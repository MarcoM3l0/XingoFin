using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using iTextSharp;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;

namespace XingóFin
{
    public partial class FrmReceitas : Form
    {
        conexaoDB conexao = new conexaoDB();
        string sql;
        MySqlCommand cmd;


        public FrmReceitas()
        {
            InitializeComponent();
            lblNomeUser.Text = GlobalData.UserName;
            ListagemGridDB();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CriarEAdicionarRelatorio(SalvarRelatorioEmPastaEscolhida());
        }

        // Função para formatar as colunas do grid
        private void FormatacaoGrid()
        {
            // Define os títulos das colunas do grid
            dataGridReceitas.Columns[1].HeaderText = "Código usuário";
            dataGridReceitas.Columns[2].HeaderText = "Valor";
            dataGridReceitas.Columns[3].HeaderText = "Data";
            dataGridReceitas.Columns[4].HeaderText = "Tipo";
            dataGridReceitas.Columns[5].HeaderText = "Categoria";
            dataGridReceitas.Columns[6].HeaderText = "Descrição ";

            dataGridReceitas.Columns[0].Visible = false;
            dataGridReceitas.Columns[7].Visible = false;
            dataGridReceitas.Columns[8].Visible = false;

        }

        // Função para carregar os dados do banco de dados no grid
        private void ListagemGridDB()
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions WHERE user_id = @user_id AND type = @type ORDER BY user_id ASC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pelo nome

                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@type", "Receita");

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;  // Atribui o objeto do tipo MySqlCommand ao objeto do tipo MySqlDataAdapter
                DataTable dt = new DataTable();
                da.Fill(dt); // Preenche o objeto do tipo DataTable com os dados do banco de dados usando o objeto do tipo MySqlDataAdapter
                dataGridReceitas.DataSource = dt; // Atribui o objeto do tipo DataTable como fonte de dados do grid

                conexao.FecharConexao();

                FormatacaoGrid(); // Formata as colunas do grid
            }
            catch (Exception )
            {
                MessageBox.Show("Erro ao listar dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

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

        public void CriarEAdicionarRelatorio(string diretorio)
        {
            double totalReceita = 0;

            try
            {
                Document doc = new Document(PageSize.A4);
                doc.SetMargins(30, 20, 30, 20);
                doc.AddCreationDate();

                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(diretorio, FileMode.Create));

                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance(pbCacto.Image, System.Drawing.Imaging.ImageFormat.Png);
                logo.ScaleAbsolute(70, 70);
                doc.Add(logo);

                Paragraph titulo = new Paragraph
                {
                    Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 30),
                    Alignment = Element.ALIGN_CENTER
                };
                titulo.Add("Receita\n");
                doc.Add(titulo);

                Paragraph nomeCliente = new Paragraph
                {
                    Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 20),
                    Alignment = Element.ALIGN_CENTER
                };
                nomeCliente.Add(GlobalData.UserName + "\n");
                doc.Add(nomeCliente);


                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions WHERE user_id = @user_id AND type = @type ORDER BY `transactions`.`date` DESC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pela data

                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@type", "Receita");

                MySqlDataReader tabelaDatos = cmd.ExecuteReader();

                PdfPTable tabela = new PdfPTable(5);

                tabela.AddCell("Valor");
                tabela.AddCell("Categoria");
                tabela.AddCell("Descrição");
                tabela.AddCell("Data de imputação");
                
                tabela.AddCell("Alteração");

                while (tabelaDatos.Read())
                {
                    tabela.AddCell(tabelaDatos["amount"].ToString());

                    totalReceita += Convert.ToDouble(tabelaDatos["amount"]);

                    tabela.AddCell(tabelaDatos["category"].ToString());
                    tabela.AddCell(tabelaDatos["description"].ToString());
                    tabela.AddCell(tabelaDatos["date"].ToString());

                    if (tabelaDatos["alteration"].ToString() == "1")
                    {
                        tabela.AddCell(tabelaDatos["date_change"].ToString());
                    }
                    else
                    {
                        tabela.AddCell("Sem alteração");
                    }
                }

                doc.Add(tabela);

                conexao.FecharConexao();

                PdfPTable receita = new PdfPTable(1);
                receita.AddCell("Total da receita: " + totalReceita);

                string mensagemFinal = $"Este relatório foi gerado pelo aplicativo XingóFin em {DateTime.Now.ToString("dd/MM/yyyy")}.\n\n" +
                                       "ForPro sistemas\n" +
                                       "<i>Desempenho e Inovação: Conectando o Futuro</i>";

                Paragraph paragrafoFinal = new Paragraph(mensagemFinal)
                {
                    Alignment = Element.ALIGN_CENTER
                };
                paragrafoFinal.Font.SetStyle(iTextSharp.text.Font.ITALIC);
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }// Fim
}
