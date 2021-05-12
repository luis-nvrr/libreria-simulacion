using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Montecarlo
{
    class GestorInventarioBicicletas
    {
        private DataTable tablaRango;
        private DataTable tablaResultados;

        private double[] lineaAnterior;
        private double[] lineaActual;
        PantallaInventarioBicicletas pantalla;
        private double[] demandaAcumulada;
        private double[] demoraAcumulada;
        private double[] dañoAcumulada;
        private Truncador truncador;
        private IGenerador generadorAleatorios;



        public GestorInventarioBicicletas(PantallaInventarioBicicletas pantalla)
        {
            this.pantalla = pantalla;
            this.lineaAnterior = new double[17];
            this.lineaActual = new double[17];
            this.tablaRango = new DataTable();
            crearTabla(tablaRango);

            this.truncador = new Truncador(4);
            this.generadorAleatorios = new GeneradorUniformeLenguaje(truncador);

            this.demandaAcumulada = new double[] { 0.5, 0.65, 0.9, 1 };
            this.demoraAcumulada = new double[] { 0.3, 0.4, 1 };
            this.dañoAcumulada = new double[] { 0.7, 1 };

            this.tablaResultados = new DataTable();
            crearTabla(tablaResultados);
        }


        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("semana");
            tabla.Columns.Add("RND demanda");
            tabla.Columns.Add("demanda");
            tabla.Columns.Add("RND demora");
            tabla.Columns.Add("demora");
            tabla.Columns.Add("llegada");
            tabla.Columns.Add("entrante");
            tabla.Columns.Add("RND dañada");
            tabla.Columns.Add("dañada");
            tabla.Columns.Add("entrante final");
            tabla.Columns.Add("stock");
            tabla.Columns.Add("costo mantenimiento");
            tabla.Columns.Add("costo pedido");
            tabla.Columns.Add("costo stockout");
            tabla.Columns.Add("costo total");
            tabla.Columns.Add("costo acumulado");
            tabla.Columns.Add("bicicletas con daños");
        }


        public void simular(int cantidadSemanas, int extremoInferior,
            int extremoSuperior, int puntoPedido, int cantidadPedido, int stockInicial, int costoMantenimiento,
            int costoStockout, int costoPedido)
        {
            procesar(cantidadSemanas, extremoInferior, extremoSuperior, 
                puntoPedido, cantidadPedido, stockInicial,costoMantenimiento, costoStockout, costoPedido);
            mostrarResultados();
            mostrarRango();
        }

        private void procesar(int cantidadSemanas, int extremoInferior, 
            int extremoSuperior, int PUNTO_PEDIDO, int CANTIDAD_PEDIDO, int STOCK_INICIAL, int COSTO_MANTENIMIENTO,
            int COSTO_STOCKOUT, int COSTO_PEDIDO)
        {
            lineaAnterior[0] = 0;
            lineaAnterior[10] = STOCK_INICIAL;
            lineaAnterior[5] = -1;


            double semanaActual;
            double aleatorioDemanda;
            double stockActual;
            double llegadaAnterior;
            double aleatorioDemora;
            double llegadaActual;
            double demoraActual;
            double entranteActual;
            double aleatorioDañadas;
            double dañadasActual;
            double entranteFinal;
            double stockAnterior;
            double demandaActual;
            double costoMantenimiento;
            double costoPedido;
            double costoStockout;
            double costoTotal;
            double costoAcumuladoAnterior;
            double costoAcumuladoActual;
            double bicicletasDañadasAcumuladasAnterior;
            double bicicletasDañadasAcumuladasActual;

            DataRow row;

            for (int i = 1; i <= cantidadSemanas; i++)
            {
                semanaActual = i;
                lineaActual[0] = semanaActual;
                aleatorioDemanda = generadorAleatorios.siguienteAleatorio();
                lineaActual[1] = aleatorioDemanda;
                demandaActual = buscarDemanda(aleatorioDemanda);
                lineaActual[2] = demandaActual;

                llegadaAnterior = lineaAnterior[5];
               
                if(llegadaAnterior == semanaActual)
                {
                    entranteActual = CANTIDAD_PEDIDO;
                }
                else
                {
                    entranteActual = -1;
                }

                lineaActual[6] = entranteActual;

                if(entranteActual != -1)  // hay entrante actual
                {
                    aleatorioDañadas = generadorAleatorios.siguienteAleatorio(); // aleatorio para dañadas 
                }
                else
                {
                    aleatorioDañadas = -1;
                }

                lineaActual[7] = aleatorioDañadas;

                if(aleatorioDañadas != -1)
                {
                    dañadasActual = buscarDaño(aleatorioDañadas); // calcula dañadas actual
                }
                else
                {
                    dañadasActual = -1; // valor invalido
                }

                lineaActual[8] = dañadasActual;

                if(dañadasActual == -1) // si no hay entrante
                {
                    entranteFinal = 0;
                }
                else
                {
                    entranteFinal = entranteActual - dañadasActual;
                }

                lineaActual[9] = entranteFinal;

                /// 
                stockAnterior = lineaAnterior[10];
                double faltante = stockAnterior + entranteFinal - demandaActual; 
                stockActual = faltante;

                if ((faltante) < 0)
                {
                    stockActual = 0;
                }

                lineaActual[10] = stockActual;
                    

                if (stockActual <= PUNTO_PEDIDO && (llegadaAnterior == -1 || llegadaAnterior == semanaActual))
                {
                    aleatorioDemora = generadorAleatorios.siguienteAleatorio();
                }
                else
                {
                    aleatorioDemora = -1;
                }

                lineaActual[3] = aleatorioDemora;

                demoraActual = buscarDemora(aleatorioDemora);
                lineaActual[4] = demoraActual;

                if (llegadaAnterior > 0 && llegadaAnterior != semanaActual)
                {
                    llegadaActual = llegadaAnterior;
                }
                else
                {
                    if (aleatorioDemora >= 0) llegadaActual = demoraActual + semanaActual;
                    else llegadaActual = -1;
                }

                lineaActual[5] = llegadaActual;
                ///

                costoMantenimiento = stockActual * COSTO_MANTENIMIENTO;
                lineaActual[11] = costoMantenimiento;

                costoPedido = COSTO_PEDIDO;
                if(aleatorioDemora == -1) { costoPedido = 0; }
                lineaActual[12] = costoPedido;

                costoStockout = 0;
                if (faltante < 0) costoStockout = -faltante * COSTO_STOCKOUT;
                lineaActual[13] = costoStockout;

                costoTotal = costoMantenimiento + costoPedido + costoStockout;
                lineaActual[14] = costoTotal;

                costoAcumuladoAnterior = lineaAnterior[15];
                costoAcumuladoActual = costoAcumuladoAnterior + costoTotal;
                lineaActual[15] = costoAcumuladoActual;

                bicicletasDañadasAcumuladasAnterior = lineaAnterior[16];

                if(dañadasActual >= 0)
                {
                    bicicletasDañadasAcumuladasActual = dañadasActual + bicicletasDañadasAcumuladasAnterior;
                }
                else
                {
                    bicicletasDañadasAcumuladasActual = bicicletasDañadasAcumuladasAnterior;
                }
        
                lineaActual[16] = bicicletasDañadasAcumuladasActual;

                if(i >= extremoInferior && i <= extremoSuperior)
                {
                    row = tablaRango.NewRow();
                    for (int j = 0; j < lineaActual.Length; j++)
                    {
                        double columnaActual = lineaActual[j];
                        
                        if(columnaActual == -1)
                        {
                            row[j] = "";
                        }
                        else
                        {
                            row[j] = columnaActual;
                        }

                    }
                    tablaRango.Rows.Add(row);
                }

                if( i >= cantidadSemanas -1)
                {
                    row = tablaResultados.NewRow();
                    for (int j = 0; j < lineaActual.Length; j++)
                    {
                        double columnaActual = lineaActual[j];

                        if (columnaActual == -1)
                        {
                            row[j] = "";
                        }
                        else
                        {
                            row[j] = columnaActual;
                        }

                    }
                    tablaResultados.Rows.Add(row);

                }


                lineaAnterior = lineaActual;
            }
        }

        private void mostrarResultados()
        {
            pantalla.mostrarResultados(tablaResultados);
        }
   

        private void mostrarRango() {
            pantalla.mostrarRango(tablaRango);

        }

        private int buscarDemanda(double demanda)
        {
            for (int i = 0; i < demandaAcumulada.Length && demanda >=0; i++)
            {
                if (demanda < demandaAcumulada[i])
                {
                    return i;
                }
            }
            return -1;
        }

        private int buscarDemora(double demora)
        {
            for (int i = 0; i < demoraAcumulada.Length && demora >= 0; i++)
            {
                if(demora < demoraAcumulada[i])
                {
                    return i+1;
                }
            }
            return -1;
        }

        private int buscarDaño(double daño)
        {
            for (int i = 0; i < dañoAcumulada.Length && daño >= 0; i++)
            {
                if(daño < dañoAcumulada[i])
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
