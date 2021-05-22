using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Colas
{
    public partial class PantallaResultados : Form
    {
        public PantallaResultados()
        {
            InitializeComponent();
        }

        private void PantallaResultados_Load(object sender, EventArgs e)
        {
            ColasMunicipalidad colas = new ColasMunicipalidad(this);
            colas.simular();
        }

        public void mostrarResultados(DataTable resultados)
        {
            this.grdRangoResultados.DataSource = resultados;
        }
    }
}
