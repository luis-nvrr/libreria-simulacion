using Numeros_aleatorios.grafico_excel;
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
    public partial class PantallaVariablesAleatorias : Form
    {
        int indice;
        GeneradorUniformeAB uniforme;
        Truncador truncador;
        GeneradorIntervalosUniformeAB generadorIntervalos;
        GraficadorExcelObservado graficador;

        float[] inicioIntervalos;
        float[] finIntervalos;

        int cantidadValores;
        int cantidadIntervalos;
        int[] frecuenciasObservadas;

        float numeroAleatorio;

        public PantallaVariablesAleatorias()
        {
            InitializeComponent();
        }

        private void PantallaPruebaGenerador_Load(object sender, EventArgs e)
        {
            truncador = new Truncador(4);
            graficador = new GraficadorExcelObservado();
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

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            indice = -1;
            cantidadValores = int.Parse(txtCantidadValores.Text);
            cantidadIntervalos = int.Parse(txtCantidadIntervalos.Text);

            frecuenciasObservadas = new int[cantidadIntervalos];

            if (rbUniforme.Checked)
            {
                generarUniforme();
                return;
            }
        }

        private void generarUniforme()
        {
            float a = float.Parse(txtA.Text);
            float b = float.Parse(txtB.Text);
            generarIntervalosUniforme(a,b);

            if (b < a) { return; }

            uniforme = new GeneradorUniformeAB(truncador, a, b);

            for (int i = 0; i < cantidadValores; i++)
            {
                numeroAleatorio = uniforme.siguienteAleatorio();
                agregarFila(numeroAleatorio);

                for (int j = 0; j < cantidadIntervalos; j++)
                {
                    if (numeroAleatorio >= inicioIntervalos[j] &&
                        numeroAleatorio <= finIntervalos[j])
                    {
                        frecuenciasObservadas[j] += 1;
                        break;
                    }
                }
            }
            graficador.frecuenciaObservada = frecuenciasObservadas;
        }

        private void generarIntervalosUniforme(float a, float b)
        {
            generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, a, b);
            inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            finIntervalos = generadorIntervalos.obtenerFinIntervalos();

            MessageBox.Show(generadorIntervalos.mostrarIntervalos());
        }


        private void btnMostrar_Click(object sender, EventArgs e)
        {
            graficador.Show();
        }
    }
}
