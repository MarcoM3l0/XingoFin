using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XingóFin
{
    // Classe responsável por lidar com a conexão ao banco de dados
    internal class conexaoDB
    {

        // String de conexão para o banco de dados
        private string stringConexao = "SERVER=localhost; DATABASE=xingofin_db; UID=root; PWD=; PORT=;";

        // Objeto de conexão que será utilizado para interagir com o banco de dados
        public MySqlConnection conexao = null;

        // Método para abrir a conexão com o banco de dados
        public void AbrirConexao()
        {
            try
            {
                // Inicializa uma nova instância da conexão usando a string de conexão
                conexao = new MySqlConnection(stringConexao);
                conexao.Open();

            }
            catch (Exception error)
            {
                MessageBox.Show("Problema ao abrir o servidor. Erro: " + error.Message);
            }
        }

        // Método para fechar a conexão com o banco de dados
        public void FecharConexao()
        {
            try
            {
                conexao = new MySqlConnection(stringConexao); 
                conexao.Close();
                conexao.Dispose();
                conexao.ClearAllPoolsAsync();
            }
            catch(Exception error)
            {
                MessageBox.Show("Problema ao abrir o servidor.Erro: " + error.Message);
            }
        }

    }
}
