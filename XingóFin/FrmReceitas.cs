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

        // Função para formatar as colunas do grid
        private void FormatacaoGrid()
        {
            // Define os títulos das colunas do grid
            dataGridReceitas.Columns[1].HeaderText = "User Código";
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

                sql = "SELECT * FROM transactions WHERE user_id = @user_id ORDER BY user_id DESC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pelo nome

                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;  // Atribui o objeto do tipo MySqlCommand ao objeto do tipo MySqlDataAdapter
                DataTable dt = new DataTable();
                da.Fill(dt); // Preenche o objeto do tipo DataTable com os dados do banco de dados usando o objeto do tipo MySqlDataAdapter
                dataGridReceitas.DataSource = dt; // Atribui o objeto do tipo DataTable como fonte de dados do grid

                conexao.FecharConexao();

                FormatacaoGrid(); // Formata as colunas do grid
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao listar dados: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }// Fim
}
