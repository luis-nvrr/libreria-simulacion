using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using Numeros_aleatorios.LibreriaSimulacion.Probadores;
using Numeros_aleatorios.Pantallas;
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
        GeneradorUniformeLenguaje generadorLenguaje;
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

        IProbador probador;

        public PantallaVariablesAleatorias()
        {
            InitializeComponent();
        }

        private void PantallaPruebaGenerador_Load(object sender, EventArgs e)
        {
            truncador = new Truncador(4);
            grdResultados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataTable = new DataTable();
            dataTable.Columns.Add("iteracion");
            dataTable.Columns.Add("aleatorio");
            generadorLenguaje = new GeneradorUniformeLenguaje(truncador);
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
            if (rbNormalBoxMuller.Checked)
            {
                generarNormalBoxMuller();
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                generarNormalConvolucion();
                return;
            }
            if (rbExponencial.Checked)
            {
                generarExponencial();
                return;
            }
            if (rbPoisson.Checked)
            {
                generarPoisson();
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
            generadorDistribucion = new GeneradorUniformeAB(dataTable, generadorLenguaje, truncador, a, b);
            generadorDistribucion.generarSerie(cantidadValores, contador); 
            grdResultados.DataSource = dataTable;
            frecuenciasObservadas = contador.obtenerFrecuencias();

            probador = new ProbadorUniforme(truncador, dataTable, inicioIntervalos, finIntervalos, frecuenciasObservadas);
            probador.probar();
        }

        private void generarIntervalosUniforme(float a, float b)
        {
            generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, a, b);
            inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        private void probarUniforme()
        {
            PantallaPruebaChi2 pantallaPrueba = new PantallaPruebaChi2();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }

        private void generarExponencial()
        {
            double[] parametros = calcularLambdaExponencial();
            double lambda = parametros[0];
            double media = parametros[1];
   
            if(lambda < 0 || media < 0) { return; }

            // TODO generar intervalos

            generadorDistribucion = new GeneradorExponencialNegativa(dataTable, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores);
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

        private void generarNormalBoxMuller()
        {
            double desviacion = double.Parse(txtDesviacionNormalBoxMuller.Text);
            double media = double.Parse(txtMediaNormalBoxMuller.Text);

            if (desviacion < 0 || media < 0) { return; } //restriccion

            generadorDistribucion = new GeneradorNormalBoxMuller(dataTable, generadorLenguaje, truncador, desviacion, media);
            generadorDistribucion.generarSerie(cantidadValores);
            grdResultados.DataSource = dataTable;

            float menor = ((GeneradorNormalBoxMuller)generadorDistribucion).getMenor();
            float mayor = ((GeneradorNormalBoxMuller)generadorDistribucion).getMayor();

            MessageBox.Show(menor.ToString());
            MessageBox.Show(mayor.ToString());

            probador = new ProbadorNormal(truncador, dataTable, media, desviacion, cantidadIntervalos, menor, mayor);
            probador.probar();
            this.frecuenciasObservadas = ((ProbadorNormal)probador).getFrecuenciasObservadas();
            this.inicioIntervalos = ((ProbadorNormal)probador).getInicioIntervalos();
            this.finIntervalos = ((ProbadorNormal)probador).getFinIntervalos();
        }


        private void probarNormalBoxMuller()
        {
            PantallaPruebaChi2 pantallaPrueba = new PantallaPruebaChi2();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }

        private void generarNormalConvolucion()
        {
            double desviacion = double.Parse(txtDesviacionNormalConvolucion.Text);
            double media = double.Parse(txtMediaNormalConvolucion.Text);

            if (desviacion < 0 || media < 0) { return; } //restriccion

            generadorDistribucion = new GeneradorNormalConvolucion(dataTable, generadorLenguaje, truncador, desviacion, media);
            generadorDistribucion.generarSerie(cantidadValores);
            grdResultados.DataSource = dataTable;

            float menor = ((GeneradorNormalConvolucion)generadorDistribucion).getMenor();
            float mayor = ((GeneradorNormalConvolucion)generadorDistribucion).getMayor();

            MessageBox.Show(menor.ToString());
            MessageBox.Show(mayor.ToString());

            probador = new ProbadorNormal(truncador, dataTable, media, desviacion, cantidadIntervalos, menor, mayor);
            probador.probar();
            this.frecuenciasObservadas = ((ProbadorNormal)probador).getFrecuenciasObservadas();
            this.inicioIntervalos = ((ProbadorNormal)probador).getInicioIntervalos();
            this.finIntervalos = ((ProbadorNormal)probador).getFinIntervalos();
        }

        private void probarNormalConvolucion()
        {
            PantallaPruebaChi2 pantallaPrueba = new PantallaPruebaChi2();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }

        private void generarPoisson()
        {
            double[] parametros = calcularLambdaPoisson();
            double lambda = parametros[0];
            double media = parametros[1];

            if (lambda < 0 || media < 0) { return; }

            // TODO generar intervalos

            generadorDistribucion = new GeneradorPoisson(dataTable, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores);
            grdResultados.DataSource = dataTable;
        }


        private double[] calcularLambdaPoisson()
        {
            double lambda;
            double media;

            if (txtLambdaPoisson.Text.Equals(""))
            {
                media = double.Parse(txtMediaPoisson.Text);
                lambda = media;
                txtLambdaPoisson.Text = lambda.ToString();
            }

            lambda = double.Parse(txtLambdaPoisson.Text);
            media = lambda;
            txtMediaPoisson.Text = media.ToString();

            return new double[] { lambda, media };
        }

        private void mostrarGrafico()
        {
            graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = frecuenciasObservadas;
            graficador.nombre = gbDistribuciones.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;

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
                gbNormalBoxMuller.Visible = false;
                gbPoisson.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                gbNormalBoxMuller.Visible = true;
                gbUniforme.Visible = false;
                gbExponencial.Visible = false;
                gbPoisson.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                gbNormalConvolucion.Visible = true;
                gbNormalBoxMuller.Visible = false;
                gbUniforme.Visible = false;
                gbPoisson.Visible = false;
                gbExponencial.Visible = false;
                return;
            }
            if (rbExponencial.Checked)
            {
                gbExponencial.Visible = true;
                gbUniforme.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbNormalConvolucion.Visible = false;
                gbPoisson.Visible = false;
                return;
            }
            if (rbPoisson.Checked)
            {
                gbPoisson.Visible = true;
                gbExponencial.Visible = false;
                gbUniforme.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbNormalConvolucion.Visible = false;
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

        private void btnJi_Click(object sender, EventArgs e)
        {
            if (rbUniforme.Checked)
            {
                probarUniforme();
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                probarNormalBoxMuller();
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                probarNormalConvolucion();
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
    }
}
