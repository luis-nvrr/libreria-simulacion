using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Colas
{
    class Cliente
    {
        String ESPERANDO_CAJA = "EAC";
        String ESPERANDO_INFORME = "EAI";
        String ESPERANDO_ACTUALIZACION = "EAA";
        String SIENDO_ATENDIDO_CAJA = "SAC";
        String SIENDO_ATENDID_ACTUALIZACION = "SAA";
        String SIENDO_ATENDIDO_INFORME = "SAI";

        public String estado;
        public long horaEsperaEnCaja;
        public long horaLlegada;
        public long  id;


        public void esperarInforme()
        {
            this.estado = ESPERANDO_INFORME;
        }

        public void limpiar()
        {
            estado = "";
            horaEsperaEnCaja = -1;
        }

        public Boolean estaLibre()
        {
            return this.estado == "";
        }

        public void esperarActualizacion()
        {
            this.estado = ESPERANDO_ACTUALIZACION;
        }

        public void atenderActualizacion()
        {
            this.estado = SIENDO_ATENDID_ACTUALIZACION;
        }

        public void atenderInforme()
        {
            this.estado = SIENDO_ATENDIDO_INFORME;
        }

        public void atenderCaja()
        {
            this.estado = SIENDO_ATENDIDO_CAJA;
        }

        public void esperarCaja()
        {
            this.estado = ESPERANDO_CAJA;
        }
    }
}
