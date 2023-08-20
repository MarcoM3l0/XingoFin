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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();
        }

        private void btnRegistroDeTransacoes_Click(object sender, EventArgs e)
        {
            FrmRegistroDeTransacoes frm = new FrmRegistroDeTransacoes();

            frm.ShowDialog();
        }

        private void btnRelatoriosFinanceiros_Click(object sender, EventArgs e)
        {
            FrmRelatoriosFinanceiros frm = new FrmRelatoriosFinanceiros();

            frm.ShowDialog();
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }
    }
}
