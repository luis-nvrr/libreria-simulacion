using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorIntervalosUniformeAB
    {
        private int cantidadIntervalos;

        private float[] inicioIntervalos; // inicio de cada intervalo
        private float[] finIntervalos; // inicio de cada intervalo

        Truncador truncador;

        public GeneradorIntervalosUniformeAB(Truncador truncador)
        {
            this.truncador = truncador;
        }

        public void generarIntervalos(int cantidadIntervalos, float a , float b)
        {
            this.cantidadIntervalos = cantidadIntervalos;
            inicioIntervalos = new float[cantidadIntervalos];
            finIntervalos = new float[cantidadIntervalos];

            double rangoIntervalo = calcularRangoIntervalos(a, b);
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                inicioIntervalos[i] = truncador.truncar(a + rangoIntervalo * i);
                finIntervalos[i] = truncador.truncar(a + rangoIntervalo * (i + 1) - 0.0001f);
            }
        }


        // calcula el rango de cada intervalo, de acuerdo a la cantidad de frecuenciaObservada
        private double calcularRangoIntervalos(float a, float b)
        {
            return ((double)(b-a) / cantidadIntervalos);
        }

        public float[] obtenerInicioIntervalos()
        {
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
