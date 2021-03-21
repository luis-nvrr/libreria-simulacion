using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorCongruencialLineal
    {
        // para la cantidad de decimales de los aleatorios
        private Truncador truncador;

        private long entradaAnterior;
        private long entradaActual;
        private double aleatorioActual;
        private float aleatorioActualTruncado;

        // parametros
        private int c;
        private int a;
        private long m;

        public GeneradorCongruencialLineal(Truncador truncador, long semilla, int c, int a, long m)
        {
            this.entradaAnterior = semilla;
            this.truncador = truncador;
            this.a = a;
            this.c = c;
            this.m = m;
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            entradaActual = ((a * entradaAnterior) + c) % (m);
            aleatorioActual = (double)entradaActual / (m - 1); // (m-1) para incluir el 1 
            entradaAnterior = entradaActual;
            return truncador.truncar(aleatorioActual);
        }

        public float[] generarSerie(int cantidadAleatorios)
        {
            float[] serieAleatorios = new float[cantidadAleatorios];
            for (int i = 0; i < cantidadAleatorios; i++)
            {
                serieAleatorios[i] = siguienteAleatorio();
            }
            return serieAleatorios;
        }



    }
}
