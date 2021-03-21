using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.ejemplo_grafico
{
    public partial class Prueba_Grafico_Generador : Form
    {
        int CANTIDAD_DECIMALES = 4;
        Random random;

        int cantidadNumeros;
        int cantidadIntervalos;

        float[] inicioIntervalos; // inicio de cada intervalo
        float[] finIntervalos; // inicio de cada intervalo

        int[] frecuenciaObservada; //
        int[] frecuenciaEsperada;

        EjemploGrafico graficador;

        public Prueba_Grafico_Generador()
        {
            InitializeComponent();
        }

        private void Prueba_Grafico_Generador_Load(object sender, EventArgs e)
        {
            cantidadNumeros = 100;  //entrada
            cantidadIntervalos = 5; // entrada 

            frecuenciaObservada = new int[cantidadIntervalos];
            frecuenciaEsperada = new int[cantidadIntervalos];

            generarIntervalos();
            mostrarIntervalos();
            generarSerie();
            mostrarContador();

            graficador = new EjemploGrafico();
            graficador.DataValues = frecuenciaObservada;
            graficador.frecuenciaEsperada = frecuenciaEsperada;

            graficador.cantidadIntervalos = cantidadIntervalos;
            graficador.cantidadNumeros = cantidadNumeros;
            graficador.ShowDialog();
        }

        private void generarSerie()
        {
            random = new Random();

            for (int i = 0; i < cantidadNumeros; i++)
            {
                double nro = random.NextDouble();
                float aleatorioTruncado = truncarDecimales(nro);
                contarNumero(aleatorioTruncado);
            }
        }
        
        private float truncarDecimales(double numero)
        {
            int factor = (int)Math.Pow(10, CANTIDAD_DECIMALES);
            return (float)Math.Truncate(factor * numero) / factor;
        }

        private void contarNumero(float numero)
        {
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                if (numero >= inicioIntervalos[i] && numero <= finIntervalos[i])
                {
                    frecuenciaObservada[i] += 1;
                }
            }
        }

        private void generarIntervalos()
        {
            inicioIntervalos = new float[cantidadIntervalos];
            finIntervalos = new float[cantidadIntervalos];

            float rangoIntervalo = calcularRangoIntervalos();
            float inicioActual = 0;
            float finActual = rangoIntervalo;
            float rangoInicio = 1f / cantidadIntervalos;
            double auxiliar = 0;

            MessageBox.Show(rangoIntervalo.ToString());
            for(int i=0; i<cantidadIntervalos; i++)
            {
                inicioIntervalos[i] = inicioActual;
                finIntervalos[i] = finActual;
                auxiliar += rangoInicio;
                inicioActual = (float) Math.Round(auxiliar,2);
                finActual = truncarDecimales(auxiliar + rangoIntervalo);
                frecuenciaEsperada[i] = cantidadNumeros / cantidadIntervalos;
            }
        }

        private float calcularRangoIntervalos() {
            return (float)((1.0f / cantidadIntervalos) - (1.0f / Math.Pow(10, CANTIDAD_DECIMALES)));
        }

        private void mostrarIntervalos()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i].ToString() + " " + finIntervalos[i].ToString();
                res += "\n";
            }
            MessageBox.Show(res);
        }

        private void mostrarContador()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + frecuenciaObservada[i].ToString();
                res += "\n";
            }
            MessageBox.Show(res);
        }
    }
}
