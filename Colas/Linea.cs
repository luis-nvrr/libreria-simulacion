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
       public double reloj { get; set; }
       public double llegadaCliente { get; set; }
       public double rndEstadoFactura { get; set; }
       public string estadoFactura { get; set; }
       public double rndConoceProcedimiento { get; set; }
       public string conoceProcedimiento { get; set; }
       public List<Caja> cajas { get; set; }
       public VentanillaActualizacion ventanillaActualizacion { get; set; }
       public VentanillaInforme ventanillaInforme { get; set; }
       public Linea lineaAnterior { get; set; }

        public Caja cajaFinCobro;

        public List<Cliente> clientes;


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
        }

        public Linea(Linea anterior)
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
        }


        public VentanillaInforme obtenerVentanillaInforme()
        {
            return (VentanillaInforme)this.ventanillaInforme.Clone();
        }

        public VentanillaActualizacion obtenerVentanillaActualizacion()
        {
            return (VentanillaActualizacion) this.ventanillaActualizacion.Clone();
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
                //MessageBox.Show("informe" + "-" + reloj.ToString());
                evento = FIN_INFORME;
            }

            if (lineaAnterior.ventanillaActualizacion.finActualizacion > 0 && lineaAnterior.ventanillaActualizacion.finActualizacion < reloj)
            {
                reloj = lineaAnterior.ventanillaActualizacion.finActualizacion;
                //MessageBox.Show("actualizacion" + "-" + reloj.ToString());
                evento = FIN_ACTUALIZACION;
            }

            foreach (var caja in lineaAnterior.cajas)
            {
                if (caja.finCobro < reloj && caja.finCobro > 0) {
                    reloj = caja.finCobro;
                    //MessageBox.Show("cobro " + caja.id.ToString() + "-" + caja.finCobro.ToString());
                    cajaFinCobro = (Caja)this.cajas.Where(x => x.id == caja.id).FirstOrDefault();
                    evento = FIN_COBRO;
                }
            }

            //if (this.evento.Equals(LLEGADA_PERSONA))
            //{
            //    this.clientes.Add(new Cliente());
            //}
        }


        public void calcularSiguienteLlegada(double tiempoParaLlegada) {
            if (this.evento.Equals(LLEGADA_PERSONA))
            {
                this.llegadaCliente = reloj + tiempoParaLlegada;
                return;
            }
            this.llegadaCliente = lineaAnterior.llegadaCliente;
        }

        public void calcularEstadoFactura(double[] probabilidades, string[] estadosFactura)
        {
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

        public void calcularFinInforme(double tiempo)
        {
            if(this.evento.Equals(FIN_INFORME) && !lineaAnterior.tieneColaInforme())
            {
                ventanillaInforme.liberar();
            }

            if ((this.evento.Equals(FIN_INFORME) && lineaAnterior.tieneColaInforme())
                || (this.conoceProcedimiento.Equals("no") && !lineaAnterior.tieneFinInforme()))
            {
                ventanillaInforme.agregarFinInforme(this.reloj + tiempo);
                ventanillaInforme.disminuirCola();
                return;
            }

            if(this.conoceProcedimiento.Equals("no") && lineaAnterior.tieneVentanillaInformeOcupada())
            {
                ventanillaInforme.aumentarCola();
                Cliente cliente = buscarClienteLibre();
                cliente.esperarInforme();
                return;
            }

            if(!this.evento.Equals(FIN_INFORME) && lineaAnterior.tieneFinInforme()) {
                this.ventanillaInforme.agregarFinInforme(lineaAnterior.obtenerFinInforme());
                return;
            }

            this.ventanillaInforme.noGenerarFinInforme();
        }

        private Cliente buscarClienteLibre()
        {
            foreach (var cliente in clientes)
            {
                if (cliente.estaLibre())
                {
                    return cliente;
                }
            }
            return null;
        }

        public int cantidadClientes()
        {
            return this.clientes.Count;
        }


        private Cliente crearNuevoCliente()
        {
            Cliente clienteNuevo = new Cliente();
            this.clientes.Add(clienteNuevo);
            return clienteNuevo;
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

        private double obtenerFinInforme()
        {
            return this.ventanillaInforme.finInforme;
        }

        public void calcularFinActualizacion(double tiempo)
        {

            if (this.evento.Equals(FIN_ACTUALIZACION) && !lineaAnterior.tieneColaActualizacion() )
            {
                ventanillaActualizacion.liberar();
            }

            //if ((this.evento.Equals(FIN_ACTUALIZACION) && lineaAnterior.tieneColaActualizacion())
            //    || (this.evento.Equals(FIN_INFORME))
            //   || (this.conoceProcedimiento.Equals("si") && !lineaAnterior.tieneFinActualizacion()))
            {
                Cliente clienteActual;

                if((this.evento.Equals(FIN_ACTUALIZACION)))
                {
                    if (lineaAnterior.tieneColaActualizacion())
                    {
                        ventanillaActualizacion.disminuirCola();
                    }
                    //clienteActual = ventanillaActualizacion.siguienteCliente();
                    //clienteActual.atenderActualizacion();
                }

                if (this.evento.Equals(FIN_INFORME))
                {
                    clienteActual = ventanillaInforme.getClienteActual();
                    if (lineaAnterior.tieneColaActualizacion())
                    {
                        ventanillaActualizacion.aumentarCola();
                        clienteActual.esperarActualizacion();
                    }
                    else
                    {
                        ventanillaActualizacion.agregarFinActualizacion(this.reloj + tiempo);
                        clienteActual.atenderActualizacion();
                    }
                   
                }
                if ((this.conoceProcedimiento.Equals("si")))
                {
                    clienteActual = new Cliente();
                    this.clientes.Add(clienteActual);
                    if (lineaAnterior.tieneVentanillaActualizacionOcupada())
                    {
                        ventanillaActualizacion.aumentarCola();
                        ventanillaActualizacion.agregarACola(clienteActual);
                        clienteActual.esperarActualizacion();
                        MessageBox.Show(ventanillaActualizacion.tamañoCola.ToString());

                    }
                    else
                    {
                        ventanillaActualizacion.agregarFinActualizacion(this.reloj + tiempo);
                        clienteActual.atenderActualizacion();
                    }

                }
                return;
            }

            //if (this.conoceProcedimiento.Equals("si") && lineaAnterior.tieneVentanillaActualizacionOcupada())
            //{
            //    ventanillaActualizacion.aumentarCola();
            //    clienteActual.esperarActualizacion();
            //    return;
            //}

            if (lineaAnterior.tieneFinActualizacion() && !this.evento.Equals(FIN_ACTUALIZACION))
            {
                this.ventanillaActualizacion.agregarFinActualizacion(lineaAnterior.obtenerFinActualizacion());
                return;
            }

            this.ventanillaActualizacion.noGenerarFinActualizacion();
        }

        private Boolean tieneVentanillaActualizacionOcupada()
        {
            return this.ventanillaActualizacion.estaOcupada();
        }

        private double obtenerFinActualizacion()
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

        public void calcularFinCobro(double tiempo)
        {
            if (evento.Equals(FIN_COBRO) && cajaFinCobro != null)
            {
                cajaFinCobro.liberar();
                Caja.actualizarCola();
            }

            if (this.estadoFactura.Equals("al dia")
                || this.evento.Equals(FIN_ACTUALIZACION)
                || (this.evento.Equals(FIN_COBRO) && Caja.tamañoCola > 0))
            {
                Caja caja = buscarCajaLibre();
                if(caja == null) {
                    Caja.aumentarCola();
                    return;
                }

                caja.agregarFinCobro(this.reloj + tiempo);

            }
           
        }


        private Caja buscarCajaLibre()
        {
            foreach (var caja in cajas)
            {
                if (caja.estaLibre()) return caja;
            }
            return null;
        }


        public void calcularClientes()
        {

        }
    }
}
