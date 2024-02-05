namespace XingóFin
{
    partial class FrmFluxoDeCaixa
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFluxoDeCaixa));
            this.pbLogoForPro = new System.Windows.Forms.PictureBox();
            this.pbCacto = new System.Windows.Forms.PictureBox();
            this.btnSair = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).BeginInit();
            this.SuspendLayout();
            // 
            // pbLogoForPro
            // 
            this.pbLogoForPro.BackColor = System.Drawing.Color.Transparent;
            this.pbLogoForPro.ErrorImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Image = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.InitialImage = global::XingóFin.Properties.Resources.ForPro___sistemas_removebg_preview;
            this.pbLogoForPro.Location = new System.Drawing.Point(598, -40);
            this.pbLogoForPro.Name = "pbLogoForPro";
            this.pbLogoForPro.Size = new System.Drawing.Size(228, 173);
            this.pbLogoForPro.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbLogoForPro.TabIndex = 16;
            this.pbLogoForPro.TabStop = false;
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
            this.pbCacto.TabIndex = 15;
            this.pbCacto.TabStop = false;
            // 
            // btnSair
            // 
            this.btnSair.BackColor = System.Drawing.Color.Transparent;
            this.btnSair.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnSair.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSair.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSair.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(139)))), ((int)(((byte)(90)))), ((int)(((byte)(43)))));
            this.btnSair.Location = new System.Drawing.Point(735, 410);
            this.btnSair.Name = "btnSair";
            this.btnSair.Size = new System.Drawing.Size(53, 28);
            this.btnSair.TabIndex = 17;
            this.btnSair.Text = "Sair";
            this.btnSair.UseVisualStyleBackColor = false;
            this.btnSair.Click += new System.EventHandler(this.btnSair_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 18;
            this.label1.Text = "label1";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(15, 115);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 19;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(121, 115);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(212, 20);
            this.dateTimePicker1.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(118, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 13);
            this.label2.TabIndex = 21;
            this.label2.Text = "Período de análise";
            // 
            // FrmFluxoDeCaixa
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(128)))), ((int)(((byte)(185)))));
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSair);
            this.Controls.Add(this.pbLogoForPro);
            this.Controls.Add(this.pbCacto);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FrmFluxoDeCaixa";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fluxo de Caixa";
            ((System.ComponentModel.ISupportInitialize)(this.pbLogoForPro)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbCacto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbCacto;
        private System.Windows.Forms.PictureBox pbLogoForPro;
        private System.Windows.Forms.Button btnSair;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label2;
    }
}