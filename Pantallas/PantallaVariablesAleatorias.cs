using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
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
        int[] valoresDiscretos;

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
            if (rb5.Checked) { cantidadIntervalos = int.Parse(rb5.Text); }
            if (rb10.Checked) { cantidadIntervalos = int.Parse(rb10.Text); }
            if (rb15.Checked) { cantidadIntervalos = int.Parse(rb15.Text); }
            if (rb20.Checked) { cantidadIntervalos = int.Parse(rb20.Text); }
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            gbGrafico.Controls.Clear();
            grdResultados.DataSource = null;
            dataTable.Rows.Clear();
            gbGrafico.Controls.Clear();
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

            if (lambda < 0 || media < 0) { return; }

            // TODO generar intervalos

            generadorDistribucion = new GeneradorExponencialNegativa(dataTable, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores);
            grdResultados.DataSource = dataTable;

            float menor = ((GeneradorExponencialNegativa)generadorDistribucion).getMenor();
            float mayor = ((GeneradorExponencialNegativa)generadorDistribucion).getMayor();

            generarIntervalosNormal(menor, mayor);
            obtenerFrecuenciasObservadasNormal(dataTable);

            probador = new ProbadorExponencial(truncador, dataTable, media, lambda, cantidadIntervalos, mayor, menor);
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

            generarIntervalosNormal(menor, mayor);
            obtenerFrecuenciasObservadasNormal(dataTable);

            probador = new ProbadorNormal(truncador, dataTable, media, desviacion, inicioIntervalos, finIntervalos, frecuenciasObservadas);
        }

        private void generarIntervalosNormal(float menor, float mayor)
        {
            GeneradorIntervalosNormal generadorIntervalos = new GeneradorIntervalosNormal(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);
            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        private void obtenerFrecuenciasObservadasNormal(DataTable numeros)
        {
            ContadorFrecuenciaObservada contadorFrecuencias = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            contadorFrecuencias.contarFrecuenciaSerie(numeros);
            frecuenciasObservadas = contadorFrecuencias.obtenerFrecuencias();
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

            generarIntervalosNormal(menor, mayor);
            obtenerFrecuenciasObservadasNormal(dataTable);

            probador = new ProbadorNormal(truncador, dataTable, media, desviacion, inicioIntervalos, finIntervalos, frecuenciasObservadas);
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

            if(media < 0) { return; }

            contador = new ContadorFrecuenciaObservada();
            generadorDistribucion = new GeneradorPoisson(dataTable, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores, contador);

            grdResultados.DataSource = dataTable;

            contador.ordenarSeriePoisson();
            frecuenciasObservadas = contador.getFrecuenciasPoisson();
            valoresDiscretos = contador.getValoresPoisson();

            probador = new ProbadorPoisson(truncador, dataTable, lambda, valoresDiscretos, frecuenciasObservadas);
        }

        private void probarPoisson()
        {
            PantallaPruebaChi2 pantallaPrueba = new PantallaPruebaChi2();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }
        private void probarExponencial()
        {
            PantallaPruebaChi2 pantallaPrueba = new PantallaPruebaChi2();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
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

            if (rbPoisson.Checked) { graficador.valoresDiscretos = this.valoresDiscretos; }
            else { graficador.valoresDiscretos = null; }
           

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
                activarRadioButtons();
                gbUniforme.Visible = true;
                gbExponencial.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbPoisson.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                activarRadioButtons();
                gbNormalBoxMuller.Visible = true;
                gbUniforme.Visible = false;
                gbExponencial.Visible = false;
                gbPoisson.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                activarRadioButtons();
                gbNormalConvolucion.Visible = true;
                gbNormalBoxMuller.Visible = false;
                gbUniforme.Visible = false;
                gbPoisson.Visible = false;
                gbExponencial.Visible = false;
                return;
            }
            if (rbExponencial.Checked)
            {
                activarRadioButtons();
                gbExponencial.Visible = true;
                gbUniforme.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbNormalConvolucion.Visible = false;
                gbPoisson.Visible = false;
                return;
            }
            if (rbPoisson.Checked)
            {
               desactivarRadioButtons();
                gbPoisson.Visible = true;
                gbExponencial.Visible = false;
                gbUniforme.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
        }

        private void desactivarRadioButtons()
        {
            rb5.Enabled = false;
            rb10.Enabled = false;
            rb15.Enabled = false;
            rb20.Enabled = false;
        }

        private void activarRadioButtons()
        {
            if(!rb5.Enabled) { rb5.Enabled = true; }
            if (!rb10.Enabled) { rb10.Enabled = true; }
            if (!rb15.Enabled) { rb15.Enabled = true; }
            if (!rb20.Enabled) { rb20.Enabled = true; }
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
                probarExponencial();
                return;
            }
            if (rbPoisson.Checked)
            {
                probarPoisson();
                return;
            }
        }

        private String tablaToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tablaToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
