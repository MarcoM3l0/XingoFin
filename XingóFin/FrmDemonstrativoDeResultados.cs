﻿using MySql.Data.MySqlClient;
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
                DespesasOperacionais(informacoes);

                conexao.FecharConexao();
            }
            catch (Exception)
            {
                MessageBox.Show("Erro Carregar informaçoes!", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void TotalReceita(DataTable informacoes)
        {
            double totalReceita = 0;

            try
            {
                foreach (DataRow row in informacoes.Rows)
                {
                    var tipo = row["type"].ToString();
                    double valor = Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture);

                    if (tipo == "Receita")
                        totalReceita += valor;
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
            double custosProdutosVendidos = 0;
            List<string> cpv = new List<string>()
            {
                "Fornecedores de Matéria-prima", "Custos de Embalagem", "Salários e Encargos", "Manutenção e Reparos", "Despesas com Veículos", "Custos de Assinaturas e Licenças"
            };
            try
            {
                foreach (DataRow row in informacoes.Rows)
                {
                    var tipo = row["type"].ToString();
                    var categoria = row["category"].ToString();
                    double valor = Convert.ToDouble(row["amount"], CultureInfo.InvariantCulture);

                    if (tipo == "Despesa")
                        if (cpv.Contains(categoria))
                            custosProdutosVendidos += valor;

                }

                txtCpv.Text = $"R${custosProdutosVendidos:F2}";
            }
            catch
            {
                txtCpv.Text = "Erro";
            }
            
        }

        private void DespesasOperacionais(DataTable informacoes)
        {
            double despesasOperacionais = 0;
            List<string> dO = new List<string>()
            {
                "Despesas de Marketing", "Despesas de Viagem", "Material de Escritório", "Despesas Bancárias", "Serviços de Contabilidade", "Despesas de Treinamento", "Publicidade e Promoção", "Despesas de Eventos", "Aluguel de Espaço", "Contas de Energia"
            };

            try
            {
                foreach (DataRow row in informacoes.Rows)
                {
                    var tipo = row["type"].ToString();
                    if (tipo == "Despesa")
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

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
