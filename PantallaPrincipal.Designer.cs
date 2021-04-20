
namespace Numeros_aleatorios
{
    partial class PantallaPrincipal
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
            this.label1 = new System.Windows.Forms.Label();
            this.btnPantallaGeneradores = new System.Windows.Forms.Button();
            this.btnPruebaJI = new System.Windows.Forms.Button();
            this.btnPruebaKS = new System.Windows.Forms.Button();
            this.btnPantallaVariablesAleatorias = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Location = new System.Drawing.Point(51, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(280, 35);
            this.label1.TabIndex = 0;
            this.label1.Text = "¿Qué desea hacer?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnPantallaGeneradores
            // 
            this.btnPantallaGeneradores.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPantallaGeneradores.Location = new System.Drawing.Point(114, 68);
            this.btnPantallaGeneradores.Name = "btnPantallaGeneradores";
            this.btnPantallaGeneradores.Size = new System.Drawing.Size(154, 52);
            this.btnPantallaGeneradores.TabIndex = 1;
            this.btnPantallaGeneradores.Text = "Ir a Pantalla de generadores";
            this.btnPantallaGeneradores.UseVisualStyleBackColor = true;
            this.btnPantallaGeneradores.Click += new System.EventHandler(this.btnPantallaGeneradores_Click);
            // 
            // btnPruebaJI
            // 
            this.btnPruebaJI.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPruebaJI.Location = new System.Drawing.Point(114, 144);
            this.btnPruebaJI.Name = "btnPruebaJI";
            this.btnPruebaJI.Size = new System.Drawing.Size(154, 30);
            this.btnPruebaJI.TabIndex = 2;
            this.btnPruebaJI.Text = "Prueba JI^2";
            this.btnPruebaJI.UseVisualStyleBackColor = true;
            this.btnPruebaJI.Click += new System.EventHandler(this.btnPruebaJI_Click);
            // 
            // btnPruebaKS
            // 
            this.btnPruebaKS.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPruebaKS.Location = new System.Drawing.Point(114, 199);
            this.btnPruebaKS.Name = "btnPruebaKS";
            this.btnPruebaKS.Size = new System.Drawing.Size(154, 30);
            this.btnPruebaKS.TabIndex = 3;
            this.btnPruebaKS.Text = "Prueba K-S";
            this.btnPruebaKS.UseVisualStyleBackColor = true;
            this.btnPruebaKS.Click += new System.EventHandler(this.btnPruebaKS_Click);
            // 
            // btnPantallaVariablesAleatorias
            // 
            this.btnPantallaVariablesAleatorias.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.btnPantallaVariablesAleatorias.Location = new System.Drawing.Point(114, 253);
            this.btnPantallaVariablesAleatorias.Name = "btnPantallaVariablesAleatorias";
            this.btnPantallaVariablesAleatorias.Size = new System.Drawing.Size(154, 74);
            this.btnPantallaVariablesAleatorias.TabIndex = 4;
            this.btnPantallaVariablesAleatorias.Text = "Ir a Pantalla de variables aleatorias";
            this.btnPantallaVariablesAleatorias.UseVisualStyleBackColor = true;
            this.btnPantallaVariablesAleatorias.Click += new System.EventHandler(this.btnPantallaVariablesAleatorias_Click);
            // 
            // PantallaPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(384, 361);
            this.Controls.Add(this.btnPantallaVariablesAleatorias);
            this.Controls.Add(this.btnPruebaKS);
            this.Controls.Add(this.btnPruebaJI);
            this.Controls.Add(this.btnPantallaGeneradores);
            this.Controls.Add(this.label1);
            this.Name = "PantallaPrincipal";
            this.Text = "PantallaPrincipal";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnPantallaGeneradores;
        private System.Windows.Forms.Button btnPruebaJI;
        private System.Windows.Forms.Button btnPruebaKS;
        private System.Windows.Forms.Button btnPantallaVariablesAleatorias;
    }
}