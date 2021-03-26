using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorUniformeLenguaje : IGenerador
    {
        Random random;
        Truncador truncador;

        public GeneradorUniformeLenguaje(Truncador truncador)
        {
            this.random = new Random();
            this.truncador = truncador;
        }

        public float siguienteAleatorio()
        {
            return truncador.truncar(random.NextDouble());
        }

        public float[] generarSerie(int cantidadAleatorios)
        {
            float[] serieAleatorios = new float[cantidadAleatorios];
            for (int i = 0; i < cantidadAleatorios; i++)
            {
                float aleatorio = siguienteAleatorio();
                serieAleatorios[i] = aleatorio;
            }
            return serieAleatorios;
        }


    }
}
