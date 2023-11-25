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
    public partial class FrmDespesas : Form
    {
        conexaoDB conexao = new conexaoDB();
        string sql;
        MySqlCommand cmd;

        public FrmDespesas()
        {
            InitializeComponent();
            lblNomeUser.Text = GlobalData.UserName;
            ListagemGridDB();
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            RelatoriosFinanceiros relatoriosDespesa = new RelatoriosFinanceiros();
            relatoriosDespesa.Relatorio("Despesa");
        }

        private void ListagemGridDB()
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions WHERE user_id = @user_id AND type = @type ORDER BY user_id ASC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pelo nome

                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@type", "Despesa");

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;  // Atribui o objeto do tipo MySqlCommand ao objeto do tipo MySqlDataAdapter
                DataTable dt = new DataTable();
                da.Fill(dt); // Preenche o objeto do tipo DataTable com os dados do banco de dados usando o objeto do tipo MySqlDataAdapter
                dataGridDespesa.DataSource = dt; // Atribui o objeto do tipo DataTable como fonte de dados do grid

                conexao.FecharConexao();

                FormatacaoGrid(); // Formata as colunas do grid
            }
            catch (Exception)
            {
                MessageBox.Show("Erro ao listar dados!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void FormatacaoGrid()
        {
            dataGridDespesa.Columns[1].HeaderText = "Código usuário";
            dataGridDespesa.Columns[2].HeaderText = "Valor";
            dataGridDespesa.Columns[3].HeaderText = "Data";
            dataGridDespesa.Columns[4].HeaderText = "Tipo";
            dataGridDespesa.Columns[5].HeaderText = "Categoria";
            dataGridDespesa.Columns[6].HeaderText = "Descrição ";

            dataGridDespesa.Columns[0].Visible = false;
            dataGridDespesa.Columns[7].Visible = false;
            dataGridDespesa.Columns[8].Visible = false;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
