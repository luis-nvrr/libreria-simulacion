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

        Random random;
        int cantidadNumeros;
        int cantidadIntervalos;
        int CANTIDAD_DECIMALES = 4;
        float[] inicioIntervalos; // inicio de cada intervalo
        float[] finIntervalos; // inicio de cada intervalo
        int[] contador; //
        EjemploGrafico graficador;

        public Prueba_Grafico_Generador()
        {
            InitializeComponent();
        }

        private void Prueba_Grafico_Generador_Load(object sender, EventArgs e)
        {
            cantidadNumeros = 100;
            cantidadIntervalos = 20;
            generarIntervalos();
            mostrarIntervalos();
            generarSerie();
            mostrarContador();

            graficador = new EjemploGrafico();
            graficador.DataValues = contador;
            graficador.rangeValuesStart = inicioIntervalos;
            graficador.rangeValuesEnd = finIntervalos;
            graficador.cantidadIntervalos = cantidadIntervalos;
            graficador.cantidadNumeros = cantidadNumeros;
            graficador.ShowDialog();
        }

        private void generarSerie()
        {
            random = new Random();

            for (int i = 0; i <= cantidadNumeros; i++)
            {
                double nro = random.NextDouble();
                float aleatorioTruncado = truncarDecimales(nro);
                contarNumero(aleatorioTruncado);
            }
        }
        
        private float truncarDecimales(double numero)
        {
            int factor = 10000;
            return (float)Math.Truncate(factor * numero) / factor;
        }

        private void contarNumero(float numero)
        {
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                if (numero >= inicioIntervalos[i] && numero <= finIntervalos[i])
                {
                    contador[i] += 1;
                }
            }
        }

        private void generarIntervalos()
        {
            inicioIntervalos = new float[cantidadIntervalos];
            finIntervalos = new float[cantidadIntervalos];
            contador = new int[cantidadIntervalos];

            float rangoIntervalo = calcularRangoIntervalos();
            float inicioActual = 0;
            float finActual = rangoIntervalo;
            float rangoInicio = 1.0f / cantidadIntervalos;
            double auxiliar = 0;
            
            for(int i=0; i<cantidadIntervalos; i++)
            {
                inicioIntervalos[i] = inicioActual;
                finIntervalos[i] = finActual;
                auxiliar += rangoInicio;
                inicioActual = (float) Math.Round(auxiliar,2);
                finActual = truncarDecimales(auxiliar + rangoIntervalo);
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
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + contador[i].ToString();
                res += "\n";
            }
            MessageBox.Show(res);
        }
    }
}
