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
    }
}
