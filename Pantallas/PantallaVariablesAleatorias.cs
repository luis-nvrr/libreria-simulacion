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
            grdResultados.Rows.Clear();
            gbGrafico.Controls.Clear();
            indice = -1;
            cantidadValores = int.Parse(txtCantidadValores.Text);
            cantidadIntervalos = int.Parse(txtCantidadIntervalos.Text);

            frecuenciasObservadas = new int[cantidadIntervalos];

            if (rbUniforme.Checked)
            {
                generarUniforme();
                return;
            }
            if (rbNormal.Checked)
            {
                return;
            }
            if (rbExponencial.Checked)
            {
                return;
            }
            if (rbPoisson.Checked)
            {
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

                // conteo de frecuencias
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
            graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = frecuenciasObservadas;
            graficador.nombre = gbDistribuciones.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;

            gbGrafico.Controls.Clear();
            graficador.TopLevel = false;
            graficador.AutoScroll = true;
            graficador.FormBorderStyle = FormBorderStyle.None;
            graficador.Dock = DockStyle.Fill;
            gbGrafico.Controls.Add(graficador);
            graficador.Show();
        }
    }
}
