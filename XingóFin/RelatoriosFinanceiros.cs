using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingóFin
{
    internal class RelatoriosFinanceiros
    {
        private readonly conexaoDB conexao = new conexaoDB();
        private string sql;
        private MySqlCommand cmd;

        public void Relatorio(string tipoRelatorio)
        {
            CriarEAdicionarRelatorio(SalvarRelatorioEmPastaEscolhida(), tipoRelatorio);
        }

        // Este método cria e adiciona um relatório em formato PDF, consolidando informações de receitas.
        private void CriarEAdicionarRelatorio(string diretorio, string tipoRelatorio)
        {
            double totalValor = 0;

            try
            {
                // Configuração do documento PDF
                Document doc = new Document(PageSize.A4);
                doc.SetMargins(30, 20, 30, 20);
                doc.AddCreationDate();

                // Configuração do escritor PDF
                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(diretorio, FileMode.Create));

                // Abertura do documento
                doc.Open();

                // Adição de imagem ao documento
                Image logoCacto = Image.GetInstance(Properties.Resources.cacto, System.Drawing.Imaging.ImageFormat.Png);
                logoCacto.ScaleAbsolute(70, 70);
                logoCacto.Alignment = Element.ALIGN_LEFT;
                doc.Add(logoCacto);


                Paragraph titulo = new Paragraph
                {
                    Font = new Font(Font.FontFamily.COURIER, 30),
                    Alignment = Element.ALIGN_CENTER
                };
                titulo.Add($"{tipoRelatorio}\n");
                doc.Add(titulo);

                Paragraph nomeCliente = new Paragraph
                {
                    Font = new Font(Font.FontFamily.COURIER, 20),
                    Alignment = Element.ALIGN_CENTER
                };
                nomeCliente.Add(GlobalData.UserName + "\n\n");
                doc.Add(nomeCliente);


                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions WHERE user_id = @user_id AND type = @type ORDER BY `transactions`.`date` DESC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pela data

                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@type", tipoRelatorio);

                MySqlDataReader tabelaDatos = cmd.ExecuteReader();

                // Criação de tabela PDF para exibir dados das transações
                PdfPTable tabela = new PdfPTable(5);

                tabela.AddCell("Valor");
                tabela.AddCell("Categoria");
                tabela.AddCell("Descrição");
                tabela.AddCell("Data de imputação");

                tabela.AddCell("Alteração");

                // Preenchimento da tabela com dados das transações
                while (tabelaDatos.Read())
                {
                    tabela.AddCell($"R${tabelaDatos["amount"]}");

                    totalValor += Convert.ToDouble(tabelaDatos["amount"], CultureInfo.InvariantCulture);

                    tabela.AddCell(tabelaDatos["category"].ToString());
                    tabela.AddCell(tabelaDatos["description"].ToString());
                    tabela.AddCell(tabelaDatos["date"].ToString());

                    if (Convert.ToByte(tabelaDatos["alteration"]) == 1)
                    {
                        tabela.AddCell($"Teve alteração em {tabelaDatos["date_change"]}");
                    }
                    else
                    {
                        tabela.AddCell("Sem alteração");
                    }
                }

                doc.Add(tabela);

                conexao.FecharConexao();

                PdfPTable receita = new PdfPTable(1);
                receita.AddCell($"Total da {tipoRelatorio.ToLower()}: R${totalValor:F2}\n\n");

                doc.Add(receita);


                Paragraph paragrafoFinal = new Paragraph($"Este relatório de {tipoRelatorio.ToLower()} foi gerado pelo aplicativo XingóFin em {DateTime.Now:dd/MM/yyyy} as {DateTime.Now.ToString("HH:m:ss", CultureInfo.InvariantCulture)}.\n\n" +
                                                         "ForPro\n" +
                                                         "<i>Desempenho e Inovação: Conectando o Futuro</i>")
                {
                    Alignment = Element.ALIGN_CENTER
                };
                paragrafoFinal.Font.SetStyle(Font.ITALIC);
                paragrafoFinal.Font.Size = 9;

                doc.Add(paragrafoFinal);

                doc.Close();

                if (MessageBox.Show("Relatório gerado com sucesso!\nDejesa abri o relatório? ", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    AbrirPDF(diretorio);
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Ocorreu um erro ao trazer os dados\nTente novamente depois!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                MessageBox.Show("" + ex);
            }


        }

        // Este método exibe uma caixa de diálogo para salvar um arquivo, permitindo que o usuário escolha a pasta e o nome do arquivo.
        // Ele retorna o caminho completo do arquivo, incluindo o nome do arquivo e a extensão escolhidos pelo usuário.
        private string SalvarRelatorioEmPastaEscolhida()
        {
            string caminho = "";

            SaveFileDialog saveFile = new SaveFileDialog
            {
                Filter = "Arquivos PDF (*.pdf)|*.pdf|Todos os arquivos (*.*)|*.*",
                FilterIndex = 1,

                Title = "Salvar Relatório"
            };

            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                caminho = saveFile.FileName;
            }

            return caminho;
        }

        // Abre um arquivo PDF no visualizador padrão do sistema.
        private void AbrirPDF(string diretorio)
        {
            try
            {
                Process.Start(diretorio);
            }
            catch
            {
                MessageBox.Show("Ocorreu um erro ao abrir o relatório.",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    } //Fim
}
