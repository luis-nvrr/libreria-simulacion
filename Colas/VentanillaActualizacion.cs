using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Colas
{
    class VentanillaActualizacion
    {
        string LIBRE = "libre";
        string OCUPADO = "ocupado";

        public int cola { get; set; }
        public string estado { get; set; }
        public double finActualizacion { get; set; }

        public VentanillaActualizacion()
        {
            this.estado = LIBRE;
            this.finActualizacion = -1;
        }

        public Boolean tieneCola()
        {
            return cola > 0;
        }

        public void agregarFinActualizacion(double tiempo)
        {
            this.finActualizacion = tiempo;
            this.estado = OCUPADO;
        }

        public Boolean tieneFinActualizacion()
        {
            return this.finActualizacion != -1;
        }

        public void noGenerarFinActualizacion()
        {
            this.finActualizacion = -1;
        }

        public double obtenerFinActualizacion()
        {
            return finActualizacion;
        }
    }
}
