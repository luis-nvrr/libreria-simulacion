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
        double anterior = 0;
        int indice = -1;
        int n;
        Random aletorio;
        int cantIntervalo;
        float[] numerosAleatorios;
        int[] intervalos;
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
            aletorio = new Random();
            n = int.Parse(txtCantidadNumero.Text);
            cantIntervalo = int.Parse(txtCantidadIntervalo.Text);
            numerosAleatorios = new float[n];
            for (int i = 0; i < n; i++)
            {
                float truncado = truncarDecimales(aletorio.NextDouble());
                numerosAleatorios[i] = truncado;
                agregarFila(truncado);
            }
        }
        private void calcularFrecuenciaObservada()
        {
            intervalos = new int[cantIntervalo];
            double longitudIntervalo = 1.0 / intervalos.Length;
            double res = longitudIntervalo;

            for (int i = 0; i < intervalos.Length; i++)  
            {
                for(int j = 0; j < numerosAleatorios.Length; j++)  
                {
                    if ((numerosAleatorios[j] >= (longitudIntervalo * (i))) &&
                       (numerosAleatorios[j] < longitudIntervalo * (1 + i)))
                    {
                        intervalos[i] += 1;
                    }
                }
            }

            for (int i = 0; i < intervalos.Length; i++)
            {
                string intervalo = "[" + anterior + "; " + longitudIntervalo + "]";
                grdResultados2.Rows.Add();
                grdResultados2.Rows[i].Cells[0].Value = intervalo;
                grdResultados2.Rows[i].Cells[1].Value = intervalos[i];
                anterior = longitudIntervalo;
                longitudIntervalo += res;

            }
            enfocarFila();
        }

        private void calcularFrecuenciaEsperada()
        {
            float frecuenciaEsperada = (float) n / cantIntervalo;
            for (int i = 0; i < intervalos.Length; i++)
            {
                grdResultados2.Rows[i].Cells[2].Value = frecuenciaEsperada;
            }
            enfocarFila();
        }

        public void calcularEstadisticaPrueba() 
        {
            for (int i = 0; i < grdResultados2.RowCount; i++)
            {
                int frecuenciaEsperada = n / cantIntervalo;
                string frecuenciaObservada = grdResultados2.Rows[i].Cells[1].Value.ToString();
                int frecuenciaObservadas = int.Parse(frecuenciaObservada);
                float c = (float) ((frecuenciaEsperada - frecuenciaObservadas) ^ 2) / frecuenciaEsperada;
                grdResultados2.Rows[i].Cells[3].Value = c;
            }
            enfocarFila();
        }

        public void calcularEstadisticaPruebaAcumulada()
        {
            float estadisticaPruebaAcumulada = 0;
            for (int i = 0; i < grdResultados2.RowCount; i++)
            {  
                string estadisticaPrueba = grdResultados2.Rows[i].Cells[3].Value.ToString();
                estadisticaPruebaAcumulada += float.Parse(estadisticaPrueba);
                grdResultados2.Rows[i].Cells[4].Value = estadisticaPruebaAcumulada;
            }
        }

        public void evaluarHipotesis()
        {
            int v = cantIntervalo - 1 + n;
            txtGradosLibertad.Text = v.ToString();
            double probabilidad = jiCuadrado[v];
            txtProbabilidad.Text = probabilidad.ToString();
            if (double.Parse(grdResultados2.Rows[cantIntervalo - 1].Cells[4].Value.ToString()) < probabilidad) 
            {
                lblResultadoHipotesis.Text = "Se acepta la hipótesis nula";
            }
            else
            {
                lblResultadoHipotesis.Text = "Se rechaza la hipótesis nula";
            }

        }
        private void btn_Generar_Click(object sender, EventArgs e)
        {
            generarNumerosAleatorios();
            calcularFrecuenciaObservada();
            calcularFrecuenciaEsperada();
            calcularEstadisticaPrueba();
            calcularEstadisticaPruebaAcumulada();
            evaluarHipotesis();
        }
    }
}
