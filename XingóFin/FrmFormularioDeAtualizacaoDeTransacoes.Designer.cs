namespace XingóFin
{
    partial class FrmFormularioDeAtualizacaoDeTransacoes
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pbCacto = new System.Windows.Forms.PictureBox();
            this.pbLogoForPro = new System.Windows.Forms.PictureBox();
            this.cbxTipoDeTransacao = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescricao = new System.Windows.Forms.TextBox();
            this.dataGrid = new System.Windows.Forms.DataGridView();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCacto
            // 
            this.pbCacto.BackColor = System.Drawing.Color.Transparent;
            this.pbCacto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbCacto.Image = global::XingóFin.Properties.Resources.cacto;
            this.pbCacto.Location = new System.Drawing.Point(12, 12);
            this.pbCacto.Name = "pbCacto";
            this.pbCacto.Size = new System.Drawing.Size(70, 70);
            this.pbCacto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCacto.TabIndex = 5;
            this.pbCacto.TabStop = false;
            // 
            // pbLogoForPro
            // 
            this.pbLogoForPro.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoForPro.ErrorImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Image = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.InitialImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Location = new System.Drawing.Point(735, -40);
            this.pbLogoForPro.Name = "pbLogoForPro";
            this.pbLogoForPro.Size = new System.Drawing.Size(228, 173);
            this.pbLogoForPro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoForPro.TabIndex = 4;
            this.pbLogoForPro.TabStop = false;
            // 
            // cbxTipoDeTransacao
            // 
            this.cbxTipoDeTransacao.BackColor = System.Drawing.SystemColors.Window;
            this.cbxTipoDeTransacao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxTipoDeTransacao.FormattingEnabled = true;
            this.cbxTipoDeTransacao.Items.AddRange(new object[] {
            "Receita",
            "Despesa"});
            this.cbxTipoDeTransacao.Location = new System.Drawing.Point(12, 112);
            this.cbxTipoDeTransacao.Name = "cbxTipoDeTransacao";
            this.cbxTipoDeTransacao.Size = new System.Drawing.Size(121, 21);
            this.cbxTipoDeTransacao.TabIndex = 7;
            this.cbxTipoDeTransacao.SelectedIndexChanged += new System.EventHandler(this.cbxTipoDeTransacao_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(126, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "Tipo de Transação";
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(156, 113);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(120, 20);
            this.txtValor.TabIndex = 9;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(153, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 15);
            this.label2.TabIndex = 10;
            this.label2.Text = "Valor";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(293, 95);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "Categoria";
            // 
            // cbxCategoria
            // 
            this.cbxCategoria.BackColor = System.Drawing.SystemColors.Window;
            this.cbxCategoria.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbxCategoria.FormattingEnabled = true;
            this.cbxCategoria.Location = new System.Drawing.Point(296, 113);
            this.cbxCategoria.Name = "cbxCategoria";
            this.cbxCategoria.Size = new System.Drawing.Size(121, 21);
            this.cbxCategoria.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(9, 169);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "Descrição";
            // 
            // txtDescricao
            // 
            this.txtDescricao.Location = new System.Drawing.Point(12, 187);
            this.txtDescricao.Multiline = true;
            this.txtDescricao.Name = "txtDescricao";
            this.txtDescricao.Size = new System.Drawing.Size(405, 148);
            this.txtDescricao.TabIndex = 14;
            // 
            // dataGrid
            // 
            this.dataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGrid.Location = new System.Drawing.Point(436, 187);
            this.dataGrid.Name = "dataGrid";
            this.dataGrid.Size = new System.Drawing.Size(485, 251);
            this.dataGrid.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(433, 169);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(159, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "Registro de Transações";
            // 
            // FrmFormularioDeAtualizacaoDeTransacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.ClientSize = new System.Drawing.Size(933, 450);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dataGrid);
            this.Controls.Add(this.txtDescricao);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbxCategoria);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValor);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbxTipoDeTransacao);
            this.Controls.Add(this.pbCacto);
            this.Controls.Add(this.pbLogoForPro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmFormularioDeAtualizacaoDeTransacoes";
            this.Text = "Atualização de Transações";
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCacto;
        private System.Windows.Forms.PictureBox pbLogoForPro;
        private System.Windows.Forms.ComboBox cbxTipoDeTransacao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescricao;
        private System.Windows.Forms.DataGridView dataGrid;
        private System.Windows.Forms.Label label5;
    }
}