﻿namespace XingóFin
{
    partial class FrmRelatoriosFinanceiros
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
            this.btnSair = new System.Windows.Forms.Button();
            this.btnGraficosDeAnalise = new System.Windows.Forms.Button();
            this.btnDemonstrativoDeResultados = new System.Windows.Forms.Button();
            this.lblNomeUser = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pbCacto = new System.Windows.Forms.PictureBox();
            this.pbLogoForPro = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(63)))));
            this.btnSair.Location = new System.Drawing.Point(664, 363);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(53, 28);
            this.btnSair.TabIndex = 15;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // btnGraficosDeAnalise
            // 
            this.btnGraficosDeAnalise.BackColor = System.Drawing.Color.Transparent;
            this.btnGraficosDeAnalise.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnGraficosDeAnalise.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGraficosDeAnalise.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGraficosDeAnalise.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(63)))));
            this.btnGraficosDeAnalise.Location = new System.Drawing.Point(390, 278);
            this.btnGraficosDeAnalise.Name = "btnGraficosDeAnalise";
            this.btnGraficosDeAnalise.Size = new System.Drawing.Size(181, 34);
            this.btnGraficosDeAnalise.TabIndex = 21;
            this.btnGraficosDeAnalise.Text = "Gráficos de Análise";
            this.btnGraficosDeAnalise.UseVisualStyleBackColor = false;
            this.btnGraficosDeAnalise.Click += new System.EventHandler(this.btnGraficosDeAnalise_Click);
            // 
            // btnDemonstrativoDeResultados
            // 
            this.btnDemonstrativoDeResultados.BackColor = System.Drawing.Color.Transparent;
            this.btnDemonstrativoDeResultados.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnDemonstrativoDeResultados.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDemonstrativoDeResultados.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDemonstrativoDeResultados.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(63)))));
            this.btnDemonstrativoDeResultados.Location = new System.Drawing.Point(170, 278);
            this.btnDemonstrativoDeResultados.Name = "btnDemonstrativoDeResultados";
            this.btnDemonstrativoDeResultados.Size = new System.Drawing.Size(144, 57);
            this.btnDemonstrativoDeResultados.TabIndex = 19;
            this.btnDemonstrativoDeResultados.Text = "Demonstrativo de Resultados";
            this.btnDemonstrativoDeResultados.UseVisualStyleBackColor = false;
            this.btnDemonstrativoDeResultados.Click += new System.EventHandler(this.btnDemonstrativoDeResultados_Click);
            // 
            // lblNomeUser
            // 
            this.lblNomeUser.AutoSize = true;
            this.lblNomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeUser.Location = new System.Drawing.Point(102, 12);
            this.lblNomeUser.Name = "lblNomeUser";
            this.lblNomeUser.Size = new System.Drawing.Size(0, 15);
            this.lblNomeUser.TabIndex = 25;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = global::XingóFin.Properties.Resources.Gráficos_de_Análise;
            this.pictureBox3.Location = new System.Drawing.Point(367, 67);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(225, 200);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 18;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::XingóFin.Properties.Resources.Demonstrativo_de_Resultados;
            this.pictureBox1.Location = new System.Drawing.Point(136, 67);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(200, 200);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 16;
            this.pictureBox1.TabStop = false;
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
            this.pbCacto.TabIndex = 14;
            this.pbCacto.TabStop = false;
            // 
            // pbLogoForPro
            // 
            this.pbLogoForPro.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoForPro.ErrorImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Image = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.InitialImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Location = new System.Drawing.Point(532, -40);
            this.pbLogoForPro.Name = "pbLogoForPro";
            this.pbLogoForPro.Size = new System.Drawing.Size(228, 173);
            this.pbLogoForPro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoForPro.TabIndex = 13;
            this.pbLogoForPro.TabStop = false;
            // 
            // FrmRelatoriosFinanceiros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(729, 403);
            this.Controls.Add(this.lblNomeUser);
            this.Controls.Add(this.btnGraficosDeAnalise);
            this.Controls.Add(this.btnDemonstrativoDeResultados);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pbCacto);
            this.Controls.Add(this.pbLogoForPro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmRelatoriosFinanceiros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Relatorios Financeiros";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pbCacto;
        private System.Windows.Forms.PictureBox pbLogoForPro;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.Button btnGraficosDeAnalise;
        private System.Windows.Forms.Button btnDemonstrativoDeResultados;
        private System.Windows.Forms.Label lblNomeUser;
    }
}