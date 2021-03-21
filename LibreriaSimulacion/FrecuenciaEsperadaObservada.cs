using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{

    class FrecuenciaEsperadaObservada
    {
        // para generar numeros aleatorios
        Random random; // se deberia cambiar dependiendo de la distribucion pedida

        // par truncar
        Truncador truncador;

        // parametros
        private int CANTIDAD_DECIMALES = 4;
        private int cantidadNumeros;
        private int cantidadIntervalos;

        // arreglos paralelos:
        private float[] inicioIntervalos; // inicio de cada intervalo
        private float[] finIntervalos; // inicio de cada intervalo

        private int[] frecuenciaObservada; // 
        private int[] frecuenciaEsperada;
        //


        // cantidadNumeros: cantidad de aleatorios a generar
        // cantidadIntervalos: cantidad de intervalos en los que dividir la serie
        // cantidadDecimales: cantidad de decimales de los numeros aleatorios
        public FrecuenciaEsperadaObservada(int cantidadNumeros, int cantidadIntervalos, int cantidadDecimales)
        {
            this.cantidadNumeros = cantidadNumeros;
            this.cantidadIntervalos = cantidadIntervalos;
            this.CANTIDAD_DECIMALES = cantidadDecimales;
            this.random = new Random();
            this.truncador = new Truncador(4);
        }

        public int[][] generar()
        {
            generarIntervalos();
            generarSerie();
            int[][] matrizFrecuencias = new int[][] { frecuenciaObservada, frecuenciaObservada };
            return matrizFrecuencias;
        }

        // genera numeros aleatorios y los cuenta a medida que los genera
        private void generarSerie()
        {
            random = new Random();

            for (int i = 0; i < cantidadNumeros; i++)
            {
                double nro = random.NextDouble();
                float aleatorioTruncado = truncador.truncar(nro);
                contarNumero(aleatorioTruncado);
            }
        }

        private void generarIntervalos()
        {
            inicioIntervalos = new float[cantidadIntervalos];
            finIntervalos = new float[cantidadIntervalos];

            float rangoIntervalo = calcularRangoIntervalos();
            
            // para la primer iteracion
            float inicioActual = 0;
            float finActual = rangoIntervalo;

            // para calcular el siguiente inicio
            float rangoInicio = 1f / cantidadIntervalos;

            // auxiliar para calcular el proximo fin
            double auxiliar = 0;

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                inicioIntervalos[i] = inicioActual;
                finIntervalos[i] = finActual;

                // actualiza para la siguiente iteracion
                auxiliar += rangoInicio;
                inicioActual = (float)Math.Round(auxiliar, 2);
                finActual = truncador.truncar(auxiliar + rangoIntervalo);

                // conteo de frecuencia esperada, solo valido para distribucion UNIFORME
                frecuenciaEsperada[i] = cantidadNumeros / cantidadIntervalos;
            }
        }

        // recorre los arreglos paralelos de inicio y fin de intervalo para determinar donde
        // pertenece el numero pasado como parametro, y lo cuenta
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
       
        // calcula el rango de cada intervalo, de acuerdo a la cantidad de intervalos
        private float calcularRangoIntervalos()
        {
            return (float)((1.0f / cantidadIntervalos) - (1.0f / Math.Pow(10, CANTIDAD_DECIMALES)));
        }

        // genera una string con los intervalos
        private void mostrarIntervalos()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i].ToString() + " " + finIntervalos[i].ToString();
                res += "\n";
            }
        }

        // genera una string con el estado de las frecuencias observadas;
        private void mostrarFrecuenciasObservadas()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + frecuenciaObservada[i].ToString();
                res += "\n";
            }
        }


    }
}
