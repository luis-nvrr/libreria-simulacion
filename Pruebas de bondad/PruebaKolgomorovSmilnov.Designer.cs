
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.btnPrueba = new System.Windows.Forms.Button();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.btnCopiarTabla1 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lblCalculado = new System.Windows.Forms.Label();
            this.txtCalculado = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.lblTitulo.BackColor = System.Drawing.Color.Transparent;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lblTitulo.Location = new System.Drawing.Point(40, 25);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(452, 41);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Prueba  De Kolgomorov-Smilnov";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1303, 100);
            this.panel1.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese el tamaño de la muestra: ";
            // 
            // tamanioMuestra
            // 
            this.tamanioMuestra.Location = new System.Drawing.Point(270, 22);
            this.tamanioMuestra.Name = "tamanioMuestra";
            this.tamanioMuestra.Size = new System.Drawing.Size(100, 29);
            this.tamanioMuestra.TabIndex = 4;
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(270, 98);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(98, 30);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(25, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese la cantidad de intervalos: ";
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResultados.DefaultCellStyle = dataGridViewCellStyle2;
            this.grdResultados.Location = new System.Drawing.Point(23, 279);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(229, 323);
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
            this.grdResultados2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdResultados2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResultados2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.grdResultados2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResultados2.DefaultCellStyle = dataGridViewCellStyle4;
            this.grdResultados2.Location = new System.Drawing.Point(271, 279);
            this.grdResultados2.Name = "grdResultados2";
            this.grdResultados2.RowHeadersVisible = false;
            this.grdResultados2.RowTemplate.Height = 25;
            this.grdResultados2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados2.Size = new System.Drawing.Size(1020, 323);
            this.grdResultados2.TabIndex = 10;
            // 
            // lblProbabilidad
            // 
            this.lblProbabilidad.AutoSize = true;
            this.lblProbabilidad.Location = new System.Drawing.Point(9, 30);
            this.lblProbabilidad.Name = "lblProbabilidad";
            this.lblProbabilidad.Size = new System.Drawing.Size(86, 21);
            this.lblProbabilidad.TabIndex = 15;
            this.lblProbabilidad.Text = "Estadistico:";
            // 
            // txtProbabilidad
            // 
            this.txtProbabilidad.Location = new System.Drawing.Point(100, 23);
            this.txtProbabilidad.Name = "txtProbabilidad";
            this.txtProbabilidad.Size = new System.Drawing.Size(100, 29);
            this.txtProbabilidad.TabIndex = 16;
            // 
            // txtGradosLibertad
            // 
            this.txtGradosLibertad.Location = new System.Drawing.Point(367, 23);
            this.txtGradosLibertad.Name = "txtGradosLibertad";
            this.txtGradosLibertad.Size = new System.Drawing.Size(107, 29);
            this.txtGradosLibertad.TabIndex = 17;
            // 
            // lblGradosLibertad
            // 
            this.lblGradosLibertad.AutoSize = true;
            this.lblGradosLibertad.Location = new System.Drawing.Point(219, 30);
            this.lblGradosLibertad.Name = "lblGradosLibertad";
            this.lblGradosLibertad.Size = new System.Drawing.Size(145, 21);
            this.lblGradosLibertad.TabIndex = 18;
            this.lblGradosLibertad.Text = "Grados de Libertad:";
            // 
            // lblResultadoHipotesis
            // 
            this.lblResultadoHipotesis.AutoSize = true;
            this.lblResultadoHipotesis.Location = new System.Drawing.Point(22, 108);
            this.lblResultadoHipotesis.Name = "lblResultadoHipotesis";
            this.lblResultadoHipotesis.Size = new System.Drawing.Size(150, 21);
            this.lblResultadoHipotesis.TabIndex = 19;
            this.lblResultadoHipotesis.Text = "Resultado Hipotesis:";
            // 
            // btnPrueba
            // 
            this.btnPrueba.Location = new System.Drawing.Point(509, 98);
            this.btnPrueba.Name = "btnPrueba";
            this.btnPrueba.Size = new System.Drawing.Size(98, 30);
            this.btnPrueba.TabIndex = 13;
            this.btnPrueba.Text = "Prueba";
            this.btnPrueba.UseVisualStyleBackColor = true;
            this.btnPrueba.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(386, 98);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(98, 30);
            this.btnMostrar.TabIndex = 12;
            this.btnMostrar.Text = "Grafico";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Location = new System.Drawing.Point(186, 101);
            this.rb20.Name = "rb20";
            this.rb20.Size = new System.Drawing.Size(46, 25);
            this.rb20.TabIndex = 11;
            this.rb20.TabStop = true;
            this.rb20.Text = "20";
            this.rb20.UseVisualStyleBackColor = true;
            // 
            // rb15
            // 
            this.rb15.AutoSize = true;
            this.rb15.Location = new System.Drawing.Point(134, 101);
            this.rb15.Name = "rb15";
            this.rb15.Size = new System.Drawing.Size(46, 25);
            this.rb15.TabIndex = 10;
            this.rb15.TabStop = true;
            this.rb15.Text = "15";
            this.rb15.UseVisualStyleBackColor = true;
            // 
            // rb10
            // 
            this.rb10.AutoSize = true;
            this.rb10.Location = new System.Drawing.Point(82, 101);
            this.rb10.Name = "rb10";
            this.rb10.Size = new System.Drawing.Size(46, 25);
            this.rb10.TabIndex = 9;
            this.rb10.TabStop = true;
            this.rb10.Text = "10";
            this.rb10.UseVisualStyleBackColor = true;
            // 
            // rb5
            // 
            this.rb5.AutoSize = true;
            this.rb5.Location = new System.Drawing.Point(39, 101);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(37, 25);
            this.rb5.TabIndex = 8;
            this.rb5.TabStop = true;
            this.rb5.Text = "5";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // btnCopiarTabla1
            // 
            this.btnCopiarTabla1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopiarTabla1.Location = new System.Drawing.Point(23, 610);
            this.btnCopiarTabla1.Name = "btnCopiarTabla1";
            this.btnCopiarTabla1.Size = new System.Drawing.Size(229, 50);
            this.btnCopiarTabla1.TabIndex = 21;
            this.btnCopiarTabla1.Text = "Copiar Números Aleatorios";
            this.btnCopiarTabla1.UseVisualStyleBackColor = true;
            this.btnCopiarTabla1.Click += new System.EventHandler(this.btnCopiar_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button1.Location = new System.Drawing.Point(271, 612);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(131, 48);
            this.button1.TabIndex = 22;
            this.button1.Text = "Copiar Prueba";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lblCalculado
            // 
            this.lblCalculado.AutoSize = true;
            this.lblCalculado.Location = new System.Drawing.Point(16, 66);
            this.lblCalculado.Name = "lblCalculado";
            this.lblCalculado.Size = new System.Drawing.Size(81, 21);
            this.lblCalculado.TabIndex = 23;
            this.lblCalculado.Text = "Calculado:";
            // 
            // txtCalculado
            // 
            this.txtCalculado.Location = new System.Drawing.Point(100, 66);
            this.txtCalculado.Name = "txtCalculado";
            this.txtCalculado.Size = new System.Drawing.Size(100, 29);
            this.txtCalculado.TabIndex = 24;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lblResultadoHipotesis);
            this.groupBox2.Controls.Add(this.txtCalculado);
            this.groupBox2.Controls.Add(this.lblCalculado);
            this.groupBox2.Controls.Add(this.txtGradosLibertad);
            this.groupBox2.Controls.Add(this.lblProbabilidad);
            this.groupBox2.Controls.Add(this.txtProbabilidad);
            this.groupBox2.Controls.Add(this.lblGradosLibertad);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(650, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(641, 154);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "2.Resultados";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnPrueba);
            this.groupBox3.Controls.Add(this.btnMostrar);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.rb20);
            this.groupBox3.Controls.Add(this.tamanioMuestra);
            this.groupBox3.Controls.Add(this.rb15);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.rb10);
            this.groupBox3.Controls.Add(this.btnGenerar);
            this.groupBox3.Controls.Add(this.rb5);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(12, 106);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(618, 154);
            this.groupBox3.TabIndex = 26;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "1. Datos";
            // 
            // PruebaKolgomorovSmilnov
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1303, 708);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCopiarTabla1);
            this.Controls.Add(this.grdResultados2);
            this.Controls.Add(this.grdResultados);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Name = "PruebaKolgomorovSmilnov";
            this.Text = "Simulacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PruebaKolgomorovSmilnov_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.RadioButton rb15;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Button btnCopiarTabla1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnPrueba;
        private System.Windows.Forms.Label lblCalculado;
        private System.Windows.Forms.TextBox txtCalculado;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}