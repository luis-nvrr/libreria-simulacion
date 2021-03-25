using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    public partial class PantallaPruebaGenerador : Form
    {
        int indice = -1;
        GeneradorUniformeAB uniforme;

        public PantallaPruebaGenerador()
        {
            InitializeComponent();
        }

        private void PantallaPruebaGenerador_Load(object sender, EventArgs e)
        {
            Truncador truncador = new Truncador(4);
            uniforme = new GeneradorUniformeAB(truncador, 14, 8);
        }

        private void agregarFila(float numeroAleatorio)
        {

            grdResultados.Rows.Add();
            ++indice;
            grdResultados.Rows[indice].Cells[0].Value = indice + 1;
            grdResultados.Rows[indice].Cells[1].Value = numeroAleatorio;
            enfocarFila();
        }

        private void enfocarFila()
        {
            grdResultados.CurrentCell = grdResultados.Rows[indice].Cells[0];
        }

        private void button1_Click(object sender, EventArgs e)
        {
            agregarFila(uniforme.siguienteAleatorio());
        }
    }
}
