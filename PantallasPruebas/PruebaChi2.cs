using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion;
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

namespace Numeros_aleatorios.Pruebas_de_bondad
{
    public partial class PruebaChi2 : Form
    {
        int indice = -1;
        int cantidadAleatorios;

        DataTable tablaAleatorios;
        DataTable tablaResultados;

        Truncador truncador;
    

        double[] inicioIntervalos;
        double[] finIntervalos;
        int cantidadIntervalos;
        int[] frecuenciasObservadas;

        double[] jiCuadrado = { 0, 3.84, 5.99, 7.81, 9.49, 11.1, 12.6, 14.1, 15.5, 16.9, 
                                18.3, 19.7, 21.0, 22.4, 23.7, 25.0, 26.3, 27.6, 28.9,
                                30.1, 31.4, 32.7, 33.9, 35.2, 36.4, 37.7, 38.9, 40.1, 
                                41.3, 42.6, 43.8};
        double estadisticoPruebaAcumuladoAnterior;
        public PruebaChi2()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tablaAleatorios = new DataTable();
            tablaResultados = new DataTable();
            truncador = new Truncador(4);

            tablaAleatorios.Columns.Add("Iteración");
            tablaAleatorios.Columns.Add("Número Aleatorio");

            tablaResultados.Columns.Add("Intervalo");
            tablaResultados.Columns.Add("Frecuencia Observada");
            tablaResultados.Columns.Add("Frecuencia Esperada");
            tablaResultados.Columns.Add("C");
            tablaResultados.Columns.Add("C (ac)");

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            tomarEntrada();
            if(cantidadAleatorios <=0) { MessageBox.Show("El tamaño de la muestra debe ser mayor a 0..."); }
            if (cantidadAleatorios > 0)
            {
                tablaAleatorios.Clear();
                generarNumerosAleatorios();
            }
        }

        private void tomarEntrada()
        {
            cantidadAleatorios = int.Parse(tamanioMuestra.Text);
            if (rb5.Checked) { cantidadIntervalos = int.Parse(rb5.Text); }
            if (rb10.Checked) { cantidadIntervalos = int.Parse(rb10.Text); }
            if (rb15.Checked) { cantidadIntervalos = int.Parse(rb15.Text); }
            if (rb20.Checked) { cantidadIntervalos = int.Parse(rb20.Text); }
        }

        public void generarNumerosAleatorios()
        {
            inicioIntervalos = new double[cantidadIntervalos];
            finIntervalos = new double[cantidadIntervalos];
            GeneradorIntervalosUniforme intervalos = new GeneradorIntervalosUniforme(truncador);

            intervalos.generarIntervalos(cantidadIntervalos);
            inicioIntervalos = intervalos.obtenerInicioIntervalos();
            finIntervalos = intervalos.obtenerFinIntervalos();

            ContadorFrecuenciaObservada contador = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            IGenerador generador = new GeneradorUniformeLenguaje(tablaAleatorios, truncador);
            generador.generarSerie(cantidadAleatorios, contador);

            grdResultados.DataSource = tablaAleatorios;
            frecuenciasObservadas = contador.obtenerFrecuencias();
        }

        private void construirTabla()
        {
            tablaResultados.Clear();
            DataRow row;
            double frecuenciaEsperada = truncador.truncar((double)cantidadAleatorios / (double)cantidadIntervalos);
            double estadisticoPrueba;
            double estadisticoPruebaAcumuladoAnterior = 0;

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                row = tablaResultados.NewRow();
                row[0] = "[" + inicioIntervalos[i] + "-" + finIntervalos[i] + "]";
                row[1] = frecuenciasObservadas[i];
                row[2] = frecuenciaEsperada;
                estadisticoPrueba = (Math.Pow((frecuenciaEsperada - frecuenciasObservadas[i]), 2) / frecuenciaEsperada);
                row[3] = truncador.truncar(estadisticoPrueba);
                row[4] = truncador.truncar(estadisticoPruebaAcumuladoAnterior + estadisticoPrueba);
                estadisticoPruebaAcumuladoAnterior += estadisticoPrueba;
                tablaResultados.Rows.Add(row);
            }
            grdResultados2.DataSource = tablaResultados;
        }

        public void evaluarHipotesis()
        {
            int v = cantidadIntervalos - 1 ; // m=0 porque no hubo observacion
            txtGradosLibertad.Text = v.ToString();
            double probabilidad = jiCuadrado[v];
            txtProbabilidad.Text = probabilidad.ToString();
            if (double.Parse(tablaResultados.Rows[cantidadIntervalos - 1][4].ToString()) <= probabilidad) 
            {
                lblResultadoHipotesis.Text = "No se rechaza la hipotesis de distribucion uniforme";
            }
            else
            {
                lblResultadoHipotesis.Text = "Se rechaza la hipótesis nula";
            }

        }

        public void mostrarGrafico()
        {
            GraficadorExcelObservado graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = frecuenciasObservadas;
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            graficador.Show();
        }
        
        public String tabla1ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in tablaAleatorios.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        public String tabla2ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in tablaResultados.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString()).Append("\t").Append(row[2].ToString()).Append("\t").Append(row[3].ToString()).Append("\t").Append(row[4].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        private void btnCopiarTabla1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tabla1ToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void copiarPrueba_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tabla2ToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarGrafico();
        }

        private void btnProbar_Click(object sender, EventArgs e)
        {
            construirTabla();
            evaluarHipotesis();
        }
    }
}
