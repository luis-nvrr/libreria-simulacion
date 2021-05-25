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

        public static int tamañoCola;

        public int id;

        public Queue<Cliente> cola;

        public Cliente clienteActual;

        public Caja(int id)
        {
            this.estado = LIBRE;
            this.id = id;
            this.cola = new Queue<Cliente>();
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
            this.finCobro = -1;
            this.estado = LIBRE;
        }

        public static void actualizarCola()
        {
            tamañoCola = tamañoCola > 0 ? tamañoCola - 1 : 0;
        }

        public static void aumentarCola()
        {
           tamañoCola += 1;
        }

        public Cliente getClienteActual()
        {
            return this.clienteActual;
        }
    }
}
