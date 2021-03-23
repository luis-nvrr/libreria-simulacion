using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class FrecuenciaEsperadaUniforme
    {
        private int[] frecuenciaEsperada;

        private int cantidadNumeros;
        private int cantidadIntervalos;

        private float[] inicioIntervalos;
        private float[] finIntervalos;

        public FrecuenciaEsperadaUniforme(int cantidadNumeros, float[] inicioIntervalos, float[] finIntervalos)
        {
            this.cantidadNumeros = cantidadNumeros;
            this.cantidadIntervalos = inicioIntervalos.Length;
            this.frecuenciaEsperada = new int[cantidadIntervalos];
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
        }

        private void generarFrecuencia()
        {
            for (int i = 0; i < frecuenciaEsperada.Length; i++)
            {
                frecuenciaEsperada[i] = cantidadNumeros / cantidadIntervalos;
            }
        }

        public int[] obtenerFrecuencias() {
            generarFrecuencia();
            return frecuenciaEsperada; 
        }

        public string mostrarFrecuencias()
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
