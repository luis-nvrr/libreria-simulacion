using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorUniformeAB : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorUniforme;

        private float aleatorio01;

        // parametros
        private float b;
        private float a;

        public GeneradorUniformeAB(Truncador truncador, double a, double b)
        {
            this.truncador = truncador;
            this.a = truncador.truncar(a);
            this.b = truncador.truncar(b);
            this.generadorUniforme = new GeneradorUniformeLenguaje(truncador);
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            aleatorio01 = generadorUniforme.siguienteAleatorio();
            return truncador.truncar(a + aleatorio01 * (b - a));
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
