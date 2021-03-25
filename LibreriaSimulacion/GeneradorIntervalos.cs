using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorIntervalos
    {
        private int cantidadIntervalos;
        private int CANTIDAD_DECIMALES = 4;


        // arreglos paralelos:
        private float[] inicioIntervalos; // inicio de cada intervalo
        private float[] finIntervalos; // inicio de cada intervalo

        Truncador truncador;

        public GeneradorIntervalos(Truncador truncador)
        {
            this.truncador = truncador;
        }

        public void generarIntervalos(int cantidadIntervalos)
        {
            this.cantidadIntervalos = cantidadIntervalos;

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


        // calcula el rango de cada intervalo, de acuerdo a la cantidad de frecuenciaObservada
        private float calcularRangoIntervalos()
        {
            return (float)((1.0f / cantidadIntervalos) - (1.0f / Math.Pow(10, CANTIDAD_DECIMALES)));
        }

        public float[] obtenerInicioIntervalos() {
            return inicioIntervalos;
        }

        public float[] obtenerFinIntervalos()
        {
            return finIntervalos;
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
    }
}
