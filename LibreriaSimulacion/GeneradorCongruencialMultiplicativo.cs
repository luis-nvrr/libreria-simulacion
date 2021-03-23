using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorCongruencialMultiplicativo
    {
        // para la cantidad de decimales de los aleatorios
        private Truncador truncador;

        private long entradaAnterior;
        private long entradaActual;
        private double aleatorioActual;
        private float aleatorioActualTruncado;

        // parametros
        private int a;
        private long m;

        public GeneradorCongruencialMultiplicativo(Truncador truncador, long semilla, int a, long m)
        {
            this.entradaAnterior = semilla;
            this.truncador = truncador;
            this.a = a;
            this.m = m;
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            entradaActual = (a * entradaAnterior) % (m);
            aleatorioActual = (double)entradaActual / (m - 1); // (m-1) para incluir el 1 
            entradaAnterior = entradaActual;
            return truncador.truncar(aleatorioActual);
        }

        public float[] generarSerie(int cantidadAleatorios)
        {
            return generarSerie(cantidadAleatorios, null, null);
        }

        public float[] generarSerie(int cantidadAleatorios, FrecuenciaObservada frecuenciaObservada)
        {
            return generarSerie(cantidadAleatorios, frecuenciaObservada, null);
        }

        public float[] generarSerie(int cantidadAleatorios, FrecuenciaObservada frecuenciaObservada, FrecuenciaEsperadaUniforme frecuenciaEsperada)
        {
            float[] serieAleatorios = new float[cantidadAleatorios];
            for (int i = 0; i < cantidadAleatorios; i++)
            {
                float aleatorio = siguienteAleatorio();
                serieAleatorios[i] = aleatorio;
                if (frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
                if (frecuenciaEsperada != null) { frecuenciaEsperada.contarNumero(aleatorio); }

            }
            return serieAleatorios;
        }
    }
}
