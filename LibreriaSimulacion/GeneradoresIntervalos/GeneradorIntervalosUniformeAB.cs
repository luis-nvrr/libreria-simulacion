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

            decimal rangoIntervalo = calcularRangoIntervalos(a, b);

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                decimal inicio = (decimal)a + rangoIntervalo * i;
                decimal fin = (decimal)a + rangoIntervalo * (i + 1);
                fin -= (decimal)0.0001; 
                inicioIntervalos[i] = truncador.truncarDecimal(inicio);
                finIntervalos[i] = truncador.truncarDecimal(fin);
            }
        }


        // calcula el rango de cada intervalo, de acuerdo a la cantidad de contador
        private decimal calcularRangoIntervalos(float a, float b)
        {
            return ((decimal)(b-a) / cantidadIntervalos);
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
