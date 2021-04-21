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

namespace Numeros_aleatorios
{
    public partial class PruebaKolgomorovSmilnov : Form
    {
        int indice = -1;
        int n;
        int cantidadIntervalos;
        int[] frecuenciasObservadas;
        float[] inicioIntervalos;
        float[] finIntervalos;
        Random random;
        DataTable tablaAleatorios;
        DataTable tabla2;
        GraficadorExcelObservado graficador;
        Truncador truncador;
        
        double esperadaAcumuladaAnterior;
        double observadaAcumuladaAnterior;

        //double[] kolgomorovosSmilnov = { 0, 0.97500, 0.84189, 0.70760, 0.62394, 0.56328, 0.51926, 0.48342, 0.45427,
        //                                0.43001, 0.40925, 0.39122, 0.37543, 0.36143, 0.34890, 0.33750, 0.32733, 0.31796,
        //                                0.30936, 0.30143, 0.29408, 0.28724, 0.28087, 0.27490, 0.26931, 0.26404, 0.25908,
        //                                0.25438, 0.24933, 0.24571, 0.24170, 0.23788, 0.23424, 0.23076, 0.22743, 0.22425};
        public PruebaKolgomorovSmilnov()
        {
            InitializeComponent();
        }

        private void PruebaKolgomorovSmilnov_Load(object sender, EventArgs e)
        {
            tablaAleatorios = new DataTable();
            tabla2 = new DataTable();
            random = new Random();
            truncador = new Truncador(4);

            tablaAleatorios.Columns.Add("Iteración");
            tablaAleatorios.Columns.Add("Número Aleatorio");

            tabla2.Columns.Add("Intervalo");
            tabla2.Columns.Add("Frecuencia Observada");
            tabla2.Columns.Add("Frecuencia Esperada");
            tabla2.Columns.Add("PO");
            tabla2.Columns.Add("PE");
            tabla2.Columns.Add("PO(ac)");
            tabla2.Columns.Add("PE(ac)");
            tabla2.Columns.Add("| PoAC - PeAC |");
            tabla2.Columns.Add("max(| PoAC - PeAC |)");

        }

        private void btnGenerar_Click(object sender, EventArgs e)
        {
            tomarEntrada();
            if (n <= 0) { MessageBox.Show("El tamaño de la muestra debe ser mayor a 0..."); }
            if (n > 0)
            {
                tablaAleatorios.Clear();
                tabla2.Clear();
                generarAleatorios();
                
            }
        }

        private float truncarDecimales(double numero)
        {
            int factor = 10000;
            return (float)Math.Truncate(factor * numero) / factor;
        }
        private double max(double a,double b)
        {
            if (a >= b)
            {
                return a;
            }
            return b;
        }

        private void generarAleatorios()
        {
            inicioIntervalos = new float[cantidadIntervalos];
            finIntervalos = new float[cantidadIntervalos];
            GeneradorIntervalosUniforme intervalos = new GeneradorIntervalosUniforme(truncador);

            intervalos.generarIntervalos(cantidadIntervalos);
            inicioIntervalos = intervalos.obtenerInicioIntervalos();
            finIntervalos = intervalos.obtenerFinIntervalos();

            ContadorFrecuenciaObservada contador = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            IGenerador generador = new GeneradorUniformeLenguaje(tablaAleatorios, truncador);
            generador.generarSerie(n, contador);

            grdResultados.DataSource = tablaAleatorios;
            frecuenciasObservadas = contador.obtenerFrecuencias();
        }

        private void construirTabla()
        {
            tabla2.Clear();
            DataRow row;
            float frecuenciaEsperada = truncador.truncar((double)n / (double)cantidadIntervalos);
            float probabilidadObservada;
            float probabilidadEsperada = truncarDecimales(1.0f / cantidadIntervalos);
            double esperadaAcumuladaAnterior = 0;
            double observadaAcumuladaAnterior = 0;
            double maximo = 0;

            for (int i=0; i < cantidadIntervalos; i++)
            {


                row = tabla2.NewRow();
                row[0] = "[" + inicioIntervalos[i] + "-" + finIntervalos[i] + "]";
                row[1] = frecuenciasObservadas[i];
                row[2] = frecuenciaEsperada;

                probabilidadObservada = truncarDecimales((double)frecuenciasObservadas[i] / n);
                row[3] = probabilidadObservada;
                row[4] = probabilidadEsperada;

                row[5] = truncador.truncar(observadaAcumuladaAnterior + probabilidadObservada);
                observadaAcumuladaAnterior += probabilidadObservada;

                row[6] = truncador.truncar(esperadaAcumuladaAnterior + probabilidadEsperada);
                esperadaAcumuladaAnterior += probabilidadEsperada;

                double diferencia = Math.Abs(observadaAcumuladaAnterior - esperadaAcumuladaAnterior);
                row[7] = truncador.truncar(diferencia);
                
                if (i == 0)
                {
                    maximo = diferencia;
                }
                else
                {
                    maximo = max(maximo,diferencia);
                }
                row[8] = truncador.truncar(maximo);

                tabla2.Rows.Add(row);
            }
            txtCalculado.Text = truncador.truncar(maximo).ToString();
            grdResultados2.DataSource = tabla2;
        }

        
        public void mostrarGrafico()
        {
            graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = frecuenciasObservadas;
           //graficador.nombre = gbDistribuciones.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            graficador.Show();
        }

        public void evaluarHipotesis()
        {
            txtGradosLibertad.Text = n.ToString();
            double tabulado = (1.36f / Math.Sqrt(n));
            txtProbabilidad.Text = tabulado.ToString();

            double calculado = double.Parse(txtCalculado.Text);

            if (calculado <= tabulado)
            {
                lblResultadoHipotesis.Text = "Con un nivel de significancia de 0,05 NO se rechaza la hipotesis nula";
            }
            else
            {
                lblResultadoHipotesis.Text = "Con un nivel de significancia de 0,05 se rechaza la hipotesis nula";
            }
        }

        
        private void tomarEntrada()
        {
            n = int.Parse(tamanioMuestra.Text);
            if (rb5.Checked) { cantidadIntervalos = int.Parse(rb5.Text); }
            if (rb10.Checked) { cantidadIntervalos = int.Parse(rb10.Text); }
            if (rb15.Checked) { cantidadIntervalos = int.Parse(rb15.Text); }
            if (rb20.Checked) { cantidadIntervalos = int.Parse(rb20.Text); }
        }

        private String tabla1ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in tablaAleatorios.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }
        private String tabla2ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in tabla2.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString()).Append("\t").Append(row[2].ToString()).Append("\t").Append(row[3].ToString()).Append("\t").Append(row[4].ToString()).Append("\t").Append(row[5].ToString()).Append("\t").Append(row[6].ToString()).Append("\t").Append(row[7].ToString()).Append("\t").Append(row[8].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tabla1ToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tabla2ToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            mostrarGrafico();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            construirTabla();
            evaluarHipotesis();
        }
    }
}
