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
    public partial class FrmLogin : Form
    {
        private conexaoDB conexao = new conexaoDB(); // Instância do objeto de conexão com o banco de dados
        private string sql; // String  SQL
        private MySqlCommand cmd; // String que armazena a query SQL
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            try
            {

                // Verifica se os campos de login estão em branco
                if (txtEmail.Text.Trim() == "" || txtPassword.Text.Trim() == "")
                {
                    MessageBox.Show("Há campo de login em branco, preencha-o", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    return;
                }

                // Verifica se o usuário existe no banco de dados
                else if (!Usuario(txtEmail.Text))
                {
                    MessageBox.Show("Email não cadastrado!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    txtEmail.Text = "";
                    return;
                }

                // Verifica se a senha é válida
                else if (!ValidarSenha(txtEmail.Text, txtPassword.Text))
                {
                    MessageBox.Show("Senha errada!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtEmail.Focus();
                    txtEmail.Text = "";
                    txtPassword.Text = "";
                    return;
                }

                // Abre o formulário principal e esconde o formulário de login
                this.Hide();

                FrmPrincipal principal = new FrmPrincipal();
                principal.ShowDialog();

                if (principal.IsDisposed)
                {
                    this.Close();
                }
                
            }

            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao processar a solicitação: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        
        }

        // Verifica se o usuário existe no banco de dados
        private bool Usuario(string email)
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT * FROM users WHERE email=@email";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("email", email);

                Object result = cmd.ExecuteScalar();

                conexao.FecharConexao();

                int count = result != null ? (int)result : 0;

                if (count > 0)
                    return true;
                else
                    return false;

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao verificar o e-mail no servidor: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Verifica se a senha é válida para o usuário
        private bool ValidarSenha(string email, string password)
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT password FROM users WHERE email=@email";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("email", email);

                string passwordDB = (string)cmd.ExecuteScalar();

                conexao.FecharConexao();

                if (passwordDB == password)
                    return true;
                else
                    return false;
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao validar a senha no servidor: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

        }
    }
}
