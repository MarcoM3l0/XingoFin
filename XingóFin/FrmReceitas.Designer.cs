namespace XingóFin
{
    partial class FrmReceitas
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
            this.pbCacto = new System.Windows.Forms.PictureBox();
            this.pbLogoForPro = new System.Windows.Forms.PictureBox();
            this.dataGridReceitas = new System.Windows.Forms.DataGridView();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.lblNomeUser = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReceitas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.btnSair.Location = new System.Drawing.Point(650, 407);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(53, 31);
            this.btnSair.TabIndex = 14;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
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
            this.pbCacto.TabIndex = 13;
            this.pbCacto.TabStop = false;
            // 
            // pbLogoForPro
            // 
            this.pbLogoForPro.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoForPro.ErrorImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Image = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.InitialImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Location = new System.Drawing.Point(531, -40);
            this.pbLogoForPro.Name = "pbLogoForPro";
            this.pbLogoForPro.Size = new System.Drawing.Size(228, 173);
            this.pbLogoForPro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoForPro.TabIndex = 12;
            this.pbLogoForPro.TabStop = false;
            // 
            // dataGridReceitas
            // 
            this.dataGridReceitas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridReceitas.Location = new System.Drawing.Point(32, 110);
            this.dataGridReceitas.Name = "dataGridReceitas";
            this.dataGridReceitas.Size = new System.Drawing.Size(671, 242);
            this.dataGridReceitas.TabIndex = 15;
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Transparent;
            this.btnImprimir.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnImprimir.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnImprimir.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(87)))), ((int)(((byte)(51)))));
            this.btnImprimir.Location = new System.Drawing.Point(29, 358);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(86, 34);
            this.btnImprimir.TabIndex = 16;
            this.btnImprimir.Text = "Imprimir ";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // lblNomeUser
            // 
            this.lblNomeUser.AutoSize = true;
            this.lblNomeUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNomeUser.Location = new System.Drawing.Point(90, 12);
            this.lblNomeUser.Name = "lblNomeUser";
            this.lblNomeUser.Size = new System.Drawing.Size(0, 15);
            this.lblNomeUser.TabIndex = 26;
            // 
            // FrmReceitas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(726, 450);
            this.Controls.Add(this.lblNomeUser);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.dataGridReceitas);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pbCacto);
            this.Controls.Add(this.pbLogoForPro);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmReceitas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Receitas";
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridReceitas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.PictureBox pbCacto;
        private System.Windows.Forms.PictureBox pbLogoForPro;
        private System.Windows.Forms.DataGridView dataGridReceitas;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Label lblNomeUser;
    }
}