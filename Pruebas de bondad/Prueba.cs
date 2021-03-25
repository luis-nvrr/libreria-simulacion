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

        Random aletorio;
        GraficadorExcelObservado graficador;

        int cantIntervalo;
        int[] frecuenciaObservada;
        // se justifica 95 de nivel de confianza porque la clase Random genera distribucion uniforme
        double[] jiCuadrado = { 0, 3.84, 5.99, 7.81, 9.49, 11.1, 12.6, 14.1, 15.5, 16.9, 
                                18.3, 19.7, 21.0, 22.4, 23.7, 25.0, 26.3, 27.6, 28.9,
                                30.1, 31.4, 32.7, 33.9, 35.2, 36.4, 37.7, 38.9, 40.1, 
                                41.3, 42.6, 43.8};

        public Prueba()
        {
            InitializeComponent();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private float truncarDecimales(double numero)
        {
            int factor = 10000;
            return (float)Math.Truncate(factor * numero) / factor;
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

        private void generarNumerosAleatorios()
        {
            grdResultados.Rows.Clear();
            grdResultados2.Rows.Clear();

            indice = -1;
            aletorio = new Random();


            n = int.Parse(txtCantidadNumero.Text);
            cantIntervalo = int.Parse(txtCantidadIntervalo.Text);
            frecuenciaObservada = new int[cantIntervalo];

            double longitudIntervalo = 1.0f / frecuenciaObservada.Length;
            float inicioIntervalo;
            float finIntervalo;

            string intervalo;


            // genera aleatorios y se fija en que intervalo pertenece

            for (int i = 0; i < cantIntervalo; i++)
            {
                grdResultados2.Rows.Add();
            }


            for (int i = 0; i < n; i++)
            {
                    float truncado = truncarDecimales(aletorio.NextDouble());
                    agregarFila(truncado);

                for (int j = 0; j < frecuenciaObservada.Length; j++)
                {
                    inicioIntervalo = truncarDecimales(longitudIntervalo * j);
                    finIntervalo = truncarDecimales(longitudIntervalo * (1 + j) - 0.0001f);

                    if (truncado >= inicioIntervalo &&
                           truncado < finIntervalo)
                    {
                        intervalo = "[" + inicioIntervalo + "; " + finIntervalo + "]";
                        frecuenciaObservada[j] += 1;

                        // agrega fila y columnas de frecuencias esperadasa y observadas
             
                        grdResultados2.Rows[j].Cells[0].Value = intervalo;
                        grdResultados2.Rows[j].Cells[1].Value = frecuenciaObservada[j];
                        
                        break;
                    }
                }
            }
        }


        public void calcularFrecuenciaEsperada()
        {
            float frecuenciaEsperada = (float)n / cantIntervalo;

            for (int i = 0; i < frecuenciaObservada.Length; i++)
            {
            grdResultados2.Rows[i].Cells[2].Value = frecuenciaEsperada;
            }
        }

        public void calcularEstadisticaPrueba() 
        {
            int frecuenciaEsperada = n / cantIntervalo;
            float estadisticaPruebaAcumulada = 0;
            for (int i = 0; i < grdResultados2.RowCount; i++)
            {
                string frecuenciaObservada = grdResultados2.Rows[i].Cells[1].Value.ToString();
                int frecuenciaObservadas = int.Parse(frecuenciaObservada);
                float c = (float) Math.Pow((frecuenciaEsperada - frecuenciaObservadas),2)  / frecuenciaEsperada;
                grdResultados2.Rows[i].Cells[3].Value = c;

                // calculo de estadistica de prueba acumulada
                string estadisticaPrueba = grdResultados2.Rows[i].Cells[3].Value.ToString();
                estadisticaPruebaAcumulada += float.Parse(estadisticaPrueba);
                grdResultados2.Rows[i].Cells[4].Value = estadisticaPruebaAcumulada;
            }
            enfocarFila();
        }


        public void evaluarHipotesis()
        {
            int v = cantIntervalo - 1 ; // m=0 porque no hubo observacion
            txtGradosLibertad.Text = v.ToString();
            double probabilidad = jiCuadrado[v];
            txtProbabilidad.Text = probabilidad.ToString();
            if (double.Parse(grdResultados2.Rows[cantIntervalo - 1].Cells[4].Value.ToString()) < probabilidad) 
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
            graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = frecuenciaObservada;
            graficador.Show();
        }

        

        private void btn_Generar_Click(object sender, EventArgs e)
        {
            generarNumerosAleatorios();
            mostrarGrafico();
            calcularFrecuenciaEsperada();
            calcularEstadisticaPrueba();
            evaluarHipotesis();
        }
    }
}
