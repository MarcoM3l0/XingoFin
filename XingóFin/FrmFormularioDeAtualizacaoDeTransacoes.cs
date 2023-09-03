using Google.Protobuf.WellKnownTypes;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
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

        private string longtextOld_Data;
        private string longtextNew_Data;
        private string dateOld;
        private string elementType;
        private int transaction_id;
        private bool controle;

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
            lblNomeUser.Text = GlobalData.UserName;
            ListagemGridDB();
            ativarDesativarBotao(true);
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
            else if (cbxTipoDeTransacao.SelectedItem != null && cbxTipoDeTransacao.SelectedItem.ToString() == "Despesa")
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

                sql = "INSERT INTO transactions (user_id, amount, date, type, category, description) VALUES (@user_id, @amount, @date, @type, @category, @description)";
                cmd = new MySqlCommand(sql, conexao.conexao);

                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@amount", txtValor.Text);
                cmd.Parameters.AddWithValue("@date", dataAtual());
                cmd.Parameters.AddWithValue("@type", cbxTipoDeTransacao.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@category", cbxCategoria.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@description", txtDescricao.Text);


                cmd.ExecuteNonQuery();

                conexao.FecharConexao();

                limparCampos();
                ListagemGridDB();
            } 
            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o registro: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            if(dataGrid.SelectedCells.Count > 0)
            {
                int rowIndex = dataGrid.SelectedCells[0].RowIndex;

                string valorCelula = dataGrid.Rows[rowIndex].Cells[0].Value.ToString();

                if(int.TryParse(valorCelula, out int id_transacao))
                {
                    ativarDesativarBotao(false);
                    BuscarDadosDaTransacaoSelecionada(id_transacao);
                    transaction_id = id_transacao;
                }
                else
                {
                    MessageBox.Show("Erro ao buscar o id da transação", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma linha para alterar.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmarAlteracao_Click(object sender, EventArgs e)
        {
            salvarAlteracoesNoBancoDeDados();
            salvarHistoricoDeModificacoes("alteration");

            limparCampos();
            ativarDesativarBotao(true);
            ListagemGridDB();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Deseja continuar?", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            conexao.AbrirConexao();

            sql = "DELETE FROM transactions WHERE id = @id";
            cmd = new MySqlCommand(sql, conexao.conexao);
            cmd.Parameters.AddWithValue("@id", transaction_id);

            cmd.ExecuteNonQuery();
            conexao.FecharConexao();

            longtextNew_Data = "[Excluído]";
            salvarHistoricoDeModificacoes("exclusion");

            ListagemGridDB();
            ativarDesativarBotao(true);
            limparCampos();
        }


        // Função para formatar as colunas do grid
        private void FormatacaoGrid()
        {
            // Define os títulos das colunas do grid
            dataGrid.Columns[1].HeaderText = "User Código";
            dataGrid.Columns[2].HeaderText = "Valor";
            dataGrid.Columns[3].HeaderText = "Data";
            dataGrid.Columns[4].HeaderText = "Tipo";
            dataGrid.Columns[5].HeaderText = "Categoria";
            dataGrid.Columns[6].HeaderText = "Descrição ";

            dataGrid.Columns[0].Visible = false;
            dataGrid.Columns[7].Visible = false;
            dataGrid.Columns[8].Visible = false;

        }

        // Função para carregar os dados do banco de dados no grid
        private void ListagemGridDB()
        {
            try
            {
                conexao.AbrirConexao();

                sql = "SELECT * FROM transactions WHERE user_id = @user_id ORDER BY date ASC"; // Define a consulta SQL para selecionar todos os registros da tabela cliente ordenados pelo nome

                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);

                MySqlDataAdapter da = new MySqlDataAdapter();
                da.SelectCommand = cmd;  // Atribui o objeto do tipo MySqlCommand ao objeto do tipo MySqlDataAdapter
                DataTable dt = new DataTable();
                da.Fill(dt); // Preenche o objeto do tipo DataTable com os dados do banco de dados usando o objeto do tipo MySqlDataAdapter
                dataGrid.DataSource = dt; // Atribui o objeto do tipo DataTable como fonte de dados do grid

                conexao.FecharConexao();

                FormatacaoGrid(); // Formata as colunas do grid
            }
            catch (Exception error)
            {
                MessageBox.Show("Erro ao listar dados: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Função para buscar os dados da transação selecionada
        private void BuscarDadosDaTransacaoSelecionada(int id)
        {
            try
            {
                conexao.AbrirConexao();

                sql = "Select * FROM transactions WHERE id = @id";
                cmd = new MySqlCommand(sql, conexao.conexao);
                cmd.Parameters.AddWithValue("@id", id);

                MySqlDataReader reader = cmd.ExecuteReader();

                StringBuilder textBuilder = new StringBuilder();

                if (reader.Read())
                {
                    // Verifica o valor da coluna "type" e define a seleção do ComboBox de  tipo
                    string tipoDeTrasancaoDB = reader.GetString(reader.GetOrdinal("type"));

                    if(tipoDeTrasancaoDB == "Receita")
                    {
                        cbxTipoDeTransacao.SelectedIndex = 0;
                    }
                    else if(tipoDeTrasancaoDB == "Despesa")
                    {
                        cbxTipoDeTransacao.SelectedIndex = 1;
                    }


                    // Verifica o valor da coluna "category" e define a seleção do ComboBox de categoria
                    string categoriaDB = reader.GetString(reader.GetOrdinal("category"));

                    if (categoriasReceitas.Contains(categoriaDB))
                    {
                        cbxCategoria.SelectedIndex = categoriasReceitas.IndexOf(categoriaDB);
                    }
                    else if (categoriasDespesas.Contains(categoriaDB))
                    {
                        cbxCategoria.SelectedIndex = categoriasDespesas.IndexOf(categoriaDB);
                    }

                    txtValor.Text = reader.GetString(reader.GetOrdinal("amount"));
                    txtDescricao.Text = reader.GetString(reader.GetOrdinal("description"));

                    for(int i =0; i < reader.FieldCount; i++)
                    {
                        string valor = reader[i].ToString();
                        textBuilder.Append("[");
                        textBuilder.Append(valor);
                        textBuilder.Append("]");
                    }

                    if (reader.GetOrdinal("alteration") == 0)
                    {
                        controle = false;
                    }
                    else
                    {
                        controle = true;
                    }

                    longtextOld_Data = textBuilder.ToString();
                    dateOld = reader.GetString(reader.GetOrdinal("date"));
                    elementType = reader.GetString(reader.GetOrdinal("type"));
                }

                conexao.FecharConexao();
            }
            catch(Exception error)
            {
                MessageBox.Show("Erro ao buscar dados: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // funções para que as alterações seja salvas no banco de dados.
        private void salvarAlteracoesNoBancoDeDados()
        {
            try
            {
                if (cbxTipoDeTransacao.SelectedItem == null && cbxCategoria.SelectedItem == null && (txtValor.Text == "" || txtValor.Text == " "))
                {
                    MessageBox.Show("Há campo no formulário em branco, preencha-o", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                conexao.AbrirConexao();

                sql = "UPDATE transactions SET user_id = @user_id, amount = @amount, date = @date, type = @type, category = @category, description = @description, alteration = @alteration, date_change = @date_change WHERE id = @id";
                cmd = new MySqlCommand(sql, conexao.conexao);

                cmd.Parameters.AddWithValue("@id", transaction_id);

                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@amount", txtValor.Text);
                cmd.Parameters.AddWithValue("@date", dateOld);
                cmd.Parameters.AddWithValue("@type", cbxTipoDeTransacao.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@category", cbxCategoria.SelectedItem.ToString());
                cmd.Parameters.AddWithValue("@description", txtDescricao.Text);
                byte valorAlteration = 1;
                cmd.Parameters.AddWithValue("@alteration", valorAlteration);
                cmd.Parameters.AddWithValue("@date_change", dataAtual());


                cmd.ExecuteNonQuery();

                conexao.FecharConexao();

                StringBuilder textBuilder = new StringBuilder();
                textBuilder.Append("[");
                textBuilder.Append(transaction_id);
                textBuilder.Append("]");
                textBuilder.Append("[");
                textBuilder.Append(GlobalData.userId);
                textBuilder.Append("]");
                textBuilder.Append("[");
                textBuilder.Append(txtValor.Text);
                textBuilder.Append("]");
                textBuilder.Append("[");
                textBuilder.Append(dateOld);
                textBuilder.Append("]");
                textBuilder.Append("[");
                textBuilder.Append(cbxTipoDeTransacao.SelectedItem.ToString());
                textBuilder.Append("]");
                textBuilder.Append("[");
                textBuilder.Append(cbxCategoria.SelectedItem.ToString());
                textBuilder.Append("]");
                textBuilder.Append("[");
                textBuilder.Append(txtDescricao.Text);
                textBuilder.Append("]");

                if (controle)
                {
                    textBuilder.Append("[");
                    textBuilder.Append(valorAlteration);
                    textBuilder.Append("]");
                    textBuilder.Append("[");
                    textBuilder.Append(dataAtual());
                    textBuilder.Append("]");
                }
                
                longtextNew_Data = textBuilder.ToString();

            }
            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao salvar alteração de registro: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        // funções de salavar histórico de modificações em registros.
        private void salvarHistoricoDeModificacoes(string action)
        {
            try
            {
                conexao.AbrirConexao();

                sql = "INSERT INTO historic (user_id, timestamp, action, element_type, element_id, old_data, new_data) VALUES (@user_id, @timestamp, @action, @element_type, @element_id, @old_data, @new_data) ";
                cmd = new MySqlCommand(sql, conexao.conexao);

                cmd.Parameters.AddWithValue("@user_id", GlobalData.userId);
                cmd.Parameters.AddWithValue("@timestamp", dataEHoraAlteracao());

                if(action == "alteration")
                {
                    cmd.Parameters.AddWithValue("@action", "Alteração");
                }
                else if(action == "exclusion")
                {
                    cmd.Parameters.AddWithValue("@action", "Exclusão");
                }

                
                cmd.Parameters.AddWithValue("@element_type", elementType);
                cmd.Parameters.AddWithValue("@element_id", transaction_id);
                cmd.Parameters.AddWithValue("@old_data", longtextOld_Data);
                cmd.Parameters.AddWithValue("@new_data", longtextNew_Data);



                cmd.ExecuteNonQuery();

                conexao.FecharConexao();
            }
            catch (Exception error)
            {
                MessageBox.Show("Ocorreu um erro ao salvar o historico de alteração de registro: " + error.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para obter a data atual formatada
        private string dataAtual()
        {
            DateTime dataAtual = DateTime.Now;
            string dataFormatada = dataAtual.ToString("dd/MM/yyyy");
            return dataFormatada;
        }

        // Método para obter a data da alteração formatada
        private string dataEHoraAlteracao()
        {
            DateTime dataHora = DateTime.Now;
            string dataFormatada = dataHora.ToString("dd/MM/yyyy - HH:mm");
            return dataFormatada;
        }
        private void limparCampos()
        {
            txtValor.Text = "";
            txtDescricao.Text = "";
            cbxCategoria.SelectedIndex = -1;
            cbxTipoDeTransacao.SelectedIndex = -1;
        }

        private void ativarDesativarBotao(bool controle)
        {
            btnConfirmar.Enabled = controle;
            btnAlterar.Enabled = controle;
            btnCancelar.Enabled = !controle;
            btnExcluir.Enabled = !controle;
            btnConfirmarAlteracao.Enabled = !controle;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ativarDesativarBotao(true);
            limparCampos();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }//FIM
}
