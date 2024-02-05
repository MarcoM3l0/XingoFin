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
    public partial class FrmRelatoriosFinanceiros : Form
    {
        public FrmRelatoriosFinanceiros()
        {
            InitializeComponent();
            lblNomeUser.Text = GlobalData.UserName;
        }


        private void btnDemonstrativoDeResultados_Click(object sender, EventArgs e)
        {
            FrmDemonstrativoDeResultados frm = new FrmDemonstrativoDeResultados();
            frm.ShowDialog();
        }

        private void btnGraficosDeAnalise_Click(object sender, EventArgs e)
        {

        }
        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
