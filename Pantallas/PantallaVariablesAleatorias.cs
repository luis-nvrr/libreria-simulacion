using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
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
        IGenerador generadorDistribucion;
        Truncador truncador;
        GeneradorIntervalosUniformeAB generadorIntervalos;
        GraficadorExcelObservado graficador;
        ContadorFrecuenciaObservada contador;

        float[] inicioIntervalos;
        float[] finIntervalos;

        int cantidadValores;
        int cantidadIntervalos;
        int[] frecuenciasObservadas;

        DataTable dataTable;

        public PantallaVariablesAleatorias()
        {
            InitializeComponent();
        }

        private void PantallaPruebaGenerador_Load(object sender, EventArgs e)
        {
            truncador = new Truncador(4);
            grdResultados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataTable = new DataTable();
        }

        private void tomarEntrada()
        {
            cantidadValores = int.Parse(txtCantidadValores.Text);
            cantidadIntervalos = int.Parse(txtCantidadIntervalos.Text);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            gbGrafico.Controls.Clear();
            grdResultados.DataSource = null;
            dataTable.Rows.Clear();

            tomarEntrada();
            generarVariablesAleatorias();
        }

        private void generarVariablesAleatorias()
        {
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
                generarExponencial();
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

            if (b < a) { return; }

            generarIntervalosUniforme(a,b);
            contador = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            generadorDistribucion = new GeneradorUniformeAB(truncador, a, b);
            dataTable = generadorDistribucion.generarSerie(cantidadValores, contador); 
            grdResultados.DataSource = dataTable;
            frecuenciasObservadas = contador.obtenerFrecuencias();
        }

        private void generarIntervalosUniforme(float a, float b)
        {
            generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, a, b);
            inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            finIntervalos = generadorIntervalos.obtenerFinIntervalos();

            //MessageBox.Show(generadorIntervalos.mostrarIntervalos());
        }

        private void generarExponencial()
        {
            double[] parametros = calcularLambdaExponencial();
            double lambda = parametros[0];
            double media = parametros[1];
   
            if(lambda < 0 || media < 0) { return; }

            // TODO generar intervalos

            generadorDistribucion = new GeneradorExponencialNegativa(truncador, lambda);
            dataTable = generadorDistribucion.generarSerie(cantidadValores);
            grdResultados.DataSource = dataTable;
        }

        private double[] calcularLambdaExponencial()
        {
            double lambda;
            double media;

            if (txtLambdaExponencial.Text.Equals(""))
            {
                media = double.Parse(txtMediaExponencial.Text);
                lambda = 1 / media;
                txtLambdaExponencial.Text = lambda.ToString();
            }

            lambda = double.Parse(txtLambdaExponencial.Text);
            media = 1 / lambda;
            txtMediaExponencial.Text = media.ToString();

            return new double[]{lambda, media};
        }


        private void mostrarGrafico()
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

        private void manejarSeleccionDistribucion()
        {
            if (rbUniforme.Checked)
            {
                gbUniforme.Visible = true;
                gbExponencial.Visible = false;
                return;
            }
            if (rbNormal.Checked)
            {
                return;
            }
            if (rbExponencial.Checked)
            {
                gbExponencial.Visible = true;
                gbUniforme.Visible = false;
                return;
            }
            if (rbPoisson.Checked)
            {
                return;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarGrafico();
        }

        private void rbUniforme_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void rbExponencial_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void rbPoisson_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }
    }
}
