namespace XingóFin
{
    partial class FrmRegistroDeTransacoes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmRegistroDeTransacoes));
            this.pbCacto = new System.Windows.Forms.PictureBox();
            this.pbLogoForPro = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).BeginInit();
            this.SuspendLayout();
            // 
            // pbCacto
            // 
            this.pbCacto.BackColor = System.Drawing.Color.Transparent;
            this.pbCacto.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.pbCacto.Image = global::XingóFin.Properties.Resources.cacto;
            this.pbCacto.Location = new System.Drawing.Point(10, 8);
            this.pbCacto.Name = "pbCacto";
            this.pbCacto.Size = new System.Drawing.Size(70, 70);
            this.pbCacto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbCacto.TabIndex = 3;
            this.pbCacto.TabStop = false;
            // 
            // pbLogoForPro
            // 
            this.pbLogoForPro.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoForPro.ErrorImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Image = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.InitialImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Location = new System.Drawing.Point(596, -44);
            this.pbLogoForPro.Name = "pbLogoForPro";
            this.pbLogoForPro.Size = new System.Drawing.Size(228, 173);
            this.pbLogoForPro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoForPro.TabIndex = 2;
            this.pbLogoForPro.TabStop = false;
            // 
            // FrmRegistroDeTransacoes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(43)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pbCacto);
            this.Controls.Add(this.pbLogoForPro);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmRegistroDeTransacoes";
            this.Text = "Registro de Transações";
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCacto;
        private System.Windows.Forms.PictureBox pbLogoForPro;
    }
}