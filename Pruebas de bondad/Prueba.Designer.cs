
namespace Numeros_aleatorios.Pruebas_de_bondad
{
    partial class Prueba
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
            this.btn_Generar = new System.Windows.Forms.Button();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.iteracion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.aleatorio = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtCantidadNumero = new System.Windows.Forms.TextBox();
            this.txtCantidadIntervalo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.lblCantidadNumero = new System.Windows.Forms.Label();
            this.lblCantidadIntervalo = new System.Windows.Forms.Label();
            this.grdResultados2 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lblResultadoHipotesis = new System.Windows.Forms.Label();
            this.txtGradosLibertad = new System.Windows.Forms.TextBox();
            this.txtProbabilidad = new System.Windows.Forms.TextBox();
            this.lblGradosLibertad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Generar
            // 
            this.btn_Generar.Location = new System.Drawing.Point(247, 102);
            this.btn_Generar.Name = "btn_Generar";
            this.btn_Generar.Size = new System.Drawing.Size(76, 23);
            this.btn_Generar.TabIndex = 0;
            this.btn_Generar.Text = "Generar";
            this.btn_Generar.UseVisualStyleBackColor = true;
            this.btn_Generar.Click += new System.EventHandler(this.btn_Generar_Click);
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iteracion,
            this.aleatorio});
            this.grdResultados.Location = new System.Drawing.Point(12, 172);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(219, 228);
            this.grdResultados.TabIndex = 3;
            // 
            // iteracion
            // 
            this.iteracion.HeaderText = "Iteracion";
            this.iteracion.Name = "iteracion";
            this.iteracion.ReadOnly = true;
            // 
            // aleatorio
            // 
            this.aleatorio.HeaderText = "Numero Aleatorio";
            this.aleatorio.Name = "aleatorio";
            this.aleatorio.ReadOnly = true;
            // 
            // txtCantidadNumero
            // 
            this.txtCantidadNumero.Location = new System.Drawing.Point(141, 102);
            this.txtCantidadNumero.Name = "txtCantidadNumero";
            this.txtCantidadNumero.Size = new System.Drawing.Size(100, 23);
            this.txtCantidadNumero.TabIndex = 4;
            // 
            // txtCantidadIntervalo
            // 
            this.txtCantidadIntervalo.Location = new System.Drawing.Point(141, 131);
            this.txtCantidadIntervalo.Name = "txtCantidadIntervalo";
            this.txtCantidadIntervalo.Size = new System.Drawing.Size(100, 23);
            this.txtCantidadIntervalo.TabIndex = 5;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 71);
            this.panel1.TabIndex = 6;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(314, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Prueba de Ji-Cuadrada ";
            // 
            // lblCantidadNumero
            // 
            this.lblCantidadNumero.AutoSize = true;
            this.lblCantidadNumero.Location = new System.Drawing.Point(12, 105);
            this.lblCantidadNumero.Name = "lblCantidadNumero";
            this.lblCantidadNumero.Size = new System.Drawing.Size(123, 15);
            this.lblCantidadNumero.TabIndex = 7;
            this.lblCantidadNumero.Text = "Cantidad de Números";
            // 
            // lblCantidadIntervalo
            // 
            this.lblCantidadIntervalo.AutoSize = true;
            this.lblCantidadIntervalo.Location = new System.Drawing.Point(12, 134);
            this.lblCantidadIntervalo.Name = "lblCantidadIntervalo";
            this.lblCantidadIntervalo.Size = new System.Drawing.Size(125, 15);
            this.lblCantidadIntervalo.TabIndex = 8;
            this.lblCantidadIntervalo.Text = "Cantidad de Intervalos";
            // 
            // grdResultados2
            // 
            this.grdResultados2.AllowUserToAddRows = false;
            this.grdResultados2.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.Column1,
            this.Column2});
            this.grdResultados2.Location = new System.Drawing.Point(247, 172);
            this.grdResultados2.Name = "grdResultados2";
            this.grdResultados2.RowHeadersVisible = false;
            this.grdResultados2.RowTemplate.Height = 25;
            this.grdResultados2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados2.Size = new System.Drawing.Size(506, 228);
            this.grdResultados2.TabIndex = 9;
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
            this.Column1.HeaderText = "C";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "C (AC)";
            this.Column2.Name = "Column2";
            // 
            // lblResultadoHipotesis
            // 
            this.lblResultadoHipotesis.AutoSize = true;
            this.lblResultadoHipotesis.Location = new System.Drawing.Point(506, 409);
            this.lblResultadoHipotesis.Name = "lblResultadoHipotesis";
            this.lblResultadoHipotesis.Size = new System.Drawing.Size(38, 15);
            this.lblResultadoHipotesis.TabIndex = 10;
            this.lblResultadoHipotesis.Text = "label1";
            // 
            // txtGradosLibertad
            // 
            this.txtGradosLibertad.Location = new System.Drawing.Point(293, 406);
            this.txtGradosLibertad.Name = "txtGradosLibertad";
            this.txtGradosLibertad.Size = new System.Drawing.Size(53, 23);
            this.txtGradosLibertad.TabIndex = 11;
            // 
            // txtProbabilidad
            // 
            this.txtProbabilidad.Location = new System.Drawing.Point(436, 406);
            this.txtProbabilidad.Name = "txtProbabilidad";
            this.txtProbabilidad.Size = new System.Drawing.Size(53, 23);
            this.txtProbabilidad.TabIndex = 12;
            // 
            // lblGradosLibertad
            // 
            this.lblGradosLibertad.AutoSize = true;
            this.lblGradosLibertad.Location = new System.Drawing.Point(274, 409);
            this.lblGradosLibertad.Name = "lblGradosLibertad";
            this.lblGradosLibertad.Size = new System.Drawing.Size(13, 15);
            this.lblGradosLibertad.TabIndex = 13;
            this.lblGradosLibertad.Text = "v";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(366, 409);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 14;
            this.label1.Text = "Probalidad";
            // 
            // Prueba
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblGradosLibertad);
            this.Controls.Add(this.txtProbabilidad);
            this.Controls.Add(this.txtGradosLibertad);
            this.Controls.Add(this.lblResultadoHipotesis);
            this.Controls.Add(this.grdResultados2);
            this.Controls.Add(this.lblCantidadIntervalo);
            this.Controls.Add(this.lblCantidadNumero);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.txtCantidadIntervalo);
            this.Controls.Add(this.txtCantidadNumero);
            this.Controls.Add(this.grdResultados);
            this.Controls.Add(this.btn_Generar);
            this.Name = "Prueba";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Generar;
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.DataGridViewTextBoxColumn iteracion;
        private System.Windows.Forms.DataGridViewTextBoxColumn aleatorio;
        private System.Windows.Forms.TextBox txtCantidadNumero;
        private System.Windows.Forms.TextBox txtCantidadIntervalo;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Label lblCantidadNumero;
        private System.Windows.Forms.Label lblCantidadIntervalo;
        private System.Windows.Forms.DataGridView grdResultados2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.Label lblResultadoHipotesis;
        private System.Windows.Forms.TextBox txtGradosLibertad;
        private System.Windows.Forms.TextBox txtProbabilidad;
        private System.Windows.Forms.Label lblGradosLibertad;
        private System.Windows.Forms.Label label1;
    }
}