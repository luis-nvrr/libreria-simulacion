using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Montecarlo
{
    public partial class PantallaInventarioBicicletas : Form
    {
        private GestorInventarioBicicletas gestor;
        private int CANTIDAD_SIMULACIONES = 100000;
        private int INICIO = 99900;
        private int FIN = 100000;
        private int CANTIDAD_PEDIDO = 6;
        private int STOCK_INICIAL = 7;
        private int PUNTO_PEDIDO = 2;
        private int COSTO_MANTENIMIENTO = 3;
        private int COSTO_STOCKOUT = 5;
        private int COSTO_PEDIDO = 20;

        public PantallaInventarioBicicletas()
        {
            InitializeComponent();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            tomarDatos();
            gestor = new GestorInventarioBicicletas(this);
            gestor.simular(CANTIDAD_SIMULACIONES, INICIO, FIN, PUNTO_PEDIDO, CANTIDAD_PEDIDO,
                STOCK_INICIAL, COSTO_MANTENIMIENTO, COSTO_STOCKOUT, COSTO_PEDIDO);
        }

        private void tomarDatos()
        {
            CANTIDAD_SIMULACIONES = int.Parse(txtCantidad.Text);
            INICIO = int.Parse(txtDesde.Text);
            FIN = int.Parse(txtHasta.Text);
            PUNTO_PEDIDO = int.Parse(txtPuntoPedido.Text);
            CANTIDAD_PEDIDO = int.Parse(txtCantidadPedido.Text);
            STOCK_INICIAL = int.Parse(txtStockInicial.Text);
            COSTO_MANTENIMIENTO = int.Parse(txtCostoMantenimiento.Text);
            COSTO_STOCKOUT = int.Parse(txtCostoStockout.Text);
            COSTO_PEDIDO = int.Parse(txtCostoPedido.Text);
        }

        public void mostrarResultados(DataTable tablaResultados)
        {
            this.grdResultados.DataSource = tablaResultados;
        }

        public void mostrarRango(DataTable tablaRango)
        {
            PantallaResultadosRangoMontecarlo resultados = new PantallaResultadosRangoMontecarlo();
            resultados.mostrarRango(tablaRango);
            resultados.Show();
        }

        public void cargarDatosIniciales()
        {
            this.txtCantidad.Text = CANTIDAD_SIMULACIONES.ToString();
            this.txtPuntoPedido.Text = PUNTO_PEDIDO.ToString();
            this.txtCantidadPedido.Text = CANTIDAD_PEDIDO.ToString();
            this.txtStockInicial.Text = STOCK_INICIAL.ToString();
            this.txtCostoMantenimiento.Text = COSTO_MANTENIMIENTO.ToString();
            this.txtCostoStockout.Text = COSTO_STOCKOUT.ToString();
            this.txtCostoPedido.Text = COSTO_PEDIDO.ToString();
            this.txtDesde.Text = INICIO.ToString();
            this.txtHasta.Text = FIN.ToString();
        }

        private void PantallaInventarioBicicletas_Load(object sender, EventArgs e)
        {
            this.cargarDatosIniciales();
        }
    }
}
