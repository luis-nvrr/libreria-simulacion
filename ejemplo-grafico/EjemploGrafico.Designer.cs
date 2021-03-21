namespace Numeros_aleatorios
{
    partial class EjemploGrafico
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
            this.picHisto = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).BeginInit();
            this.SuspendLayout();
            // 
            // picHisto
            // 
            this.picHisto.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picHisto.BackColor = System.Drawing.Color.White;
            this.picHisto.Cursor = System.Windows.Forms.Cursors.Cross;
            this.picHisto.Location = new System.Drawing.Point(0, 4);
            this.picHisto.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.picHisto.Name = "picHisto";
            this.picHisto.Size = new System.Drawing.Size(476, 229);
            this.picHisto.TabIndex = 1;
            this.picHisto.TabStop = false;
            this.picHisto.Paint += new System.Windows.Forms.PaintEventHandler(this.picHisto_Paint);
            this.picHisto.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picHisto_MouseDown);
            this.picHisto.Resize += new System.EventHandler(this.picHisto_Resize);
            // 
            // EjemploGrafico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 237);
            this.Controls.Add(this.picHisto);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "EjemploGrafico";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "howto_histogram";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picHisto)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.PictureBox picHisto;
    }
}

