using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorUniformeLenguaje
    {
        Random random;
        Truncador truncador;

        public GeneradorUniformeLenguaje(Truncador truncador)
        {
            this.random = new Random();
            this.truncador = truncador;
        }

        public float siguientAleatorio()
        {
            return truncador.truncar(random.NextDouble());
        }

    }
}
