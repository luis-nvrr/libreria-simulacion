
namespace Numeros_aleatorios.Pruebas_de_bondad
{
    partial class PruebaChi2
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.grdResultados2 = new System.Windows.Forms.DataGridView();
            this.lblResultadoHipotesis = new System.Windows.Forms.Label();
            this.txtGradosLibertad = new System.Windows.Forms.TextBox();
            this.txtProbabilidad = new System.Windows.Forms.TextBox();
            this.lblGradosLibertad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.rb20 = new System.Windows.Forms.RadioButton();
            this.rb15 = new System.Windows.Forms.RadioButton();
            this.rb10 = new System.Windows.Forms.RadioButton();
            this.rb5 = new System.Windows.Forms.RadioButton();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnProbar = new System.Windows.Forms.Button();
            this.btnGenerar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tamanioMuestra = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.copiarPrueba = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCopiarTabla1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResultados.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResultados.DefaultCellStyle = dataGridViewCellStyle7;
            this.grdResultados.Location = new System.Drawing.Point(19, 263);
            this.grdResultados.Margin = new System.Windows.Forms.Padding(4);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(240, 310);
            this.grdResultados.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1071, 81);
            this.panel1.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(15, 18);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(314, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Prueba de Ji-Cuadrada ";
            // 
            // grdResultados2
            // 
            this.grdResultados2.AllowUserToAddRows = false;
            this.grdResultados2.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdResultados2.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResultados2.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle8;
            this.grdResultados2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.grdResultados2.DefaultCellStyle = dataGridViewCellStyle9;
            this.grdResultados2.Location = new System.Drawing.Point(367, 263);
            this.grdResultados2.Margin = new System.Windows.Forms.Padding(4);
            this.grdResultados2.Name = "grdResultados2";
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.grdResultados2.RowHeadersDefaultCellStyle = dataGridViewCellStyle10;
            this.grdResultados2.RowHeadersVisible = false;
            this.grdResultados2.RowTemplate.Height = 25;
            this.grdResultados2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados2.Size = new System.Drawing.Size(658, 310);
            this.grdResultados2.TabIndex = 9;
            // 
            // lblResultadoHipotesis
            // 
            this.lblResultadoHipotesis.AutoSize = true;
            this.lblResultadoHipotesis.Location = new System.Drawing.Point(21, 107);
            this.lblResultadoHipotesis.Name = "lblResultadoHipotesis";
            this.lblResultadoHipotesis.Size = new System.Drawing.Size(0, 21);
            this.lblResultadoHipotesis.TabIndex = 10;
            // 
            // txtGradosLibertad
            // 
            this.txtGradosLibertad.Location = new System.Drawing.Point(172, 18);
            this.txtGradosLibertad.Name = "txtGradosLibertad";
            this.txtGradosLibertad.Size = new System.Drawing.Size(108, 29);
            this.txtGradosLibertad.TabIndex = 11;
            // 
            // txtProbabilidad
            // 
            this.txtProbabilidad.Location = new System.Drawing.Point(172, 65);
            this.txtProbabilidad.Name = "txtProbabilidad";
            this.txtProbabilidad.Size = new System.Drawing.Size(108, 29);
            this.txtProbabilidad.TabIndex = 12;
            // 
            // lblGradosLibertad
            // 
            this.lblGradosLibertad.AutoSize = true;
            this.lblGradosLibertad.Location = new System.Drawing.Point(21, 26);
            this.lblGradosLibertad.Name = "lblGradosLibertad";
            this.lblGradosLibertad.Size = new System.Drawing.Size(141, 21);
            this.lblGradosLibertad.TabIndex = 13;
            this.lblGradosLibertad.Text = "Grados de libertad:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(160, 21);
            this.label1.TabIndex = 14;
            this.label1.Text = "Estadistico de prueba:";
            // 
            // rb20
            // 
            this.rb20.AutoSize = true;
            this.rb20.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb20.Location = new System.Drawing.Point(218, 105);
            this.rb20.Margin = new System.Windows.Forms.Padding(4);
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
            this.rb15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb15.Location = new System.Drawing.Point(158, 105);
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
            this.rb10.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb10.Location = new System.Drawing.Point(98, 105);
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
            this.rb5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.rb5.Location = new System.Drawing.Point(47, 105);
            this.rb5.Name = "rb5";
            this.rb5.Size = new System.Drawing.Size(37, 25);
            this.rb5.TabIndex = 8;
            this.rb5.TabStop = true;
            this.rb5.Text = "5";
            this.rb5.UseVisualStyleBackColor = true;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(393, 95);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(92, 35);
            this.btnMostrar.TabIndex = 6;
            this.btnMostrar.Text = "Grafico";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // btnProbar
            // 
            this.btnProbar.Location = new System.Drawing.Point(491, 95);
            this.btnProbar.Name = "btnProbar";
            this.btnProbar.Size = new System.Drawing.Size(92, 35);
            this.btnProbar.TabIndex = 6;
            this.btnProbar.Text = "Prueba";
            this.btnProbar.UseVisualStyleBackColor = true;
            this.btnProbar.Click += new System.EventHandler(this.btnProbar_Click);
            // 
            // btnGenerar
            // 
            this.btnGenerar.Location = new System.Drawing.Point(295, 95);
            this.btnGenerar.Name = "btnGenerar";
            this.btnGenerar.Size = new System.Drawing.Size(92, 35);
            this.btnGenerar.TabIndex = 6;
            this.btnGenerar.Text = "Generar";
            this.btnGenerar.UseVisualStyleBackColor = true;
            this.btnGenerar.Click += new System.EventHandler(this.btnGenerar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(25, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(239, 21);
            this.label2.TabIndex = 3;
            this.label2.Text = "Ingrese el tamaño de la muestra: ";
            // 
            // tamanioMuestra
            // 
            this.tamanioMuestra.Location = new System.Drawing.Point(317, 27);
            this.tamanioMuestra.Margin = new System.Windows.Forms.Padding(4);
            this.tamanioMuestra.Name = "tamanioMuestra";
            this.tamanioMuestra.Size = new System.Drawing.Size(127, 29);
            this.tamanioMuestra.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(24, 63);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(240, 21);
            this.label4.TabIndex = 7;
            this.label4.Text = "Ingrese la cantidad de intervalos: ";
            // 
            // copiarPrueba
            // 
            this.copiarPrueba.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.copiarPrueba.Location = new System.Drawing.Point(367, 581);
            this.copiarPrueba.Margin = new System.Windows.Forms.Padding(4);
            this.copiarPrueba.Name = "copiarPrueba";
            this.copiarPrueba.Size = new System.Drawing.Size(133, 40);
            this.copiarPrueba.TabIndex = 23;
            this.copiarPrueba.Text = "Copiar Prueba";
            this.copiarPrueba.UseVisualStyleBackColor = true;
            this.copiarPrueba.Click += new System.EventHandler(this.copiarPrueba_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rb20);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.rb15);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.rb10);
            this.groupBox2.Controls.Add(this.tamanioMuestra);
            this.groupBox2.Controls.Add(this.rb5);
            this.groupBox2.Controls.Add(this.btnGenerar);
            this.groupBox2.Controls.Add(this.btnMostrar);
            this.groupBox2.Controls.Add(this.btnProbar);
            this.groupBox2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox2.Location = new System.Drawing.Point(19, 98);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(599, 145);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "1.Datos";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtGradosLibertad);
            this.groupBox1.Controls.Add(this.lblResultadoHipotesis);
            this.groupBox1.Controls.Add(this.txtProbabilidad);
            this.groupBox1.Controls.Add(this.lblGradosLibertad);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(635, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 145);
            this.groupBox1.TabIndex = 25;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "2.Resultados";
            // 
            // btnCopiarTabla1
            // 
            this.btnCopiarTabla1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCopiarTabla1.Location = new System.Drawing.Point(19, 581);
            this.btnCopiarTabla1.Margin = new System.Windows.Forms.Padding(4);
            this.btnCopiarTabla1.Name = "btnCopiarTabla1";
            this.btnCopiarTabla1.Size = new System.Drawing.Size(240, 40);
            this.btnCopiarTabla1.TabIndex = 26;
            this.btnCopiarTabla1.Text = "Copiar Números Aleatorios";
            this.btnCopiarTabla1.UseVisualStyleBackColor = true;
            this.btnCopiarTabla1.Click += new System.EventHandler(this.btnCopiarTabla1_Click);
            // 
            // Prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1071, 723);
            this.Controls.Add(this.btnCopiarTabla1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.copiarPrueba);
            this.Controls.Add(this.grdResultados2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.grdResultados);
            this.Name = "Prueba";
            this.Text = "Simulacion";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.DataGridView grdResultados2;
        private System.Windows.Forms.Label lblResultadoHipotesis;
        private System.Windows.Forms.TextBox txtGradosLibertad;
        private System.Windows.Forms.TextBox txtProbabilidad;
        private System.Windows.Forms.Label lblGradosLibertad;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rb20;
        private System.Windows.Forms.RadioButton rb15;
        private System.Windows.Forms.RadioButton rb10;
        private System.Windows.Forms.RadioButton rb5;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tamanioMuestra;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button copiarPrueba;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnProbar;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnCopiarTabla1;
    }
}