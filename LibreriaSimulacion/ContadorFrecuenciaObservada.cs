using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{

    class ContadorFrecuenciaObservada
    {
        private int[] frecuenciaObservada;

        private int cantidadIntervalos;

        private float[] inicioIntervalos;
        private float[] finIntervalos;

        public ContadorFrecuenciaObservada(float[] inicioIntervalos, float[] finIntervalos)
        {
            this.cantidadIntervalos = inicioIntervalos.Length;
            this.frecuenciaObservada = new int[cantidadIntervalos];
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
        }
        public void contarNumero(float numero)
        {
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                if (numero >= inicioIntervalos[i] && numero <= finIntervalos[i])
                {
                    frecuenciaObservada[i] += 1;
                }
            }
        }

        public int[] obtenerFrecuencias()
        {
            return frecuenciaObservada;
        }


        public string mostrarFrecuencias()
        {
            string res = " ";
            for (int i = 0; i < cantidadIntervalos; i++)
            {
                res += inicioIntervalos[i] + " " + finIntervalos[i] + "=" + frecuenciaObservada[i].ToString();
                res += "\n";
            }
            return res;
        }
    }
}
