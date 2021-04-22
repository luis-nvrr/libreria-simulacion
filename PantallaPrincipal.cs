using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.Pruebas_de_bondad;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios
{
    public partial class PantallaPrincipal : Form
    {
        public PantallaPrincipal()
        {
            InitializeComponent();
        }

        private void btnPantallaGeneradores_Click(object sender, EventArgs e)
        {
            PantallaGeneradores pantallaGeneradores = new PantallaGeneradores();
            pantallaGeneradores.Show();
        }

        private void btnPruebaJI_Click(object sender, EventArgs e)
        {
            PruebaChi2 pantallaPruebaJI = new PruebaChi2();
            pantallaPruebaJI.Show();
        }

        private void btnPruebaKS_Click(object sender, EventArgs e)
        {
            PruebaKolgomorovSmilnov pantallaPruebaKS = new PruebaKolgomorovSmilnov();
            pantallaPruebaKS.Show();
        }

        private void btnPantallaVariablesAleatorias_Click(object sender, EventArgs e)
        {
            PantallaVariablesAleatorias pantallaVariablesAleatorias = new PantallaVariablesAleatorias();
            pantallaVariablesAleatorias.Show();
        }
    }
}
