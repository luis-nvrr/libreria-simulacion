using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{

    class FrecuenciaEsperadaObservada
    {
        int CANTIDAD_DECIMALES = 4;

        // par truncar
        private Truncador truncador;

        // parametros
        private int cantidadNumeros;
        private int cantidadIntervalos;

        // arreglos paralelos:
        private float[] inicioIntervalos; // inicio de cada intervalo
        private float[] finIntervalos; // inicio de cada intervalo

        private int[] frecuenciaObservada;  
        private int[] frecuenciaEsperada;


        public FrecuenciaEsperadaObservada(int cantidadNumeros, int cantidadIntervalos, Truncador truncador)
        {
            this.cantidadNumeros = cantidadNumeros;
            this.cantidadIntervalos = cantidadIntervalos;
            this.truncador = truncador;
            this.frecuenciaEsperada = new int[cantidadIntervalos];
            this.frecuenciaObservada = new int[cantidadIntervalos];

            generarIntervalos();
        }
        public void contarNumero(float numero)
        {
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                if (numero >= inicioIntervalos[i] && numero <= finIntervalos[i])
                {
                    frecuenciaObservada[i] += 1;
                    frecuenciaEsperada[i] = cantidadNumeros / cantidadIntervalos;
                }
            }
        }

        public int[][] obtenerFrecuencias()
        {
            int[][] matrizFrecuencias = new int[][] { frecuenciaObservada, frecuenciaObservada };
            return matrizFrecuencias;
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
            }
        }

       
        // calcula el rango de cada intervalo, de acuerdo a la cantidad de intervalos
        private float calcularRangoIntervalos()
        {
            return (float)((1.0f / cantidadIntervalos) - (1.0f / Math.Pow(10, CANTIDAD_DECIMALES)));
        }

        public string mostrarIntervalos()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i].ToString() + " " + finIntervalos[i].ToString();
                res += "\n";
            }
            return res;
        }

        public string mostrarFrecuenciasObservadas()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + frecuenciaObservada[i].ToString();
                res += "\n";
            }
            return res;
        }

        public string mostrarFrecuenciasEsperadas()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + frecuenciaEsperada[i].ToString();
                res += "\n";
            }
            return res;
        }


    }
}
