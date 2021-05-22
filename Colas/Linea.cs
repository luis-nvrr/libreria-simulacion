using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Colas
{
    class Linea
    {
        string LLEGADA_PERSONA = "llegada de persona";
        string FIN_INFORME = "fin de informe";
        string FIN_ACTUALIZACION = "fin de actualizacion";
        string FIN_COBRO = "fin de cobro";

        IGenerador aleatorios;
        Truncador truncador;

        string evento { get; set; }
        double reloj { get; set; }
        double llegadaCliente { get; set; }
        double rndEstadoFactura { get; set; }
        string estadoFactura { get; set; }
        double rndConoceProcedimiento { get; set; }
        string conoceProcedimiento { get; set; }
        List<Caja> cajas { get; set; }
        VentanillaActualizacion ventanillaActualizacion { get; set; }
        VentanillaInforme ventanillaInforme { get; set; }
        Linea lineaAnterior { get; set; }


        public Linea(int cantidadCajas)
        {
            this.llegadaCliente = 60;
            this.truncador = new Truncador(4);
            this.aleatorios = new GeneradorUniformeLenguaje(truncador);
            this.ventanillaInforme = new VentanillaInforme();
            this.ventanillaActualizacion = new VentanillaActualizacion();
            this.cajas = new List<Caja>(5);
        }

        public Linea(Linea anterior)
        {
            this.lineaAnterior = anterior;
            this.truncador = new Truncador(4);
            this.aleatorios = new GeneradorUniformeLenguaje(truncador);
            this.ventanillaInforme = new VentanillaInforme();
            this.ventanillaActualizacion = new VentanillaActualizacion();
            this.cajas = new List<Caja>(5);
        }



        public void calcularEvento()
        {
            this.reloj = lineaAnterior.llegadaCliente;
            this.evento = LLEGADA_PERSONA;

            if (lineaAnterior.ventanillaInforme.finInforme < reloj) {
                reloj = lineaAnterior.ventanillaInforme.finInforme;
                evento = FIN_INFORME;
            }

            if (lineaAnterior.ventanillaActualizacion.finActualizacion < reloj)
            {
                reloj = lineaAnterior.ventanillaActualizacion.finActualizacion;
                evento = FIN_ACTUALIZACION;
            }

            foreach (var caja in lineaAnterior.cajas)
            {
                if (caja.finCobro < reloj) {
                    reloj = caja.finCobro;
                    evento = FIN_COBRO;
                }
            }
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
                double rndFactura = aleatorios.siguienteAleatorio();
                this.estadoFactura = buscarProbabilidadEnVector(probabilidades, estadosFactura, rndFactura);
                return;
            }
            this.estadoFactura = "";
        }

        public void calcularConoceProcedimiento(double[] probabilidades, string[] conoceProcedimiento)
        {
            if (this.estadoFactura.Equals("vencida"))
            {
                double rndConoce = aleatorios.siguienteAleatorio();
                this.conoceProcedimiento = buscarProbabilidadEnVector(probabilidades, conoceProcedimiento, rndConoce);
                return;
            }
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
            if (this.evento.Equals(FIN_INFORME) && lineaAnterior.tieneColaInforme())
            {
                ventanillaInforme.agregarFinInforme(this.reloj + tiempo);
                return;
            }

            if (this.evento.Equals(LLEGADA_PERSONA) && this.conoceProcedimiento.Equals("no"))
            {

                if (lineaAnterior.tieneFinInforme())
                {
                    this.ventanillaInforme.finInforme = lineaAnterior.obtenerFinInforme();
                    return;
                }

                this.ventanillaInforme.agregarFinInforme(this.reloj + tiempo);
                return;
            }

            this.ventanillaInforme.noGenerarFinInforme();
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

            if (this.evento.Equals(FIN_ACTUALIZACION) && lineaAnterior.tieneColaActualizacion()
                || this.evento.Equals(FIN_INFORME)
                || this.conoceProcedimiento.Equals("si") && !lineaAnterior.tieneFinActualizacion())
            {
                ventanillaActualizacion.agregarFinActualizacion(this.reloj + tiempo);
                return;
            }

            this.ventanillaActualizacion.noGenerarFinActualizacion();
        }


        private Boolean tieneFinActualizacion()
        {
            return this.ventanillaActualizacion.tieneFinActualizacion();
        }

        private Boolean tieneColaActualizacion()
        {
            return this.ventanillaActualizacion.tieneCola();
        }

    }
}
