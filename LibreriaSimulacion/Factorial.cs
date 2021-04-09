using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class Factorial
    {
        public static long factorial(int number)
        {
            int i;
            long fact = 1;

            for (i = 1; i <= number; i++)
            {
                fact = fact * i;
            }

            return fact;
        }
    }
}
