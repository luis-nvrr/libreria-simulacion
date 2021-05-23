using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Colas
{
    class VentanillaInforme
    {
        string LIBRE = "libre";
        string OCUPADO = "ocupado";

        public int cola { get; set; }
        public string estado { get; set; }
        public  double finInforme { get; set; }


        public VentanillaInforme()
        {
            this.finInforme = -1;
        }

        public void agregarFinInforme(double fin)
        {
                finInforme = fin;
                return;
        }


        public Boolean tieneCola()
        {
            return cola > 0;
        }

        public Boolean tieneFinInforme()
        {
            return finInforme != -1;
        }

        public void noGenerarFinInforme()
        {
            this.finInforme = -1;
        }
    }
}
