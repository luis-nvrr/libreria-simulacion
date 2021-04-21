
namespace Numeros_aleatorios.Pantallas
{
    partial class PantallaPruebaChi2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.lblResultado = new System.Windows.Forms.Label();
            this.txtEstadisticoPruebaAcumulado = new System.Windows.Forms.TextBox();
            this.txtValorCritico = new System.Windows.Forms.TextBox();
            this.lblEstadisticoPruebaAcumulado = new System.Windows.Forms.Label();
            this.lblValorCritico = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1198, 71);
            this.panel1.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(211, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Prueba de Chi2";
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdResultados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(279, 94);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(637, 375);
            this.grdResultados.TabIndex = 9;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnCopiar);
            this.groupBox1.Controls.Add(this.lblResultado);
            this.groupBox1.Controls.Add(this.txtEstadisticoPruebaAcumulado);
            this.groupBox1.Controls.Add(this.txtValorCritico);
            this.groupBox1.Controls.Add(this.lblEstadisticoPruebaAcumulado);
            this.groupBox1.Controls.Add(this.lblValorCritico);
            this.groupBox1.Controls.Add(this.grdResultados);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(42, 102);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1111, 506);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Resultados";
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(922, 94);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(172, 31);
            this.btnCopiar.TabIndex = 13;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // lblResultado
            // 
            this.lblResultado.AutoSize = true;
            this.lblResultado.Location = new System.Drawing.Point(549, 39);
            this.lblResultado.Name = "lblResultado";
            this.lblResultado.Size = new System.Drawing.Size(0, 21);
            this.lblResultado.TabIndex = 12;
            // 
            // txtEstadisticoPruebaAcumulado
            // 
            this.txtEstadisticoPruebaAcumulado.Location = new System.Drawing.Point(390, 54);
            this.txtEstadisticoPruebaAcumulado.Name = "txtEstadisticoPruebaAcumulado";
            this.txtEstadisticoPruebaAcumulado.Size = new System.Drawing.Size(100, 29);
            this.txtEstadisticoPruebaAcumulado.TabIndex = 11;
            // 
            // txtValorCritico
            // 
            this.txtValorCritico.Location = new System.Drawing.Point(390, 22);
            this.txtValorCritico.Name = "txtValorCritico";
            this.txtValorCritico.Size = new System.Drawing.Size(100, 29);
            this.txtValorCritico.TabIndex = 11;
            // 
            // lblEstadisticoPruebaAcumulado
            // 
            this.lblEstadisticoPruebaAcumulado.AutoSize = true;
            this.lblEstadisticoPruebaAcumulado.Location = new System.Drawing.Point(143, 57);
            this.lblEstadisticoPruebaAcumulado.Name = "lblEstadisticoPruebaAcumulado";
            this.lblEstadisticoPruebaAcumulado.Size = new System.Drawing.Size(241, 21);
            this.lblEstadisticoPruebaAcumulado.TabIndex = 10;
            this.lblEstadisticoPruebaAcumulado.Text = "Estadistico de prueba acumulado:";
            // 
            // lblValorCritico
            // 
            this.lblValorCritico.AutoSize = true;
            this.lblValorCritico.Location = new System.Drawing.Point(289, 25);
            this.lblValorCritico.Name = "lblValorCritico";
            this.lblValorCritico.Size = new System.Drawing.Size(95, 21);
            this.lblValorCritico.TabIndex = 10;
            this.lblValorCritico.Text = "Valor critico:";
            // 
            // PantallaPruebaChi2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1198, 633);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "PantallaPruebaChi2";
            this.Text = "Simulacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PantallaPruebaChi2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblResultado;
        private System.Windows.Forms.TextBox txtEstadisticoPruebaAcumulado;
        private System.Windows.Forms.TextBox txtValorCritico;
        private System.Windows.Forms.Label lblEstadisticoPruebaAcumulado;
        private System.Windows.Forms.Label lblValorCritico;
        private System.Windows.Forms.Button btnCopiar;
    }
}