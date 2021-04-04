using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class ValorCriticoChi2
    {
        public static float[] tabla = new float[] { 0f, 3.84f, 5.99f, 7.81f, 9.49f, 11.1f, 12.6f, 14.1f, 15.5f, 16.9f,
                                18.3f, 19.7f, 21.0f, 22.4f, 23.7f, 25.0f, 26.3f, 27.6f, 28.9f,
                                30.1f, 31.4f, 32.7f, 33.9f, 35.2f, 36.4f, 37.7f, 38.9f, 40.1f,
                                41.3f, 42.6f, 43.8f};
        public static float obtenerValorCritico(int gradosLibertad)
        {
            return tabla[gradosLibertad];
        }
    }
}
