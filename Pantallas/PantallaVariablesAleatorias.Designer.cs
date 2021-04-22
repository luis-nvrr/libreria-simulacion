﻿
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
            this.rbNormalConvolucion = new System.Windows.Forms.RadioButton();
            this.rbNormalBoxMuller = new System.Windows.Forms.RadioButton();
            this.rbExponencial = new System.Windows.Forms.RadioButton();
            this.gbUniforme = new System.Windows.Forms.GroupBox();
            this.lblB = new System.Windows.Forms.Label();
            this.lblA = new System.Windows.Forms.Label();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.gbResultados = new System.Windows.Forms.GroupBox();
            this.btnCopiar = new System.Windows.Forms.Button();
            this.btnJi = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.gbCantidades = new System.Windows.Forms.GroupBox();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.txtCantidadValores = new System.Windows.Forms.TextBox();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.btnCalcular = new System.Windows.Forms.Button();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.lblCantidadValores = new System.Windows.Forms.Label();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.gbGrafico = new System.Windows.Forms.GroupBox();
            this.gbExponencial = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMediaExponencial = new System.Windows.Forms.TextBox();
            this.txtLambdaExponencial = new System.Windows.Forms.TextBox();
            this.gbNormalBoxMuller = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMediaNormalBoxMuller = new System.Windows.Forms.TextBox();
            this.txtDesviacionNormalBoxMuller = new System.Windows.Forms.TextBox();
            this.gbNormalConvolucion = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtMediaNormalConvolucion = new System.Windows.Forms.TextBox();
            this.txtDesviacionNormalConvolucion = new System.Windows.Forms.TextBox();
            this.gbPoisson = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtMediaPoisson = new System.Windows.Forms.TextBox();
            this.txtLambdaPoisson = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.panel1.SuspendLayout();
            this.gbDistribuciones.SuspendLayout();
            this.gbUniforme.SuspendLayout();
            this.gbResultados.SuspendLayout();
            this.gbCantidades.SuspendLayout();
            this.gbExponencial.SuspendLayout();
            this.gbNormalBoxMuller.SuspendLayout();
            this.gbNormalConvolucion.SuspendLayout();
            this.gbPoisson.SuspendLayout();
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
            this.grdResultados.Size = new System.Drawing.Size(235, 250);
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
            this.rbUniforme.Location = new System.Drawing.Point(25, 28);
            this.rbUniforme.Name = "rbUniforme";
            this.rbUniforme.Size = new System.Drawing.Size(117, 25);
            this.rbUniforme.TabIndex = 8;
            this.rbUniforme.TabStop = true;
            this.rbUniforme.Text = "Uniforme AB";
            this.rbUniforme.UseVisualStyleBackColor = true;
            this.rbUniforme.CheckedChanged += new System.EventHandler(this.rbUniforme_CheckedChanged);
            // 
            // gbDistribuciones
            // 
            this.gbDistribuciones.Controls.Add(this.rbPoisson);
            this.gbDistribuciones.Controls.Add(this.rbNormalConvolucion);
            this.gbDistribuciones.Controls.Add(this.rbNormalBoxMuller);
            this.gbDistribuciones.Controls.Add(this.rbExponencial);
            this.gbDistribuciones.Controls.Add(this.rbUniforme);
            this.gbDistribuciones.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbDistribuciones.Location = new System.Drawing.Point(12, 89);
            this.gbDistribuciones.Name = "gbDistribuciones";
            this.gbDistribuciones.Size = new System.Drawing.Size(268, 171);
            this.gbDistribuciones.TabIndex = 9;
            this.gbDistribuciones.TabStop = false;
            this.gbDistribuciones.Text = "1. Seleccione una distribución";
            // 
            // rbPoisson
            // 
            this.rbPoisson.AutoSize = true;
            this.rbPoisson.Location = new System.Drawing.Point(25, 136);
            this.rbPoisson.Name = "rbPoisson";
            this.rbPoisson.Size = new System.Drawing.Size(81, 25);
            this.rbPoisson.TabIndex = 8;
            this.rbPoisson.TabStop = true;
            this.rbPoisson.Text = "Poisson";
            this.rbPoisson.UseVisualStyleBackColor = true;
            this.rbPoisson.CheckedChanged += new System.EventHandler(this.rbPoisson_CheckedChanged);
            // 
            // rbNormalConvolucion
            // 
            this.rbNormalConvolucion.AutoSize = true;
            this.rbNormalConvolucion.Location = new System.Drawing.Point(25, 109);
            this.rbNormalConvolucion.Name = "rbNormalConvolucion";
            this.rbNormalConvolucion.Size = new System.Drawing.Size(200, 25);
            this.rbNormalConvolucion.TabIndex = 8;
            this.rbNormalConvolucion.TabStop = true;
            this.rbNormalConvolucion.Text = "Normal por Convolucion";
            this.rbNormalConvolucion.UseVisualStyleBackColor = true;
            this.rbNormalConvolucion.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbNormalBoxMuller
            // 
            this.rbNormalBoxMuller.AutoSize = true;
            this.rbNormalBoxMuller.Location = new System.Drawing.Point(25, 82);
            this.rbNormalBoxMuller.Name = "rbNormalBoxMuller";
            this.rbNormalBoxMuller.Size = new System.Drawing.Size(187, 25);
            this.rbNormalBoxMuller.TabIndex = 8;
            this.rbNormalBoxMuller.TabStop = true;
            this.rbNormalBoxMuller.Text = "Normal por Box Muller";
            this.rbNormalBoxMuller.UseVisualStyleBackColor = true;
            this.rbNormalBoxMuller.CheckedChanged += new System.EventHandler(this.rbNormal_CheckedChanged);
            // 
            // rbExponencial
            // 
            this.rbExponencial.AutoSize = true;
            this.rbExponencial.Location = new System.Drawing.Point(25, 55);
            this.rbExponencial.Name = "rbExponencial";
            this.rbExponencial.Size = new System.Drawing.Size(176, 25);
            this.rbExponencial.TabIndex = 8;
            this.rbExponencial.TabStop = true;
            this.rbExponencial.Text = "Exponencial Negativa";
            this.rbExponencial.UseVisualStyleBackColor = true;
            this.rbExponencial.CheckedChanged += new System.EventHandler(this.rbExponencial_CheckedChanged);
            // 
            // gbUniforme
            // 
            this.gbUniforme.Controls.Add(this.lblB);
            this.gbUniforme.Controls.Add(this.lblA);
            this.gbUniforme.Controls.Add(this.txtB);
            this.gbUniforme.Controls.Add(this.txtA);
            this.gbUniforme.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbUniforme.Location = new System.Drawing.Point(298, 89);
            this.gbUniforme.Name = "gbUniforme";
            this.gbUniforme.Size = new System.Drawing.Size(235, 171);
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
            this.gbResultados.Controls.Add(this.btnCopiar);
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
            // btnCopiar
            // 
            this.btnCopiar.Location = new System.Drawing.Point(331, 126);
            this.btnCopiar.Name = "btnCopiar";
            this.btnCopiar.Size = new System.Drawing.Size(172, 31);
            this.btnCopiar.TabIndex = 7;
            this.btnCopiar.Text = "Copiar";
            this.btnCopiar.UseVisualStyleBackColor = true;
            this.btnCopiar.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // btnJi
            // 
            this.btnJi.Location = new System.Drawing.Point(331, 89);
            this.btnJi.Name = "btnJi";
            this.btnJi.Size = new System.Drawing.Size(172, 31);
            this.btnJi.TabIndex = 6;
            this.btnJi.Text = "Prueba de Ji2";
            this.btnJi.UseVisualStyleBackColor = true;
            this.btnJi.Click += new System.EventHandler(this.btnJi_Click);
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
            // gbCantidades
            // 
            this.gbCantidades.Controls.Add(this.rb20);
            this.gbCantidades.Controls.Add(this.txtCantidadValores);
            this.gbCantidades.Controls.Add(this.rb15);
            this.gbCantidades.Controls.Add(this.btnCalcular);
            this.gbCantidades.Controls.Add(this.rb10);
            this.gbCantidades.Controls.Add(this.lblCantidadValores);
            this.gbCantidades.Controls.Add(this.rb5);
            this.gbCantidades.Controls.Add(this.label1);
            this.gbCantidades.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbCantidades.Location = new System.Drawing.Point(12, 266);
            this.gbCantidades.Name = "gbCantidades";
            this.gbCantidades.Size = new System.Drawing.Size(521, 132);
            this.gbCantidades.TabIndex = 12;
            this.gbCantidades.TabStop = false;
            this.gbCantidades.Text = "3. Ingrese la cantidad";
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Location = new System.Drawing.Point(200, 101);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(46, 25);
            this.rb20.TabIndex = 21;
            this.rb20.TabStop = true;
            this.rb20.Text = "20";
            this.rb20.UseVisualStyleBackColor = true;
            // 
            // txtCantidadValores
            // 
            this.txtCantidadValores.Location = new System.Drawing.Point(164, 32);
            this.txtCantidadValores.Name = "txtCantidadValores";
            this.txtCantidadValores.Size = new System.Drawing.Size(100, 29);
            this.txtCantidadValores.TabIndex = 13;
            // 
            // rb15
            // 
            this.rb15.AutoSize = true;
            this.rb15.Location = new System.Drawing.Point(138, 101);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(46, 25);
            this.rb15.TabIndex = 20;
            this.rb15.TabStop = true;
            this.rb15.Text = "15";
            this.rb15.UseVisualStyleBackColor = true;
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
            // rb10
            // 
            this.rb10.AutoSize = true;
            this.rb10.Location = new System.Drawing.Point(79, 101);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(46, 25);
            this.rb10.TabIndex = 19;
            this.rb10.TabStop = true;
            this.rb10.Text = "10";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // lblCantidadValores
            // 
            this.lblCantidadValores.AutoSize = true;
            this.lblCantidadValores.Location = new System.Drawing.Point(8, 40);
            this.lblCantidadValores.Name = "lblCantidadValores";
            this.lblCantidadValores.Size = new System.Drawing.Size(150, 21);
            this.lblCantidadValores.TabIndex = 0;
            this.lblCantidadValores.Text = "Cantidad de valores:";
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(25, 101);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(37, 25);
            this.rb5.TabIndex = 18;
            this.rb5.TabStop = true;
            this.rb5.Text = "5";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 77);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(240, 21);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ingrese la cantidad de intervalos: ";
            // 
            // gbGrafico
            // 
            this.gbGrafico.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbGrafico.Location = new System.Drawing.Point(553, 89);
            this.gbGrafico.Name = "gbGrafico";
            this.gbGrafico.Size = new System.Drawing.Size(708, 648);
            this.gbGrafico.TabIndex = 13;
            this.gbGrafico.TabStop = false;
            this.gbGrafico.Text = "5. Gráfico";
            // 
            // gbExponencial
            // 
            this.gbExponencial.Controls.Add(this.label3);
            this.gbExponencial.Controls.Add(this.label2);
            this.gbExponencial.Controls.Add(this.txtMediaExponencial);
            this.gbExponencial.Controls.Add(this.txtLambdaExponencial);
            this.gbExponencial.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbExponencial.Location = new System.Drawing.Point(298, 89);
            this.gbExponencial.Name = "gbExponencial";
            this.gbExponencial.Size = new System.Drawing.Size(235, 171);
            this.gbExponencial.TabIndex = 0;
            this.gbExponencial.TabStop = false;
            this.gbExponencial.Text = "2. Ingrese los parámetros:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(38, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "Media:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 21);
            this.label2.TabIndex = 0;
            this.label2.Text = "Lambda:";
            // 
            // txtMediaExponencial
            // 
            this.txtMediaExponencial.Location = new System.Drawing.Point(100, 75);
            this.txtMediaExponencial.Name = "txtMediaExponencial";
            this.txtMediaExponencial.Size = new System.Drawing.Size(100, 29);
            this.txtMediaExponencial.TabIndex = 13;
            // 
            // txtLambdaExponencial
            // 
            this.txtLambdaExponencial.Location = new System.Drawing.Point(100, 35);
            this.txtLambdaExponencial.Name = "txtLambdaExponencial";
            this.txtLambdaExponencial.Size = new System.Drawing.Size(100, 29);
            this.txtLambdaExponencial.TabIndex = 13;
            // 
            // gbNormalBoxMuller
            // 
            this.gbNormalBoxMuller.Controls.Add(this.label4);
            this.gbNormalBoxMuller.Controls.Add(this.label5);
            this.gbNormalBoxMuller.Controls.Add(this.txtMediaNormalBoxMuller);
            this.gbNormalBoxMuller.Controls.Add(this.txtDesviacionNormalBoxMuller);
            this.gbNormalBoxMuller.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbNormalBoxMuller.Location = new System.Drawing.Point(298, 89);
            this.gbNormalBoxMuller.Name = "gbNormalBoxMuller";
            this.gbNormalBoxMuller.Size = new System.Drawing.Size(235, 171);
            this.gbNormalBoxMuller.TabIndex = 14;
            this.gbNormalBoxMuller.TabStop = false;
            this.gbNormalBoxMuller.Text = "2. Ingrese los parámetros:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(55, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 21);
            this.label4.TabIndex = 0;
            this.label4.Text = "Media:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 50);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 21);
            this.label5.TabIndex = 0;
            this.label5.Text = "Desviación:";
            // 
            // txtMediaNormalBoxMuller
            // 
            this.txtMediaNormalBoxMuller.Location = new System.Drawing.Point(117, 82);
            this.txtMediaNormalBoxMuller.Name = "txtMediaNormalBoxMuller";
            this.txtMediaNormalBoxMuller.Size = new System.Drawing.Size(100, 29);
            this.txtMediaNormalBoxMuller.TabIndex = 13;
            // 
            // txtDesviacionNormalBoxMuller
            // 
            this.txtDesviacionNormalBoxMuller.Location = new System.Drawing.Point(117, 43);
            this.txtDesviacionNormalBoxMuller.Name = "txtDesviacionNormalBoxMuller";
            this.txtDesviacionNormalBoxMuller.Size = new System.Drawing.Size(100, 29);
            this.txtDesviacionNormalBoxMuller.TabIndex = 13;
            // 
            // gbNormalConvolucion
            // 
            this.gbNormalConvolucion.Controls.Add(this.label6);
            this.gbNormalConvolucion.Controls.Add(this.label7);
            this.gbNormalConvolucion.Controls.Add(this.txtMediaNormalConvolucion);
            this.gbNormalConvolucion.Controls.Add(this.txtDesviacionNormalConvolucion);
            this.gbNormalConvolucion.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbNormalConvolucion.Location = new System.Drawing.Point(298, 89);
            this.gbNormalConvolucion.Name = "gbNormalConvolucion";
            this.gbNormalConvolucion.Size = new System.Drawing.Size(235, 171);
            this.gbNormalConvolucion.TabIndex = 15;
            this.gbNormalConvolucion.TabStop = false;
            this.gbNormalConvolucion.Text = "2. Ingrese los parámetros:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(55, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 21);
            this.label6.TabIndex = 0;
            this.label6.Text = "Media:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(16, 50);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 21);
            this.label7.TabIndex = 0;
            this.label7.Text = "Desviación:";
            // 
            // txtMediaNormalConvolucion
            // 
            this.txtMediaNormalConvolucion.Location = new System.Drawing.Point(117, 82);
            this.txtMediaNormalConvolucion.Name = "txtMediaNormalConvolucion";
            this.txtMediaNormalConvolucion.Size = new System.Drawing.Size(100, 29);
            this.txtMediaNormalConvolucion.TabIndex = 13;
            // 
            // txtDesviacionNormalConvolucion
            // 
            this.txtDesviacionNormalConvolucion.Location = new System.Drawing.Point(117, 43);
            this.txtDesviacionNormalConvolucion.Name = "txtDesviacionNormalConvolucion";
            this.txtDesviacionNormalConvolucion.Size = new System.Drawing.Size(100, 29);
            this.txtDesviacionNormalConvolucion.TabIndex = 13;
            // 
            // gbPoisson
            // 
            this.gbPoisson.Controls.Add(this.label8);
            this.gbPoisson.Controls.Add(this.label9);
            this.gbPoisson.Controls.Add(this.txtMediaPoisson);
            this.gbPoisson.Controls.Add(this.txtLambdaPoisson);
            this.gbPoisson.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.gbPoisson.Location = new System.Drawing.Point(298, 89);
            this.gbPoisson.Name = "gbPoisson";
            this.gbPoisson.Size = new System.Drawing.Size(235, 171);
            this.gbPoisson.TabIndex = 16;
            this.gbPoisson.TabStop = false;
            this.gbPoisson.Text = "2. Ingrese los parámetros:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(55, 90);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 21);
            this.label8.TabIndex = 0;
            this.label8.Text = "Media:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(42, 48);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 21);
            this.label9.TabIndex = 0;
            this.label9.Text = "Lambda:";
            // 
            // txtMediaPoisson
            // 
            this.txtMediaPoisson.Location = new System.Drawing.Point(117, 82);
            this.txtMediaPoisson.Name = "txtMediaPoisson";
            this.txtMediaPoisson.Size = new System.Drawing.Size(100, 29);
            this.txtMediaPoisson.TabIndex = 13;
            // 
            // txtLambdaPoisson
            // 
            this.txtLambdaPoisson.Location = new System.Drawing.Point(117, 43);
            this.txtLambdaPoisson.Name = "txtLambdaPoisson";
            this.txtLambdaPoisson.Size = new System.Drawing.Size(100, 29);
            this.txtLambdaPoisson.TabIndex = 13;
            // 
            // PantallaVariablesAleatorias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1287, 749);
            this.Controls.Add(this.gbPoisson);
            this.Controls.Add(this.gbNormalConvolucion);
            this.Controls.Add(this.gbNormalBoxMuller);
            this.Controls.Add(this.gbExponencial);
            this.Controls.Add(this.gbGrafico);
            this.Controls.Add(this.gbCantidades);
            this.Controls.Add(this.gbResultados);
            this.Controls.Add(this.gbUniforme);
            this.Controls.Add(this.gbDistribuciones);
            this.Controls.Add(this.panel1);
            this.Name = "PantallaVariablesAleatorias";
            this.Text = "PantallaPruebaGenerador";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PantallaPruebaGenerador_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.gbDistribuciones.ResumeLayout(false);
            this.gbDistribuciones.PerformLayout();
            this.gbUniforme.ResumeLayout(false);
            this.gbUniforme.PerformLayout();
            this.gbResultados.ResumeLayout(false);
            this.gbCantidades.ResumeLayout(false);
            this.gbCantidades.PerformLayout();
            this.gbExponencial.ResumeLayout(false);
            this.gbExponencial.PerformLayout();
            this.gbNormalBoxMuller.ResumeLayout(false);
            this.gbNormalBoxMuller.PerformLayout();
            this.gbNormalConvolucion.ResumeLayout(false);
            this.gbNormalConvolucion.PerformLayout();
            this.gbPoisson.ResumeLayout(false);
            this.gbPoisson.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.RadioButton rbUniforme;
        private System.Windows.Forms.GroupBox gbDistribuciones;
        private System.Windows.Forms.RadioButton rbPoisson;
        private System.Windows.Forms.RadioButton rbNormalBoxMuller;
        private System.Windows.Forms.RadioButton rbExponencial;
        private System.Windows.Forms.GroupBox gbUniforme;
        private System.Windows.Forms.GroupBox gbResultados;
        private System.Windows.Forms.TextBox txtA;
        private System.Windows.Forms.GroupBox gbCantidades;
        private System.Windows.Forms.Label lblA;
        private System.Windows.Forms.Label lblCantidadValores;
        private System.Windows.Forms.Label lblB;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.TextBox txtCantidadValores;
        private System.Windows.Forms.Button btnCalcular;
        private System.Windows.Forms.GroupBox gbGrafico;
        private System.Windows.Forms.Button btnJi;
        private System.Windows.Forms.GroupBox gbExponencial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMediaExponencial;
        private System.Windows.Forms.TextBox txtLambdaExponencial;
        private System.Windows.Forms.GroupBox gbNormalBoxMuller;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtMediaNormalBoxMuller;
        private System.Windows.Forms.TextBox txtDesviacionNormalBoxMuller;
        private System.Windows.Forms.RadioButton rbNormalConvolucion;
        private System.Windows.Forms.GroupBox gbNormalConvolucion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtMediaNormalConvolucion;
        private System.Windows.Forms.TextBox txtDesviacionNormalConvolucion;
        private System.Windows.Forms.GroupBox gbPoisson;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtMediaPoisson;
        private System.Windows.Forms.TextBox txtLambdaPoisson;
        private System.Windows.Forms.Button btnCopiar;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.RadioButton rb15;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Label label1;
    }
}