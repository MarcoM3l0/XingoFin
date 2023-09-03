﻿using System;
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
    public partial class FrmRegistroDeTransacoes : Form
    {
        public FrmRegistroDeTransacoes()
        {
            InitializeComponent();
            lblNomeUser.Text = GlobalData.UserName;
        }

        private void btnSair_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAtualizacaoDeTransacoes_Click(object sender, EventArgs e)
        {
            FrmFormularioDeAtualizacaoDeTransacoes frm = new FrmFormularioDeAtualizacaoDeTransacoes();

            frm.ShowDialog();
        }
    }
}
