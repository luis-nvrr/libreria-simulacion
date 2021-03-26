using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios
{
    interface IGenerador
    {

        float siguienteAleatorio();
        float[] generarSerie(int cantidadAleatorios);
    }
}
