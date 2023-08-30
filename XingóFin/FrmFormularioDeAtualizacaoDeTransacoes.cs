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

namespace XingóFin
{
    public partial class FrmFormularioDeAtualizacaoDeTransacoes : Form
    {

        conexaoDB conexao = new conexaoDB();
        string sql;
        MySqlCommand cmd;



        // Lista de categorias de receitas
        private List<string> categoriasReceitas = new List<string>
        {
            "Vendas de Produtos", "Serviços Prestados", "Aluguel de Ativos", "Investimentos", "Receitas de Parcerias", "Receitas de Licenciamento", "Subsídios", "Doações", "Comissões", "Juros Recebidos", "Dividendos", "Venda de Ativos", "Reembolsos", "Participação em Eventos", "Honorários Profissionais", "Rendas de Propriedades", "Consultorias", "Receitas de Publicidade", "Cursos e Treinamentos", "Venda de Software"
        };

        // Lista de categorias de despesas
        private List<string> categoriasDespesas = new List<string> 
        {
            "Salários e Encargos", "Aluguel de Espaço", "Fornecedores de Matéria-prima", "Despesas de Marketing", "Manutenção e Reparos", "Despesas de Viagem", "Impostos e Taxas", "Contas de Energia", "Material de Escritório", "Despesas com Veículos", "Despesas Bancárias", "Seguros", "Serviços de Contabilidade", "Despesas de Treinamento", "Publicidade e Promoção", "Despesas de Eventos", "Custos de Embalagem", "Assinaturas e Licenças", "Equipamentos de Tecnologia", "Depreciação"
        };

        public FrmFormularioDeAtualizacaoDeTransacoes()
        {
            InitializeComponent();
            
        }

        private void FrmFormularioDeAtualizacaoDeTransacoes_Load(object sender, EventArgs e)
        {
            lblTeste.Text = GlobalData.UserName;
            ListagemGridDB();
        }

        private void cbxTipoDeTransacao_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxCategoria.Items.Clear();

            // Preencher o ComboBox de categorias baseado no tipo de transação selecionado
            if (cbxTipoDeTransacao.SelectedItem != null && cbxTipoDeTransacao.SelectedItem.ToString() == "Receita")
            {
                foreach (string categoria in categoriasReceitas)
                {
                    cbxCategoria.Items.Add(categoria);
                }
            }
            else if (cbxTipoDeTransacao.SelectedItem != null & cbxTipoDeTransacao.SelectedItem.ToString() == "Despesa")
            {
                foreach (string categoria in categoriasDespesas)
                {
                    cbxCategoria.Items.Add(categoria);
                }
            }
            else
                cbxCategoria.Items.Clear();
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbxTipoDeTransacao.SelectedItem == null && cbxCategoria.SelectedItem == null && (txtValor.Text == "" || txtValor.Text == " "))
                {
                    MessageBox.Show("Há campo no formulário em branco, preencha-o", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                conexao.AbrirConexao();

                sql = "INSERT INTO transactions (user_id, amount, date, type, category, description, alteration, date_change) VALUES (@user_id, @amount, @date, @type, @category, @description, @alteration, @date_change)";
                cmd = new MySqlCommand(sql, conexao.conexao);

                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@amount", txtValor.Text);
                cmd.Parameters.AddWithValue("@date", dataAtual());
                cmd.Parameters.AddWithValue("@type", cbxTipoDeTransacao.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@category", cbxCategoria.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@description", txtDescricao.Text);
                cmd.Parameters.AddWithValue("@alteration", 0);
                cmd.Parameters.AddWithValue("@date_change", " ");


                cmd.ExecuteNonQuery();

                MessageBox.Show("@user_id: " + GlobalData.userId + " @amount: " + txtValor.Text + " @date: " + dataAtual() + " @type: " + cbxTipoDeTransacao.SelectedItem.ToString() + " @category: " + cbxCategoria.SelectedItem.ToString() + " @description: " + txtDescricao.Text);

                conexao.FecharConexao();
            } 
            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o registro: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        // método para obter a data atual formatada
        private string dataAtual()
        {
            DateTime dataAtual = DateTime.Now;
            string dataFormatada = dataAtual.ToString("dd/MM/yyyy");
            return dataFormatada;
        }

        // Função para formatar as colunas do grid
        private void FormatacaoGrid()
        {
            // Define os títulos das colunas do grid
            dataGrid.Columns[1].HeaderText = "User Código";
            dataGrid.Columns[2].HeaderText = "Data";
            dataGrid.Columns[3].HeaderText = "Tipo";
            dataGrid.Columns[4].HeaderText = "Categoria";
            dataGrid.Columns[5].HeaderText = "Descrição";

            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[6].Visible = false;
            dataGrid.Columns[7].Visible = false;

        }

        // Função para carregar os dados do banco de dados no grid
        private void ListagemGridDB()
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions ORDER BY user_id ASC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pelo nome

                cmd = new MySqlCommand(sql, conexao.conexao);

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;  // Atribui o objeto do tipo MySqlCommand ao objeto do tipo MySqlDataAdapter
                DataTable dt = new DataTable();
                da.Fill(dt); // Preenche o objeto do tipo DataTable com os dados do banco de dados usando o objeto do tipo MySqlDataAdapter
                dataGrid.DataSource = dt; // Atribui o objeto do tipo DataTable como fonte de dados do grid

                conexao.FecharConexao();

                FormatacaoGrid(); // Formata as colunas do grid
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao listar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
