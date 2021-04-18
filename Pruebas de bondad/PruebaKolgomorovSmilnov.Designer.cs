
namespace Numeros_aleatorios
{
    partial class PruebaKolgomorovSmilnov
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
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.tamanioMuestra = new System.Windows.Forms.TextBox();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.grdResultados2 = new System.Windows.Forms.DataGridView();
            this.lblProbabilidad = new System.Windows.Forms.Label();
            this.txtProbabilidad = new System.Windows.Forms.TextBox();
            this.txtGradosLibertad = new System.Windows.Forms.TextBox();
            this.lblGradosLibertad = new System.Windows.Forms.Label();
            this.lblResultadoHipotesis = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.btnCopiarTabla1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(236, -14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.BackColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(452, 41);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Prueba  De Kolgomorov-Smilnov";
            this.lblTitulo.Click += new System.EventHandler(this.label2_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1184, 100);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(0, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese el tamaño de la muestra: ";
            // 
            // tamanioMuestra
            // 
            this.tamanioMuestra.Location = new System.Drawing.Point(239, 19);
            this.tamanioMuestra.Name = "tamanioMuestra";
            this.tamanioMuestra.Size = new System.Drawing.Size(100, 23);
            this.tamanioMuestra.TabIndex = 4;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(311, 95);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(75, 23);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(-1, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese la cantidad de intervalos: ";
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(39, 279);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(175, 200);
            this.grdResultados.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "Intervalo";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "Frecuencia Observada";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "Frecuencia Esperada";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // Column1
            // 
            this.Column1.HeaderText = "PO";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "PE";
            this.Column2.Name = "Column2";
            // 
            // grdResultados2
            // 
            this.grdResultados2.AllowUserToAddRows = false;
            this.grdResultados2.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados2.Location = new System.Drawing.Point(220, 279);
            this.grdResultados2.Name = "grdResultados2";
            this.grdResultados2.RowHeadersVisible = false;
            this.grdResultados2.RowTemplate.Height = 25;
            this.grdResultados2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados2.Size = new System.Drawing.Size(1000, 234);
            this.grdResultados2.TabIndex = 10;
            // 
            // lblProbabilidad
            // 
            this.lblProbabilidad.AutoSize = true;
            this.lblProbabilidad.Location = new System.Drawing.Point(26, 539);
            this.lblProbabilidad.Name = "lblProbabilidad";
            this.lblProbabilidad.Size = new System.Drawing.Size(64, 15);
            this.lblProbabilidad.TabIndex = 15;
            this.lblProbabilidad.Text = "Probalidad";
            // 
            // txtProbabilidad
            // 
            this.txtProbabilidad.Location = new System.Drawing.Point(96, 536);
            this.txtProbabilidad.Name = "txtProbabilidad";
            this.txtProbabilidad.Size = new System.Drawing.Size(53, 23);
            this.txtProbabilidad.TabIndex = 16;
            // 
            // txtGradosLibertad
            // 
            this.txtGradosLibertad.Location = new System.Drawing.Point(290, 536);
            this.txtGradosLibertad.Name = "txtGradosLibertad";
            this.txtGradosLibertad.Size = new System.Drawing.Size(53, 23);
            this.txtGradosLibertad.TabIndex = 17;
            // 
            // lblGradosLibertad
            // 
            this.lblGradosLibertad.AutoSize = true;
            this.lblGradosLibertad.Location = new System.Drawing.Point(178, 539);
            this.lblGradosLibertad.Name = "lblGradosLibertad";
            this.lblGradosLibertad.Size = new System.Drawing.Size(106, 15);
            this.lblGradosLibertad.TabIndex = 18;
            this.lblGradosLibertad.Text = "Grados de Libertad";
            // 
            // lblResultadoHipotesis
            // 
            this.lblResultadoHipotesis.AutoSize = true;
            this.lblResultadoHipotesis.Location = new System.Drawing.Point(373, 539);
            this.lblResultadoHipotesis.Name = "lblResultadoHipotesis";
            this.lblResultadoHipotesis.Size = new System.Drawing.Size(111, 15);
            this.lblResultadoHipotesis.TabIndex = 19;
            this.lblResultadoHipotesis.Text = "Resultado Hipotesis";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnMostrar);
            this.groupBox1.Controls.Add(this.rb20);
            this.groupBox1.Controls.Add(this.rb15);
            this.groupBox1.Controls.Add(this.rb10);
            this.groupBox1.Controls.Add(this.rb5);
            this.groupBox1.Controls.Add(this.btnGenerar);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.tamanioMuestra);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(40, 106);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(386, 152);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(311, 129);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 12;
            this.btnMostrar.Text = "Grafico";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Location = new System.Drawing.Point(138, 122);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(37, 19);
            this.rb20.TabIndex = 11;
            this.rb20.TabStop = true;
            this.rb20.Text = "20";
            this.rb20.UseVisualStyleBackColor = true;
            // 
            // rb15
            // 
            this.rb15.AutoSize = true;
            this.rb15.Location = new System.Drawing.Point(69, 122);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(37, 19);
            this.rb15.TabIndex = 10;
            this.rb15.TabStop = true;
            this.rb15.Text = "15";
            this.rb15.UseVisualStyleBackColor = true;
            // 
            // rb10
            // 
            this.rb10.AutoSize = true;
            this.rb10.Location = new System.Drawing.Point(138, 97);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(37, 19);
            this.rb10.TabIndex = 9;
            this.rb10.TabStop = true;
            this.rb10.Text = "10";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(69, 97);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(31, 19);
            this.rb5.TabIndex = 8;
            this.rb5.TabStop = true;
            this.rb5.Text = "5";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // btnCopiarTabla1
            // 
            this.btnCopiarTabla1.Location = new System.Drawing.Point(39, 485);
            this.btnCopiarTabla1.Name = "btnCopiarTabla1";
            this.btnCopiarTabla1.Size = new System.Drawing.Size(175, 31);
            this.btnCopiarTabla1.TabIndex = 21;
            this.btnCopiarTabla1.Text = "Copiar Números Aleatorios";
            this.btnCopiarTabla1.UseVisualStyleBackColor = true;
            this.btnCopiarTabla1.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(815, 519);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 31);
            this.button1.TabIndex = 22;
            this.button1.Text = "Copiar Prueba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // PruebaKolgomorovSmilnov
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 571);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopiarTabla1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lblResultadoHipotesis);
            this.Controls.Add(this.lblGradosLibertad);
            this.Controls.Add(this.txtGradosLibertad);
            this.Controls.Add(this.txtProbabilidad);
            this.Controls.Add(this.lblProbabilidad);
            this.Controls.Add(this.grdResultados2);
            this.Controls.Add(this.grdResultados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "PruebaKolgomorovSmilnov";
            this.Text = "PruebaKolgomorovSmilnov";
            this.Load += new System.EventHandler(this.PruebaKolgomorovSmilnov_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tamanioMuestra;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridView grdResultados2;
        private System.Windows.Forms.TextBox cantIntervalo;
        private System.Windows.Forms.Label lblProbabilidad;
        private System.Windows.Forms.TextBox txtProbabilidad;
        private System.Windows.Forms.TextBox txtGradosLibertad;
        private System.Windows.Forms.Label lblGradosLibertad;
        private System.Windows.Forms.Label lblResultadoHipotesis;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.RadioButton rb15;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Button btnCopiarTabla1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMostrar;
    }
}