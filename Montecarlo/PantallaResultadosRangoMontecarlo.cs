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
    public partial class PantallaResultadosRangoMontecarlo : Form
    {
        public PantallaResultadosRangoMontecarlo()
        {
            InitializeComponent();
        }

        public void mostrarRango(DataTable tablaRango)
        {
            this.grdRangoResultados.DataSource = tablaRango;
        }
    }
}
