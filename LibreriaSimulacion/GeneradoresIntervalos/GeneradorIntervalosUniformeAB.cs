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
                double inicio = a + rangoIntervalo * i;
                double fin = a + rangoIntervalo * (i + 1);
                if (inicio < 0 || fin < 0) { 
                    fin += 0.0001f;
                    inicio -= 0.0001f;
                }
                else { fin -= 0.0001f;  }
                inicioIntervalos[i] = truncador.truncar(inicio);
                finIntervalos[i] = truncador.truncar(fin);
            }
        }


        // calcula el rango de cada intervalo, de acuerdo a la cantidad de contador
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
