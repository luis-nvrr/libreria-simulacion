
namespace Numeros_aleatorios.LibreriaSimulacion
{
    partial class PantallaVariablesAleatorias
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
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.rbUniforme = new System.Windows.Forms.RadioButton();
            this.gbDistribuciones = new System.Windows.Forms.GroupBox();
            this.rbPoisson = new System.Windows.Forms.RadioButton();
            this.rbNormal = new System.Windows.Forms.RadioButton();
            this.rbExponencial = new System.Windows.Forms.RadioButton();
            this.gbUniforme = new System.Windows.Forms.GroupBox();
            this.lblB = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.btnKolgomorov = new System.Windows.Forms.Button();
            this.btnJi = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCantidadIntervalos = new System.Windows.Forms.TextBox();
            this.txtCantidadValores = new System.Windows.Forms.TextBox();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblCantidadValores = new System.Windows.Forms.Label();
            this.gbGrafico = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbDistribuciones.SuspendLayout();
            this.gbUniforme.SuspendLayout();
            this.gbResultados.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(61, 52);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(223, 228);
            this.grdResultados.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1287, 71);
            this.panel1.TabIndex = 7;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(443, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Generador de variables aleatorias";
            // 
            // rbUniforme
            // 
            this.rbUniforme.AutoSize = true;
            this.rbUniforme.Location = new System.Drawing.Point(25, 41);
            this.rbUniforme.Name = "rbUniforme";
            this.rbUniforme.Size = new System.Drawing.Size(117, 25);
            this.rbUniforme.TabIndex = 8;
            this.rbUniforme.TabStop = true;
            this.rbUniforme.Text = "Uniforme AB";
            this.rbUniforme.UseVisualStyleBackColor = true;
            // 
            // gbDistribuciones
            // 
            this.gbDistribuciones.Controls.Add(this.rbPoisson);
            this.gbDistribuciones.Controls.Add(this.rbNormal);
            this.gbDistribuciones.Controls.Add(this.rbExponencial);
            this.gbDistribuciones.Controls.Add(this.rbUniforme);
            this.gbDistribuciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbDistribuciones.Location = new System.Drawing.Point(12, 104);
            this.gbDistribuciones.Name = "gbDistribuciones";
            this.gbDistribuciones.Size = new System.Drawing.Size(268, 156);
            this.gbDistribuciones.TabIndex = 9;
            this.gbDistribuciones.TabStop = false;
            this.gbDistribuciones.Text = "1. Seleccione una distribución";
            // 
            // rbPoisson
            // 
            this.rbPoisson.AutoSize = true;
            this.rbPoisson.Location = new System.Drawing.Point(25, 116);
            this.rbPoisson.Name = "rbPoisson";
            this.rbPoisson.Size = new System.Drawing.Size(81, 25);
            this.rbPoisson.TabIndex = 8;
            this.rbPoisson.TabStop = true;
            this.rbPoisson.Text = "Poisson";
            this.rbPoisson.UseVisualStyleBackColor = true;
            // 
            // rbNormal
            // 
            this.rbNormal.AutoSize = true;
            this.rbNormal.Location = new System.Drawing.Point(25, 91);
            this.rbNormal.Name = "rbNormal";
            this.rbNormal.Size = new System.Drawing.Size(170, 25);
            this.rbNormal.TabIndex = 8;
            this.rbNormal.TabStop = true;
            this.rbNormal.Text = "Normal No Estándar";
            this.rbNormal.UseVisualStyleBackColor = true;
            // 
            // rbExponencial
            // 
            this.rbExponencial.AutoSize = true;
            this.rbExponencial.Location = new System.Drawing.Point(25, 66);
            this.rbExponencial.Name = "rbExponencial";
            this.rbExponencial.Size = new System.Drawing.Size(176, 25);
            this.rbExponencial.TabIndex = 8;
            this.rbExponencial.TabStop = true;
            this.rbExponencial.Text = "Exponencial Negativa";
            this.rbExponencial.UseVisualStyleBackColor = true;
            // 
            // gbUniforme
            // 
            this.gbUniforme.Controls.Add(this.lblB);
            this.gbUniforme.Controls.Add(this.lblA);
            this.gbUniforme.Controls.Add(this.txtB);
            this.gbUniforme.Controls.Add(this.txtA);
            this.gbUniforme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbUniforme.Location = new System.Drawing.Point(298, 104);
            this.gbUniforme.Name = "gbUniforme";
            this.gbUniforme.Size = new System.Drawing.Size(235, 156);
            this.gbUniforme.TabIndex = 10;
            this.gbUniforme.TabStop = false;
            this.gbUniforme.Text = "2. Ingrese los parámetros";
            // 
            // lblB
            // 
            this.lblB.AutoSize = true;
            this.lblB.Location = new System.Drawing.Point(34, 78);
            this.lblB.Name = "lblB";
            this.lblB.Size = new System.Drawing.Size(22, 21);
            this.lblB.TabIndex = 0;
            this.lblB.Text = "B:";
            // 
            // lblA
            // 
            this.lblA.AutoSize = true;
            this.lblA.Location = new System.Drawing.Point(34, 43);
            this.lblA.Name = "lblA";
            this.lblA.Size = new System.Drawing.Size(23, 21);
            this.lblA.TabIndex = 0;
            this.lblA.Text = "A:";
            // 
            // txtB
            // 
            this.txtB.Location = new System.Drawing.Point(63, 72);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(100, 29);
            this.txtB.TabIndex = 6;
            // 
            // txtA
            // 
            this.txtA.Location = new System.Drawing.Point(63, 37);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(100, 29);
            this.txtA.TabIndex = 6;
            // 
            // gbResultados
            // 
            this.gbResultados.Controls.Add(this.btnKolgomorov);
            this.gbResultados.Controls.Add(this.btnJi);
            this.gbResultados.Controls.Add(this.btnMostrar);
            this.gbResultados.Controls.Add(this.grdResultados);
            this.gbResultados.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbResultados.Location = new System.Drawing.Point(12, 394);
            this.gbResultados.Name = "gbResultados";
            this.gbResultados.Size = new System.Drawing.Size(521, 343);
            this.gbResultados.TabIndex = 11;
            this.gbResultados.TabStop = false;
            this.gbResultados.Text = "4. Resultados";
            // 
            // btnKolgomorov
            // 
            this.btnKolgomorov.Location = new System.Drawing.Point(331, 126);
            this.btnKolgomorov.Name = "btnKolgomorov";
            this.btnKolgomorov.Size = new System.Drawing.Size(172, 31);
            this.btnKolgomorov.TabIndex = 6;
            this.btnKolgomorov.Text = "Kolgomorov-Smirnov";
            this.btnKolgomorov.UseVisualStyleBackColor = true;
            this.btnKolgomorov.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnJi
            // 
            this.btnJi.Location = new System.Drawing.Point(331, 89);
            this.btnJi.Name = "btnJi";
            this.btnJi.Size = new System.Drawing.Size(172, 31);
            this.btnJi.TabIndex = 6;
            this.btnJi.Text = "Prueba de Ji2";
            this.btnJi.UseVisualStyleBackColor = true;
            this.btnJi.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(331, 52);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(172, 31);
            this.btnMostrar.TabIndex = 6;
            this.btnMostrar.Text = "Mostrar Gráfico";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCantidadIntervalos);
            this.groupBox1.Controls.Add(this.txtCantidadValores);
            this.groupBox1.Controls.Add(this.btnCalcular);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCantidadValores);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 266);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(521, 122);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "3. Ingrese la cantidad";
            // 
            // txtCantidadIntervalos
            // 
            this.txtCantidadIntervalos.Location = new System.Drawing.Point(201, 69);
            this.txtCantidadIntervalos.Name = "txtCantidadIntervalos";
            this.txtCantidadIntervalos.Size = new System.Drawing.Size(100, 29);
            this.txtCantidadIntervalos.TabIndex = 13;
            // 
            // txtCantidadValores
            // 
            this.txtCantidadValores.Location = new System.Drawing.Point(201, 29);
            this.txtCantidadValores.Name = "txtCantidadValores";
            this.txtCantidadValores.Size = new System.Drawing.Size(100, 29);
            this.txtCantidadValores.TabIndex = 13;
            // 
            // btnCalcular
            // 
            this.btnCalcular.Location = new System.Drawing.Point(346, 67);
            this.btnCalcular.Name = "btnCalcular";
            this.btnCalcular.Size = new System.Drawing.Size(97, 31);
            this.btnCalcular.TabIndex = 5;
            this.btnCalcular.Text = "Calcular";
            this.btnCalcular.UseVisualStyleBackColor = true;
            this.btnCalcular.Click += new System.EventHandler(this.btnCalcular_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cantidad de intervalos:";
            // 
            // lblCantidadValores
            // 
            this.lblCantidadValores.AutoSize = true;
            this.lblCantidadValores.Location = new System.Drawing.Point(45, 37);
            this.lblCantidadValores.Name = "lblCantidadValores";
            this.lblCantidadValores.Size = new System.Drawing.Size(150, 21);
            this.lblCantidadValores.TabIndex = 0;
            this.lblCantidadValores.Text = "Cantidad de valores:";
            // 
            // gbGrafico
            // 
            this.gbGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbGrafico.Location = new System.Drawing.Point(553, 104);
            this.gbGrafico.Name = "gbGrafico";
            this.gbGrafico.Size = new System.Drawing.Size(708, 633);
            this.gbGrafico.TabIndex = 13;
            this.gbGrafico.TabStop = false;
            this.gbGrafico.Text = "5. Gráfico";
            // 
            // PantallaVariablesAleatorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1287, 749);
            this.Controls.Add(this.gbGrafico);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.gbUniforme);
            this.Controls.Add(this.gbDistribuciones);
            this.Controls.Add(this.panel1);
            this.Name = "PantallaVariablesAleatorias";
            this.Text = "PantallaPruebaGenerador";
            this.Load += new System.EventHandler(this.PantallaPruebaGenerador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDistribuciones.ResumeLayout(false);
            this.gbDistribuciones.PerformLayout();
            this.gbUniforme.ResumeLayout(false);
            this.gbUniforme.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.RadioButton rbUniforme;
        private System.Windows.Forms.GroupBox gbDistribuciones;
        private System.Windows.Forms.RadioButton rbPoisson;
        private System.Windows.Forms.RadioButton rbNormal;
        private System.Windows.Forms.RadioButton rbExponencial;
        private System.Windows.Forms.GroupBox gbUniforme;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblCantidadValores;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.TextBox txtCantidadIntervalos;
        private System.Windows.Forms.TextBox txtCantidadValores;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.GroupBox gbGrafico;
        private System.Windows.Forms.Button btnKolgomorov;
        private System.Windows.Forms.Button btnJi;
    }
}