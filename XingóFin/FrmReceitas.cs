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
using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

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
            RelatoriosFinanceiros relatoriosReceita = new RelatoriosFinanceiros();
            relatoriosReceita.Relatorio("Receita");
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


        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }// Fim
}
