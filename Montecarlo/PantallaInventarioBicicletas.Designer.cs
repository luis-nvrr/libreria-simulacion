﻿
namespace Numeros_aleatorios.Montecarlo
{
    partial class PantallaInventarioBicicletas
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
            this.txtCantidad = new System.Windows.Forms.TextBox();
            this.lblCantidad = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtCostoStockout = new System.Windows.Forms.TextBox();
            this.txtCostoMantenimiento = new System.Windows.Forms.TextBox();
            this.txtCantidadPedido = new System.Windows.Forms.TextBox();
            this.txtStockInicial = new System.Windows.Forms.TextBox();
            this.txtPuntoPedido = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnSimular = new System.Windows.Forms.Button();
            this.txtHasta = new System.Windows.Forms.TextBox();
            this.txtDesde = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grdResultados = new System.Windows.Forms.DataGridView();
            this.txtCostoPedido = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(0)))), ((int)(((byte)(30)))));
            this.panel1.Controls.Add(this.lblTitulo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1364, 71);
            this.panel1.TabIndex = 8;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.lblTitulo.ForeColor = System.Drawing.SystemColors.Control;
            this.lblTitulo.Location = new System.Drawing.Point(12, 13);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(537, 40);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Montecarlo: Ej.10 Inventario de bicicletas";
            // 
            // txtCantidad
            // 
            this.txtCantidad.Location = new System.Drawing.Point(229, 33);
            this.txtCantidad.Name = "txtCantidad";
            this.txtCantidad.Size = new System.Drawing.Size(100, 29);
            this.txtCantidad.TabIndex = 9;
            // 
            // lblCantidad
            // 
            this.lblCantidad.AutoSize = true;
            this.lblCantidad.Location = new System.Drawing.Point(33, 36);
            this.lblCantidad.Name = "lblCantidad";
            this.lblCantidad.Size = new System.Drawing.Size(190, 21);
            this.lblCantidad.TabIndex = 10;
            this.lblCantidad.Text = "Cantidad de simulaciones:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtCostoPedido);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtCostoStockout);
            this.groupBox1.Controls.Add(this.txtCostoMantenimiento);
            this.groupBox1.Controls.Add(this.txtCantidadPedido);
            this.groupBox1.Controls.Add(this.txtStockInicial);
            this.groupBox1.Controls.Add(this.txtPuntoPedido);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.btnSimular);
            this.groupBox1.Controls.Add(this.txtHasta);
            this.groupBox1.Controls.Add(this.txtDesde);
            this.groupBox1.Controls.Add(this.txtCantidad);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.lblCantidad);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox1.Location = new System.Drawing.Point(12, 77);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1332, 394);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "1. Datos";
            // 
            // txtCostoStockout
            // 
            this.txtCostoStockout.Location = new System.Drawing.Point(228, 296);
            this.txtCostoStockout.Name = "txtCostoStockout";
            this.txtCostoStockout.Size = new System.Drawing.Size(100, 29);
            this.txtCostoStockout.TabIndex = 18;
            // 
            // txtCostoMantenimiento
            // 
            this.txtCostoMantenimiento.Location = new System.Drawing.Point(228, 261);
            this.txtCostoMantenimiento.Name = "txtCostoMantenimiento";
            this.txtCostoMantenimiento.Size = new System.Drawing.Size(100, 29);
            this.txtCostoMantenimiento.TabIndex = 18;
            // 
            // txtCantidadPedido
            // 
            this.txtCantidadPedido.Location = new System.Drawing.Point(228, 227);
            this.txtCantidadPedido.Name = "txtCantidadPedido";
            this.txtCantidadPedido.Size = new System.Drawing.Size(100, 29);
            this.txtCantidadPedido.TabIndex = 18;
            // 
            // txtStockInicial
            // 
            this.txtStockInicial.Location = new System.Drawing.Point(229, 192);
            this.txtStockInicial.Name = "txtStockInicial";
            this.txtStockInicial.Size = new System.Drawing.Size(100, 29);
            this.txtStockInicial.TabIndex = 18;
            // 
            // txtPuntoPedido
            // 
            this.txtPuntoPedido.Location = new System.Drawing.Point(229, 157);
            this.txtPuntoPedido.Name = "txtPuntoPedido";
            this.txtPuntoPedido.Size = new System.Drawing.Size(100, 29);
            this.txtPuntoPedido.TabIndex = 18;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(86, 304);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(137, 21);
            this.label7.TabIndex = 17;
            this.label7.Text = "Costo de stockout:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 269);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(184, 21);
            this.label6.TabIndex = 16;
            this.label6.Text = "Costo de mantenimiento:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(96, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 21);
            this.label5.TabIndex = 15;
            this.label5.Text = "Cantidad pedida:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(128, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 21);
            this.label4.TabIndex = 14;
            this.label4.Text = "Stock inicial:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(127, 21);
            this.label3.TabIndex = 13;
            this.label3.Text = "Punto de pedido:";
            // 
            // btnSimular
            // 
            this.btnSimular.Location = new System.Drawing.Point(411, 289);
            this.btnSimular.Name = "btnSimular";
            this.btnSimular.Size = new System.Drawing.Size(113, 36);
            this.btnSimular.TabIndex = 12;
            this.btnSimular.Text = "Simular";
            this.btnSimular.UseVisualStyleBackColor = true;
            this.btnSimular.Click += new System.EventHandler(this.btnSimular_Click);
            // 
            // txtHasta
            // 
            this.txtHasta.Location = new System.Drawing.Point(411, 83);
            this.txtHasta.Name = "txtHasta";
            this.txtHasta.Size = new System.Drawing.Size(100, 29);
            this.txtHasta.TabIndex = 11;
            // 
            // txtDesde
            // 
            this.txtDesde.Location = new System.Drawing.Point(229, 83);
            this.txtDesde.Name = "txtDesde";
            this.txtDesde.Size = new System.Drawing.Size(100, 29);
            this.txtDesde.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(355, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 21);
            this.label2.TabIndex = 10;
            this.label2.Text = "hasta:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(110, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 21);
            this.label1.TabIndex = 10;
            this.label1.Text = "Mostrar desde:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grdResultados);
            this.groupBox3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.groupBox3.Location = new System.Drawing.Point(12, 477);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1340, 244);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "2. Resultados";
            // 
            // grdResultados
            // 
            this.grdResultados.AllowUserToAddRows = false;
            this.grdResultados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.grdResultados.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.grdResultados.BackgroundColor = System.Drawing.Color.White;
            this.grdResultados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdResultados.Location = new System.Drawing.Point(33, 45);
            this.grdResultados.Name = "grdResultados";
            this.grdResultados.RowHeadersVisible = false;
            this.grdResultados.RowTemplate.Height = 25;
            this.grdResultados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.grdResultados.Size = new System.Drawing.Size(1288, 164);
            this.grdResultados.TabIndex = 6;
            // 
            // txtCostoPedido
            // 
            this.txtCostoPedido.Location = new System.Drawing.Point(229, 331);
            this.txtCostoPedido.Name = "txtCostoPedido";
            this.txtCostoPedido.Size = new System.Drawing.Size(100, 29);
            this.txtCostoPedido.TabIndex = 20;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(96, 339);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 21);
            this.label8.TabIndex = 19;
            this.label8.Text = "Costo de pedido:";
            // 
            // PantallaInventarioBicicletas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1364, 749);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel1);
            this.Name = "PantallaInventarioBicicletas";
            this.Text = "PantallaInventarioBicicletas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.PantallaInventarioBicicletas_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdResultados)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.TextBox txtCantidad;
        private System.Windows.Forms.Label lblCantidad;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtHasta;
        private System.Windows.Forms.TextBox txtDesde;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnSimular;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DataGridView grdResultados;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCostoStockout;
        private System.Windows.Forms.TextBox txtCostoMantenimiento;
        private System.Windows.Forms.TextBox txtCantidadPedido;
        private System.Windows.Forms.TextBox txtStockInicial;
        private System.Windows.Forms.TextBox txtPuntoPedido;
        private System.Windows.Forms.TextBox txtCostoPedido;
        private System.Windows.Forms.Label label8;
    }
}