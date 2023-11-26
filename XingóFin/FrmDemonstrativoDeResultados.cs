using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
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
            }
            else
            {
                lblLiquido.Text = "Prejuízo líquido:";
                lblLiquido.ForeColor = Color.Red;
            }

            txtLiquido.Text = $"R${liquido:F2}";
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
