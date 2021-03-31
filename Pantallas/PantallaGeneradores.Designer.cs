
namespace Numeros_aleatorios
{
    partial class PantallaGeneradores
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gbOpcion = new System.Windows.Forms.GroupBox();
            this.rbMultiplicativo = new System.Windows.Forms.RadioButton();
            this.rbLineal = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.modulo = new System.Windows.Forms.TextBox();
            this.constanteMultiplicativa = new System.Windows.Forms.TextBox();
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.constanteAditiva = new System.Windows.Forms.TextBox();
            this.enteroG = new System.Windows.Forms.TextBox();
            this.enteroK = new System.Windows.Forms.TextBox();
            this.semilla = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.gbOpcion.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.gbResultados.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // gbOpcion
            // 
            this.gbOpcion.Controls.Add(this.rbMultiplicativo);
            this.gbOpcion.Controls.Add(this.rbLineal);
            this.gbOpcion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbOpcion.Location = new System.Drawing.Point(12, 98);
            this.gbOpcion.Name = "gbOpcion";
            this.gbOpcion.Size = new System.Drawing.Size(329, 100);
            this.gbOpcion.TabIndex = 0;
            this.gbOpcion.TabStop = false;
            this.gbOpcion.Text = "1. Seleccione un método:";
            // 
            // rbMultiplicativo
            // 
            this.rbMultiplicativo.AutoSize = true;
            this.rbMultiplicativo.Location = new System.Drawing.Point(38, 59);
            this.rbMultiplicativo.Name = "rbMultiplicativo";
            this.rbMultiplicativo.Size = new System.Drawing.Size(259, 25);
            this.rbMultiplicativo.TabIndex = 1;
            this.rbMultiplicativo.TabStop = true;
            this.rbMultiplicativo.Text = "Congruencial lineal multiplicativo";
            this.rbMultiplicativo.UseVisualStyleBackColor = true;
            // 
            // rbLineal
            // 
            this.rbLineal.AutoSize = true;
            this.rbLineal.Location = new System.Drawing.Point(38, 33);
            this.rbLineal.Name = "rbLineal";
            this.rbLineal.Size = new System.Drawing.Size(204, 25);
            this.rbLineal.TabIndex = 0;
            this.rbLineal.TabStop = true;
            this.rbLineal.Text = "Congruencial lineal mixto";
            this.rbLineal.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.modulo);
            this.groupBox1.Controls.Add(this.constanteMultiplicativa);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.constanteAditiva);
            this.groupBox1.Controls.Add(this.enteroG);
            this.groupBox1.Controls.Add(this.enteroK);
            this.groupBox1.Controls.Add(this.semilla);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(10, 204);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 174);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2. Ingrese los valores:";
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(186, 119);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(145, 21);
            this.lblCantidad.TabIndex = 4;
            this.lblCantidad.Text = "Cantidad a generar:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(633, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(27, 21);
            this.label6.TabIndex = 2;
            this.label6.Text = "m:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(514, 36);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 21);
            this.label5.TabIndex = 2;
            this.label5.Text = "a:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(395, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(20, 21);
            this.label4.TabIndex = 2;
            this.label4.Text = "c:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(276, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 21);
            this.label3.TabIndex = 2;
            this.label3.Text = "g:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(21, 21);
            this.label2.TabIndex = 2;
            this.label2.Text = "k:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 21);
            this.label1.TabIndex = 2;
            this.label1.Text = "x0:";
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(443, 116);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(118, 27);
            this.btnCalcular.TabIndex = 1;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // modulo
            // 
            this.modulo.Location = new System.Drawing.Point(633, 54);
            this.modulo.Name = "modulo";
            this.modulo.PlaceholderText = "      m";
            this.modulo.Size = new System.Drawing.Size(100, 29);
            this.modulo.TabIndex = 0;
            this.modulo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.modulo_KeyDown);
            // 
            // constanteMultiplicativa
            // 
            this.constanteMultiplicativa.Location = new System.Drawing.Point(514, 54);
            this.constanteMultiplicativa.Name = "constanteMultiplicativa";
            this.constanteMultiplicativa.PlaceholderText = "      a";
            this.constanteMultiplicativa.Size = new System.Drawing.Size(100, 29);
            this.constanteMultiplicativa.TabIndex = 0;
            this.constanteMultiplicativa.KeyDown += new System.Windows.Forms.KeyEventHandler(this.constanteMultiplicativa_KeyDown);
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(337, 115);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 29);
            this.txtCantidad.TabIndex = 0;
            // 
            // constanteAditiva
            // 
            this.constanteAditiva.Location = new System.Drawing.Point(395, 54);
            this.constanteAditiva.Name = "constanteAditiva";
            this.constanteAditiva.PlaceholderText = "      c";
            this.constanteAditiva.Size = new System.Drawing.Size(100, 29);
            this.constanteAditiva.TabIndex = 0;
            // 
            // enteroG
            // 
            this.enteroG.Location = new System.Drawing.Point(276, 54);
            this.enteroG.Name = "enteroG";
            this.enteroG.PlaceholderText = "      g";
            this.enteroG.Size = new System.Drawing.Size(100, 29);
            this.enteroG.TabIndex = 0;
            this.enteroG.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enteroG_KeyDown);
            // 
            // enteroK
            // 
            this.enteroK.Location = new System.Drawing.Point(157, 54);
            this.enteroK.Name = "enteroK";
            this.enteroK.PlaceholderText = "      k";
            this.enteroK.Size = new System.Drawing.Size(100, 29);
            this.enteroK.TabIndex = 0;
            this.enteroK.KeyDown += new System.Windows.Forms.KeyEventHandler(this.enteroK_KeyDown);
            // 
            // semilla
            // 
            this.semilla.Location = new System.Drawing.Point(38, 54);
            this.semilla.Name = "semilla";
            this.semilla.PlaceholderText = "      x0";
            this.semilla.Size = new System.Drawing.Size(100, 29);
            this.semilla.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 71);
            this.panel1.TabIndex = 2;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(538, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generador de números pseudoaleatorios";
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.grdResultados);
            this.gbResultados.Controls.Add(this.btnCopiar);
            this.gbResultados.Controls.Add(this.btnMostrar);
            this.gbResultados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbResultados.Location = new System.Drawing.Point(12, 384);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(755, 442);
            this.gbResultados.TabIndex = 3;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "3. Resultados";
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.AllowUserToDeleteRows = false;
            this.grdResultados.AllowUserToResizeColumns = false;
            this.grdResultados.AllowUserToResizeRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(275, 31);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(229, 303);
            this.grdResultados.TabIndex = 0;
            // 
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(510, 74);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(118, 37);
            this.btnCopiar.TabIndex = 1;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(510, 31);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(118, 37);
            this.btnMostrar.TabIndex = 1;
            this.btnMostrar.Text = "Agregar fila";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // PantallaGeneradores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1381, 749);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbOpcion);
            this.Name = "PantallaGeneradores";
            this.Text = "Ejercicio 1 - Simulacion";
            this.Load += new System.EventHandler(this.Ejercicio1_Load);
            this.gbOpcion.ResumeLayout(false);
            this.gbOpcion.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbOpcion;
        private System.Windows.Forms.RadioButton rbMultiplicativo;
        private System.Windows.Forms.RadioButton rbLineal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.TextBox modulo;
        private System.Windows.Forms.TextBox constanteMultiplicativa;
        private System.Windows.Forms.TextBox constanteAditiva;
        private System.Windows.Forms.TextBox enteroG;
        private System.Windows.Forms.TextBox enteroK;
        private System.Windows.Forms.TextBox semilla;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox tabla;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Button btnCopiar;
    }
}

