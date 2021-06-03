using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Colas
{
    class Linea
    {
        public string LLEGADA_PERSONA = "llegada de persona";
        public string FIN_INFORME = "fin de informe";
        public string FIN_ACTUALIZACION = "fin de actualizacion";
        public string FIN_COBRO = "fin de cobro";

       public IGenerador aleatorios;
       public Truncador truncador;
       public string evento { get; set; }
       public long reloj { get; set; }
       public long llegadaCliente { get; set; }
       public double rndEstadoFactura { get; set; }
       public string estadoFactura { get; set; }
       public double rndConoceProcedimiento { get; set; }
       public string conoceProcedimiento { get; set; }
       public List<Caja> cajas { get; set; }
       public VentanillaActualizacion ventanillaActualizacion { get; set; }
       public VentanillaInforme ventanillaInforme { get; set; }
       public Linea lineaAnterior { get; set; }

        public Caja cajaFinCobro;

        public long colaCaja;

        public List<Cliente> clientes;

        public ColasMunicipalidad colas;
        public Queue<Cliente> clientesLibre;

        public long acumuladorTiemposEsperaEnCaja;
        public long cantidadClientesEsperan;
        public long acumuladorTiempoOcupacionVentanillaInformes;
        public long acumuladorTiempoOciosoVentanillaActualizacion;
        public long tiempoMaximoEsperaEnCola;


        public int idFila;
        private int filaDesde;
        private int filaHasta;

        public Linea(int cantidadCajas)
        {
            this.llegadaCliente = 60;
            this.truncador = new Truncador(4);
            this.aleatorios = new GeneradorUniformeLenguaje(truncador);
            this.ventanillaInforme = new VentanillaInforme();
            this.ventanillaActualizacion = new VentanillaActualizacion();
            this.cajas = new List<Caja>();
            cargarCajas(cantidadCajas);
            this.clientes = new List<Cliente>();
            this.colaCaja = 0;
            this.clientesLibre = new Queue<Cliente>();
            this.rndConoceProcedimiento = -1;
            this.rndEstadoFactura = -1;
        }

        public Linea(Linea anterior, ColasMunicipalidad colas, int filaDesde, int filaHasta, int idFila)
        {
            this.lineaAnterior = anterior;
            this.truncador = new Truncador(4);
            this.aleatorios = new GeneradorUniformeLenguaje(truncador);
            this.ventanillaInforme = anterior.obtenerVentanillaInforme();
            this.ventanillaActualizacion = anterior.obtenerVentanillaActualizacion();

            Caja[] temp = new Caja[anterior.cajas.Count];
            anterior.cajas.CopyTo(temp);

            this.cajas = new List<Caja>(temp);
            this.clientes = anterior.clientes;

            colaCaja = anterior.colaCaja;
            this.colas = colas;
            this.clientesLibre = anterior.clientesLibre;

            this.filaDesde = filaDesde;
            this.filaHasta = filaHasta;
            this.idFila = idFila;

            acumuladorTiemposEsperaEnCaja = anterior.acumuladorTiemposEsperaEnCaja;
            cantidadClientesEsperan = anterior.cantidadClientesEsperan;
            acumuladorTiempoOcupacionVentanillaInformes = anterior.acumuladorTiempoOcupacionVentanillaInformes;
            acumuladorTiempoOciosoVentanillaActualizacion = anterior.acumuladorTiempoOciosoVentanillaActualizacion;
            tiempoMaximoEsperaEnCola = anterior.tiempoMaximoEsperaEnCola;
    }


        public VentanillaInforme obtenerVentanillaInforme()
        {
            return (VentanillaInforme)this.ventanillaInforme.Clone();
        }

        public VentanillaActualizacion obtenerVentanillaActualizacion()
        {
            return (VentanillaActualizacion) this.ventanillaActualizacion.Clone();
        }

        public void calcularFinInforme(long tiempo)
        {
            calcularTiempoOcupacionInformes();

            calcularFinInformeEventoFinInforme(tiempo);
            calcularFinInformeEventoLlegadaCliente(tiempo);
            calcularFinInformeEventoFinActualizacion(tiempo);
        }

        public void calcularColumnaFinActualizacion(long tiempo)
        {
            sumarTiempoOciosoActualizacion();

            calcularFinActualizacionEventoFinActualizacion(tiempo);
            calcularFinActualizacionEventoFinInforme(tiempo);
            calcularFinActualizacionEventoLlegadaCliente(tiempo);
        }

        private void cargarCajas(int cantidadCajas)
        {
            for (int i = 1; i <= cantidadCajas; i++)
            {
                cajas.Add(new Caja(i));
            }
        }

        public void calcularEvento()
        {

            this.reloj = lineaAnterior.llegadaCliente;
            this.evento = LLEGADA_PERSONA;
            cajaFinCobro = null;

            if (lineaAnterior.ventanillaInforme.finInforme >0 && lineaAnterior.ventanillaInforme.finInforme < reloj) {
                reloj = lineaAnterior.ventanillaInforme.finInforme;
                evento = FIN_INFORME;
            }

            if (lineaAnterior.ventanillaActualizacion.finActualizacion > 0 && lineaAnterior.ventanillaActualizacion.finActualizacion < reloj)
            {
                reloj = lineaAnterior.ventanillaActualizacion.finActualizacion;
                evento = FIN_ACTUALIZACION;
            }

            foreach (var caja in lineaAnterior.cajas)
            {
                if (caja.finCobro < reloj && caja.finCobro > 0) {
                    reloj = caja.finCobro;
                    cajaFinCobro = (Caja)this.cajas.Where(x => x.id == caja.id).FirstOrDefault();
                    evento = FIN_COBRO;
                }
            }

        }


        public void calcularSiguienteLlegada(long tiempoParaLlegada) {
            if (this.evento.Equals(LLEGADA_PERSONA))
            {
                this.llegadaCliente = reloj + tiempoParaLlegada;
                return;
            }
            this.llegadaCliente = lineaAnterior.llegadaCliente;
        }

        public void calcularEstadoFactura(double[] probabilidades, string[] estadosFactura)
        {
            rndEstadoFactura = -1;
            if (this.evento.Equals(LLEGADA_PERSONA))
            {
                rndEstadoFactura = aleatorios.siguienteAleatorio();
                this.estadoFactura = buscarProbabilidadEnVector(probabilidades, estadosFactura, rndEstadoFactura);
                return;
            }
            this.estadoFactura = "";
        }

        public void calcularConoceProcedimiento(double[] probabilidades, string[] conoceProcedimiento)
        {
            if (this.estadoFactura.Equals("vencida"))
            {
                rndConoceProcedimiento = aleatorios.siguienteAleatorio();
                this.conoceProcedimiento = buscarProbabilidadEnVector(probabilidades, conoceProcedimiento, rndConoceProcedimiento);
                return;
            }
            this.rndConoceProcedimiento = -1;
            this.conoceProcedimiento = "";
        }

        private string buscarProbabilidadEnVector(double[] probAcum, string[] vector, double random)
        {

            for (int i = 0; i < probAcum.Length; i++)
            {
                if (random < probAcum[i])
                {
                    return vector[i];
                }
            }
            return "";
        }

        private void calcularTiempoOcupacionInformes()
        {
            if (lineaAnterior.ventanillaInforme.estaOcupada())
            {
                this.acumuladorTiempoOcupacionVentanillaInformes += (reloj - lineaAnterior.reloj);
            }

        }

        private void calcularFinInformeEventoFinInforme(long tiempo)
        {

            if (this.evento.Equals(FIN_INFORME))
            {
                if (lineaAnterior.tieneColaInforme())
                {
                    Cliente clienteActual = ventanillaInforme.siguienteCliente();
                    atenderInforme(clienteActual, tiempo);
                }
                else
                {
                    ventanillaInforme.liberar();
                }
            }
        }



        private void esperarInforme(Cliente clienteActual)
        {
            ventanillaInforme.agregarFinInforme(lineaAnterior.obtenerFinInforme());
            ventanillaInforme.agregarACola(clienteActual);
            clienteActual.esperarInforme();
        }
        private void esperarActualizacion(Cliente clienteActual)
        {
            ventanillaActualizacion.agregarFinActualizacion(lineaAnterior.obtenerFinActualizacion());
            ventanillaActualizacion.agregarACola(clienteActual);
            clienteActual.esperarActualizacion();
        }

        private void atenderInforme(Cliente clienteActual, long tiempo)
        {
            clienteActual.atenderInforme();
            ventanillaInforme.agregarFinInforme(this.reloj + tiempo);
            ventanillaInforme.clienteActual = clienteActual;
        }

        private void atenderActualizacion(Cliente clienteActual, long tiempo)
        {
            clienteActual.atenderActualizacion();
            ventanillaActualizacion.agregarFinActualizacion(this.reloj + tiempo);
            ventanillaActualizacion.clienteActual = clienteActual;
        }



        private void calcularFinInformeEventoFinActualizacion(long tiempo)
        {
            if (this.evento.Equals(FIN_ACTUALIZACION) && lineaAnterior.tieneFinInforme())
            {
                ventanillaInforme.agregarFinInforme(lineaAnterior.obtenerFinInforme());
            }
        }

        private Cliente buscarClienteLibre()
        {
            Cliente libre;
            Boolean correcto = clientesLibre.TryDequeue(out libre);
            if (correcto)
            {
                return libre;
            }

            Cliente res = new Cliente();
            this.clientes.Add(res);
            if(idFila <= filaHasta)
            {
                colas.agregarColumna();
            }
         
            return res;
        }

        private Boolean tieneVentanillaInformeOcupada()
        {
            return this.ventanillaInforme.estaOcupada();
        }

        private Boolean tieneColaInforme()
        {
            return this.ventanillaInforme.tieneCola();
        }

        private Boolean tieneFinInforme()
        {
            return this.ventanillaInforme.tieneFinInforme();
        }

        private long obtenerFinInforme()
        {
            return this.ventanillaInforme.finInforme;
        }

        private void sumarTiempoOciosoActualizacion()
        {
            if (!lineaAnterior.ventanillaActualizacion.estaOcupada())
            {
                this.acumuladorTiempoOciosoVentanillaActualizacion += (reloj - lineaAnterior.reloj);
            }
        }


        private void calcularFinActualizacionEventoLlegadaCliente(long tiempo)
        {
            if ((this.conoceProcedimiento.Equals("si")))
            {
                Cliente clienteActual = buscarClienteLibre();
                if (lineaAnterior.tieneVentanillaActualizacionOcupada())
                {
                    esperarActualizacion(clienteActual);
                }
                else
                {
                    atenderActualizacion(clienteActual, tiempo);

                }
            }
        }

        private void calcularFinInformeEventoLlegadaCliente(long tiempo)
        {
            if (this.conoceProcedimiento.Equals("no"))
            {
                Cliente clienteActual = buscarClienteLibre();
                if (lineaAnterior.tieneVentanillaInformeOcupada())
                {
                    esperarInforme(clienteActual);
                }
                else
                {
                    atenderInforme(clienteActual, tiempo);

                }
            }
        }

        private void calcularFinActualizacionEventoFinInforme(long tiempo)
        {
            if (this.evento.Equals(FIN_INFORME))
            {
                Cliente clienteActual = lineaAnterior.ventanillaInforme.getClienteActual();

                if (lineaAnterior.tieneVentanillaActualizacionOcupada())
                {
                    esperarActualizacion(clienteActual);
                }
                else
                {
                    atenderActualizacion(clienteActual, tiempo);
                }
            }
        }

        private void calcularFinActualizacionEventoFinActualizacion(long tiempo)
        {
            if (this.evento.Equals(FIN_ACTUALIZACION))
            {
                if (this.lineaAnterior.tieneColaActualizacion())
                {
                    Cliente clienteActual = ventanillaActualizacion.siguienteCliente();
                    atenderActualizacion(clienteActual, tiempo);
                }
                else
                {
                    ventanillaActualizacion.liberar();
                }
            }

        }


        private Boolean tieneVentanillaActualizacionOcupada()
        {
            return this.ventanillaActualizacion.estaOcupada();
        }

        private long obtenerFinActualizacion()
        {
            return this.ventanillaActualizacion.obtenerFinActualizacion();
        }

        private Boolean tieneFinActualizacion()
        {
            return this.ventanillaActualizacion.tieneFinActualizacion();
        }

        private Boolean tieneColaActualizacion()
        {
            return this.ventanillaActualizacion.tieneCola();
        }

        private void esperarCaja(Cliente nuevoCliente)
        {
            Caja.agregarACola(nuevoCliente);
            nuevoCliente.esperarCaja();
            nuevoCliente.horaLLegadaACaja = this.reloj;
            this.colaCaja++;
        }

        private void atenderCaja(Cliente nuevoCliente, Caja cajaLibre, long tiempo)
        {
            cajaLibre.clienteActual = nuevoCliente;
            nuevoCliente.atenderCaja(cajaLibre.id, reloj);
            cajaLibre.agregarFinCobro(reloj + tiempo);
        }

        private void actualizarTiempoMaximoEsperaEnCola(Cliente clienteActual)
        {
            long maxTemp = clienteActual.tiempoEsperaEnCaja;
            this.acumuladorTiemposEsperaEnCaja += maxTemp;
            if (maxTemp > tiempoMaximoEsperaEnCola) { tiempoMaximoEsperaEnCola = maxTemp; }
        }

        public void calcularFinCobro(long tiempo)
        {

            if (this.evento.Equals(FIN_COBRO))
            {
                Cliente clienteViejo = cajaFinCobro.clienteActual;
                clienteViejo.limpiar();
                clientesLibre.Enqueue(clienteViejo);
                cajaFinCobro.liberar();

                if (lineaAnterior.tieneColaCobro())
                {
                    Cliente clienteActual = Caja.siguienteCliente();
                    colaCaja--;
                    atenderCaja(clienteActual, cajaFinCobro, tiempo);
                    actualizarTiempoMaximoEsperaEnCola(clienteActual);
                    cantidadClientesEsperan++;
                }
                else
                {
                    
                }
            }

            if (this.estadoFactura.Equals("al dia")) 
            {
                Cliente nuevoCliente = buscarClienteLibre();
                Caja cajaLibre = buscarCajaLibre();

                if (cajaLibre == null)
                {
                    esperarCaja(nuevoCliente);
                }
                else
                {
                    atenderCaja(nuevoCliente, cajaLibre, tiempo);
                }
            } 

            if (this.evento.Equals(FIN_ACTUALIZACION))
            {
                Cliente clienteActual = lineaAnterior.ventanillaActualizacion.getClienteActual();
                Caja cajaLibre = buscarCajaLibre();

                if (cajaLibre == null)
                {
                    esperarCaja(clienteActual);
                }
                else
                {
                    atenderCaja(clienteActual, cajaLibre, tiempo);
                    actualizarTiempoMaximoEsperaEnCola(clienteActual);
                }

            }

        }

        private Boolean tieneColaCobro()
        {
            return Caja.tieneCola();
        }

        private Caja buscarCajaLibre()
        {
            foreach (var caja in cajas)
            {
                if (caja.estaLibre()) return caja;
            }
            return null;
        }


    }
}
