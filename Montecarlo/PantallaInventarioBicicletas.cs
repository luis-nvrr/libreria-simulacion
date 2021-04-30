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
        private int CANTIDAD_SIMULACIONES = 2000000;
        private int INICIO = 100;
        private int FIN = 200;

        public PantallaInventarioBicicletas()
        {
            InitializeComponent();
        }

        private void btnSimular_Click(object sender, EventArgs e)
        {
            gestor = new GestorInventarioBicicletas(this);
            gestor.simular(CANTIDAD_SIMULACIONES, INICIO, FIN);
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


    }
}
