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

namespace Numeros_aleatorios.Pruebas_de_bondad
{
    public partial class Prueba : Form
    {
        int indice = -1;
        int n;

        Random random;
        DataTable tabla1;
        DataTable tabla2;

        float[] inicioIntervalos;
        float[] finIntervalos;
        int cantIntervalo;
        int[] frecuenciaObservada;
        // se justifica 95 de nivel de confianza porque la clase Random genera distribucion uniforme
        double[] jiCuadrado = { 0, 3.84, 5.99, 7.81, 9.49, 11.1, 12.6, 14.1, 15.5, 16.9, 
                                18.3, 19.7, 21.0, 22.4, 23.7, 25.0, 26.3, 27.6, 28.9,
                                30.1, 31.4, 32.7, 33.9, 35.2, 36.4, 37.7, 38.9, 40.1, 
                                41.3, 42.6, 43.8};
        double estadisticoPruebaAcumuladoAnterior;
        public Prueba()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            random = new Random();
            tabla1 = new DataTable();
            tabla2 = new DataTable();

            tabla1.Columns.Add("Iteración");
            tabla1.Columns.Add("Número Aleatorio");
            tabla2.Columns.Add("Intervalo");
            tabla2.Columns.Add("Frecuencia Observada");
            tabla2.Columns.Add("Frecuencia Esperada");
            tabla2.Columns.Add("C");
            tabla2.Columns.Add("C (ac)");

        }

        private float truncarDecimales(double numero)
        {
            int factor = 10000;
            return (float)Math.Truncate(factor * numero) / factor;
        }
       
        public void generarNumerosAleatorios()
        {
            grdResultados.Rows.Clear();
            grdResultados2.Rows.Clear();

            tabla1.Rows.Clear();
            tabla2.Rows.Clear();

            indice = -1;

            tomarEntrada();
           
            frecuenciaObservada = new int[cantIntervalo];

            double longitudIntervalo = 1.0f / frecuenciaObservada.Length;
            float inicioIntervalo;
            float finIntervalo;

            string intervalo;
            float frecuenciaEsperada = (float)n / cantIntervalo;

            inicioIntervalos = new float[cantIntervalo];
            finIntervalos = new float[cantIntervalo];
            
            DataRow filaTabla1;
            DataRow filaTabla2;
            // genera aleatorios y se fija en que intervalo pertenece
            for (int i = 0; i < cantIntervalo; i++)
            {
                filaTabla2 = tabla2.NewRow();
                tabla2.Rows.Add(filaTabla2);
            }


            for (int i = 0; i < n; i++)
            {

                float truncado = truncarDecimales(random.NextDouble());
                filaTabla1 = tabla1.NewRow();
                filaTabla1[0] = i + 1;
                filaTabla1[1] = truncado;
                tabla1.Rows.Add(filaTabla1);
                
                for (int j = 0; j < frecuenciaObservada.Length; j++)
                {
                    inicioIntervalo = truncarDecimales(longitudIntervalo * j);
                    finIntervalo = truncarDecimales(longitudIntervalo * (1 + j) - 0.0001f);
                    inicioIntervalos[j] = inicioIntervalo;
                    finIntervalos[j] = finIntervalo;


                    if (truncado >= inicioIntervalo &&
                           truncado <= finIntervalo)
                    {
                        estadisticoPruebaAcumuladoAnterior = 0;

                        if (j != 0 && tabla2.Rows[j-1][4].ToString() != "")
                        {
                            estadisticoPruebaAcumuladoAnterior = double.Parse(tabla2.Rows[j - 1][4].ToString());
                        }
                        intervalo = "[" + inicioIntervalo + "; " + finIntervalo + "]";
                        frecuenciaObservada[j] += 1;
                        

                        // agrega fila y columnas de frecuencias esperadasa y observadas
             
                        tabla2.Rows[j][0] = intervalo;
                        tabla2.Rows[j][1] = frecuenciaObservada[j];
                        tabla2.Rows[j][2] = frecuenciaEsperada;

                        float c = truncarDecimales(Math.Pow((frecuenciaEsperada - frecuenciaObservada[j]), 2) / frecuenciaEsperada);
                        tabla2.Rows[j][3] = c;
                        tabla2.Rows[j][4] = truncarDecimales(double.Parse(tabla2.Rows[j][3].ToString()) + estadisticoPruebaAcumuladoAnterior);
                        //MessageBox.Show(estadisticoPruebaAcumuladoAnterior.ToString());
                        break;
                    }
                }
            }
            grdResultados.DataSource = tabla1;
            grdResultados2.DataSource = tabla2;
        }


        public void evaluarHipotesis()
        {
            int v = cantIntervalo - 1 ; // m=0 porque no hubo observacion
            txtGradosLibertad.Text = v.ToString();
            double probabilidad = jiCuadrado[v];
            txtProbabilidad.Text = probabilidad.ToString();
            if (double.Parse(tabla2.Rows[cantIntervalo - 1][4].ToString()) <= probabilidad) 
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
            graficador.frecuenciaObservada = frecuenciaObservada;
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            graficador.Show();
        }
        
        private void btnGenerar_Click(object sender, EventArgs e)
        {
            generarNumerosAleatorios();
            mostrarGrafico();
            evaluarHipotesis();
        }
        private void tomarEntrada()
        {
            n = int.Parse(tamanioMuestra.Text);
            if (rb5.Checked) { cantIntervalo = int.Parse(rb5.Text); }
            if (rb10.Checked) { cantIntervalo = int.Parse(rb10.Text); }
            if (rb15.Checked) { cantIntervalo = int.Parse(rb15.Text); }
            if (rb20.Checked) { cantIntervalo = int.Parse(rb20.Text); }
        }

        public String tabla1ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in tabla1.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        public String tabla2ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in tabla1.Rows)
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
    }
}
