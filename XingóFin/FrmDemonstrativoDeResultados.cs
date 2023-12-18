using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.draw;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingóFin
{
    public partial class FrmDemonstrativoDeResultados : Form
    {
        conexaoDB conexao = new conexaoDB();
        string sql;
        MySqlCommand cmd;

        private double totalReceita;
        private double custosProdutosVendidos;
        private double margemBruta;
        private double despesasOperacionais;
        private double lucroOperacional;
        private double imposto;
        private double outrasReceitasEDespesas;
        private double liquido;
        private string textLiquido;

        public FrmDemonstrativoDeResultados()
        {
            InitializeComponent();
            CarregarInformacoesDoBanco();
        }

        private void CarregarInformacoesDoBanco()
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions WHERE user_id = @user_id";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);

                DataTable informacoes = new DataTable();

                MySqlDataReader reader = cmd.ExecuteReader();
                informacoes.Load(reader);

                TotalReceita(informacoes);
                CustosProdutosVendidos(informacoes);
                MargemBruta(totalReceita, custosProdutosVendidos);
                DespesasOperacionais(informacoes);
                LucroOperacional(margemBruta, despesasOperacionais);
                OutrasReceitasEDespesas(informacoes);
                Impostos(informacoes);
                Liquido(lucroOperacional, outrasReceitasEDespesas, imposto);

                conexao.FecharConexao();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro Carregar informaçoes!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void TotalReceita(DataTable informacoes)
        {

            totalReceita = 0;

            List<string> receitaNãoPrinciapal = new List<string>
            {
                "Investimentos", "Aluguel de Ativos", "Subsídios", "Doações", "Juros Recebidos", "Dividendos", "Venda de Ativos", "Reembolsos", "Participação em Eventos", "Honorários Profissionais", "Rendas de Propriedades", "Consultorias", "Receitas de Publicidade", "Cursos e Treinamentos"
            };

            try
            {
                foreach (DataRow row in informacoes.Rows)
                {

                    if (row["type"].ToString() == "Receita")
                        if (!receitaNãoPrinciapal.Contains(row["category"].ToString()))
                            totalReceita += Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture); ;
                }

                txtReceita.Text = $"R${totalReceita:F2}";
            }
            catch
            {
                txtReceita.Text = "Erro";
            }

            
        }

        private void CustosProdutosVendidos(DataTable informacoes)
        {
            custosProdutosVendidos = 0;

            List<string> cpv = new List<string>()
            {
                "Fornecedores de Matéria-prima", "Custos de Embalagem", "Salários e Encargos", "Manutenção e Reparos", "Despesas com Veículos", "Custos de Assinaturas e Licenças"
            };

            try
            {
                foreach (DataRow row in informacoes.Rows)
                {

                    if (row["type"].ToString() == "Despesa")
                        if (cpv.Contains(row["category"].ToString()))
                            custosProdutosVendidos += Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture); ;

                }

                txtCpv.Text = $"R${custosProdutosVendidos:F2}";
            }
            catch
            {
                txtCpv.Text = "Erro";
            }
            
        }

        private void MargemBruta(double totalReceita, double custosProdutosVendidos)
        {
            margemBruta = totalReceita - custosProdutosVendidos;
            txtMargemBruta.Text = $"R${margemBruta:F2}";
        }

        private void DespesasOperacionais(DataTable informacoes)
        {
            despesasOperacionais = 0;

            List<string> dO = new List<string>()
            {
                "Despesas de Marketing", "Despesas de Viagem", "Material de Escritório", "Despesas Bancárias", "Serviços de Contabilidade", "Despesas de Treinamento", "Publicidade e Promoção", "Despesas de Eventos", "Aluguel de Espaço", "Contas de Energia"
            };

            try
            {
                foreach (DataRow row in informacoes.Rows)
                {

                    if (row["type"].ToString() == "Despesa")
                        if (dO.Contains(row["category"].ToString()))
                            despesasOperacionais += Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture);
                }

                txtDespesasOperacionais.Text = $"R${despesasOperacionais:F2}";
            }
            catch
            {
                txtDespesasOperacionais.Text = "Erro";
            }
        }

        private void LucroOperacional(double margemBruta, double despesasOperacionais)
        {
            lucroOperacional = margemBruta - despesasOperacionais;
            txtLucroOperacional.Text = $"R${lucroOperacional:F2}";
        }

        private void Impostos(DataTable informacoes)
        {
            imposto = 0;

            try
            {
                foreach (DataRow row in informacoes.Rows)
                {

                    if (row["type"].ToString() == "Despesa")
                        if (row["category"].ToString() == "Impostos e Taxas")
                            imposto += Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture);
                }

                txtImpostos.Text = $"R${imposto:F2}";
            }
            catch
            {
                txtImpostos.Text = "Erro";
            }
        }

        private void OutrasReceitasEDespesas(DataTable informacoes)
        {
            outrasReceitasEDespesas = 0;
            double receitas = 0;
            double despesas = 0;

            List<string> outros = new List<string>
            {
                "Assinaturas e Licenças", "Equipamentos de Tecnologia", "Depreciação", "Investimentos", "Aluguel de Ativos", "Subsídios", "Doações", "Juros Recebidos", "Dividendos", "Venda de Ativos", "Reembolsos", "Participação em Eventos", "Honorários Profissionais", "Rendas de Propriedades", "Consultorias", "Receitas de Publicidade", "Cursos e Treinamentos"
            };

            try
            {
                foreach(DataRow row in informacoes.Rows)
                {
                    if (row["type"].ToString() == "Receita")
                    {
                        if (outros.Contains(row["category"].ToString()))
                            receitas += Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture);
                    }
                    else
                    {
                        if (outros.Contains(row["category"].ToString()))
                            despesas += Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture);
                    }
                }
                outrasReceitasEDespesas = receitas - despesas;

                txtOutrasReceitasEDespesas.Text = $"R${outrasReceitasEDespesas:F2}";
            }
            catch
            {

            }

        }

        private void Liquido(double lucroOperacional, double outrasReceitasEDespesas, double imposto)
        {
            liquido = lucroOperacional + outrasReceitasEDespesas - imposto;

            if(liquido >= 0)
            {
                lblLiquido.Text = "Lucro líquido:";
                lblLiquido.ForeColor = Color.Blue;
                textLiquido = "Lucro líquido";
            }
            else
            {
                lblLiquido.Text = "Prejuízo líquido:";
                lblLiquido.ForeColor = Color.Red;
                textLiquido = "Prejuízo líquido";
            }

            txtLiquido.Text = $"R${liquido:F2}";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnImprimir_Click(object sender, EventArgs e)
        {
            CriarEAdicionarRelatorio(SalvarRelatorioEmPastaEscolhida());
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

        private void CriarEAdicionarRelatorio(string diretorio)
        {
            try
            {
                Document doc = new Document(PageSize.A4);
                doc.SetMargins(30, 20, 30, 20);
                doc.AddCreationDate();

                PdfWriter pdfWriter = PdfWriter.GetInstance(doc, new FileStream(diretorio, FileMode.Create));

                doc.Open();

                iTextSharp.text.Image logoCacto = iTextSharp.text.Image.GetInstance(Properties.Resources.cacto, System.Drawing.Imaging.ImageFormat.Png);
                logoCacto.ScaleAbsolute(70, 70);
                logoCacto.SetAbsolutePosition(20, 750);
                logoCacto.Alignment = Element.ALIGN_LEFT;
                doc.Add(logoCacto);

                iTextSharp.text.Image logoMarca = iTextSharp.text.Image.GetInstance(Properties.Resources.ForPro___sistemas_removebg_preview, System.Drawing.Imaging.ImageFormat.Png);
                logoMarca.ScaleAbsolute(150, 150);
                logoMarca.SetAbsolutePosition(450, 720);
                logoMarca.Alignment = Element.ALIGN_RIGHT;
                doc.Add(logoMarca);

                Paragraph titulo = new Paragraph
                {
                    Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 30),
                    Alignment = Element.ALIGN_CENTER
                };
                titulo.Add("\n\n\n\n\nDemonstrativo de Resultados\n");
                doc.Add(titulo);

                Paragraph nomeCliente = new Paragraph
                {
                    Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.COURIER, 20),
                    Alignment = Element.ALIGN_CENTER
                };
                nomeCliente.Add(GlobalData.UserName + "\n\n");
                doc.Add(nomeCliente);

                AdicionarLinhaSeparadora(doc);

                AdicionarSecao(doc, "Receitas", totalReceita);
                AdicionarSecao(doc, "Custos dos Produtos Vendidos", custosProdutosVendidos);
                AdicionarSecao(doc, "Margem Bruta", margemBruta);
                AdicionarSecao(doc, "Despesas Operacionais", despesasOperacionais);
                AdicionarSecao(doc, "Lucro Operacional", lucroOperacional);
                AdicionarSecao(doc, "Outras Receitas e Despesas", outrasReceitasEDespesas);
                AdicionarSecao(doc, "Impostos", imposto);

                AdicionarLinhaSeparadora(doc);

                AdicionarSecao(doc, textLiquido, liquido);

                AdicionarLinhaSeparadora(doc);

                Paragraph paragrafoPenultimo = new Paragraph("\n    - O Demonstrativo de Resultados fornece uma visão clara do desempenho financeiro da empresa. As receitas representam o total de vendas, enquanto os custos dos produtos vendidos refletem os gastos associados à produção ou entrega de bens ou serviços. A margem bruta é a diferença entre as receitas e os custos dos produtos vendidos, indicando a rentabilidade bruta.\n\n" +
                                                            "   - As despesas operacionais englobam os custos associados às operações diárias da empresa, como salários, aluguel, utilitários, marketing, etc. O lucro operacional é calculado subtraindo as despesas operacionais da margem bruta.\n\n" +
                                                            "   - Outras receitas e despesas incluem itens não relacionados às operações principais da empresa, como receitas de investimentos ou despesas financeiras.\n\n" +
                                                            "   - Os impostos representam a carga tributária sobre o lucro. O lucro líquido é o resultado final, representando o lucro ou prejuízo líquido da empresa após todas as receitas, custos e despesas.\n\n" +
                                                            "   - Este relatório é uma ferramenta valiosa para avaliar a saúde financeira da empresa e identificar áreas de melhoria. Certifique-se de revisar e analisar os dados detalhadamente para tomar decisões informadas e estratégicas.\n\n")
                {                    
                    Alignment = Element.ALIGN_JUSTIFIED
                };
                paragrafoPenultimo.Font.SetStyle(iTextSharp.text.Font.ITALIC);
                paragrafoPenultimo.Font.Size = 10;

                doc.Add(paragrafoPenultimo);

                AdicionarLinhaSeparadora(doc);

                Paragraph paragrafoFinal = new Paragraph($"Demonstrativo de Resultados foi gerado pelo aplicativo XingóFin em {DateTime.Now:dd/MM/yyyy} as {DateTime.Now.ToString("HH:m:ss", CultureInfo.InvariantCulture)}.\n\n" +
                                                         "ForPro\n" +
                                                         "<i>Desempenho e Inovação: Conectando o Futuro</i>")
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
            catch
            {
                MessageBox.Show("Ocorreu um erro.\nTente novamente depois!",
                    "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        static void AdicionarSecao(Document doc, string rotulo, double valor)
        {
            iTextSharp.text.Font fonteRotulo = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12, iTextSharp.text.Font.BOLD);
            iTextSharp.text.Font fonteValor = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12);

            Paragraph rotuloParagrafo = new Paragraph(rotulo + ":", fonteRotulo);
            rotuloParagrafo.SpacingAfter = 5f;

            Paragraph valorParagrafo = new Paragraph($"     R$ {valor:F2}", fonteValor);
            valorParagrafo.SpacingAfter = 10f;

            doc.Add(rotuloParagrafo);
            doc.Add(valorParagrafo);
        }

        static void AdicionarLinhaSeparadora(Document doc)
        {
            LineSeparator linhaSeparadora = new LineSeparator();
            doc.Add(linhaSeparadora);
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

    }//Fim
}
