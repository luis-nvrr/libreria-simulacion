using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Colas
{
    class Caja
    {
        string LIBRE = "libre";
        string OCUPADO = "ocupado";

        public string estado { get; set; }
        public double finCobro { get; set; }

        public int id;


        public Caja(int id)
        {
            this.estado = LIBRE;
            this.id = id;
        }

        public Boolean estaLibre()
        {
            return this.estado.Equals(LIBRE);
        }

        public void agregarFinCobro(double fin)
        {
            this.finCobro = fin;
            this.estado = OCUPADO;
        }

        public void liberar()
        {
            this.estado = LIBRE;
        }
    }
}
