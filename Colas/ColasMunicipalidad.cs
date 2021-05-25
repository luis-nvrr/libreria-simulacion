using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Colas
{
    class ColasMunicipalidad
    {
        double[] probabilidadesEstadosAcum = new double[] { 0.4, 1 };
        string[] estadosFactura = new string[] { "vencida", "al dia" };

        double[] probabilidadesConoceProcedimientoAcum = new double[] { 0.6, 1 };
        string[] conoceProcedimiento = new string[] { "si", "no" };

        DataTable resultados;
        DataTable temp;
        private PantallaResultados pantallaResultados;
        private int cantidadClientes;
        private int indice;

        public ColasMunicipalidad(PantallaResultados pantallaResultados)
        {
            this.pantallaResultados = pantallaResultados;
            resultados = new DataTable();
            crearTabla(resultados);
            temp = new DataTable();
            crearTabla(temp);
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("evento");
            tabla.Columns.Add("reloj(seg)");
            tabla.Columns.Add("llegada cliente");
            tabla.Columns.Add("RND estado factura");
            tabla.Columns.Add("estado factura");
            tabla.Columns.Add("RND conoce procedimiento");
            tabla.Columns.Add("conoce procedimiento");
            tabla.Columns.Add("fin informe");
            tabla.Columns.Add("fin actualizacion");
            tabla.Columns.Add("fin de cobro 1");
            tabla.Columns.Add("fin de cobro 2");
            tabla.Columns.Add("fin de cobro 3");
            tabla.Columns.Add("fin de cobro 4");
            tabla.Columns.Add("fin de cobro 5");
            tabla.Columns.Add("estado informe");
            tabla.Columns.Add("cola informe");
            tabla.Columns.Add("estado actualizacion");
            tabla.Columns.Add("cola actualizacion");
            tabla.Columns.Add("estado caja 1");
            tabla.Columns.Add("estado caja 2");
            tabla.Columns.Add("estado caja 3");
            tabla.Columns.Add("estado caja 4");
            tabla.Columns.Add("estado caja 5");
            tabla.Columns.Add("cola caja");
            tabla.Columns.Add("Acum tiempos espera en caja");
            tabla.Columns.Add("Cantidad clientes atendidos");
            tabla.Columns.Add("Acum tiempo de ocupacion de informe");
            tabla.Columns.Add("Tiempo ocioso de actualizacion");
            tabla.Columns.Add("Tiempo maximo espera en caja");
        }


        public void simular()
        {
            Linea lineaAnterior = new Linea(5);
            Linea lineaActual = null;

            for (int i = 1; i < 1000; i++)
            {
                lineaActual = new Linea(lineaAnterior, this);
                lineaActual.calcularEvento();
                lineaActual.calcularSiguienteLlegada(5);
                lineaActual.calcularEstadoFactura(probabilidadesEstadosAcum, estadosFactura);
                lineaActual.calcularConoceProcedimiento(probabilidadesConoceProcedimientoAcum, conoceProcedimiento);
                lineaActual.calcularFinInforme(20);
                lineaActual.calcularFinActualizacion(20);
                lineaActual.calcularFinCobro(60);
                lineaAnterior = lineaActual;

                    lineaActual.calcularClientes();
                    agregarLinea(lineaActual, i);
            }

            MessageBox.Show("Promedio - " + ((double)lineaActual.acumuladorTiemposEsperaEnCaja / (double)lineaActual.cantidadClientesEsperan).ToString());
            construirTablaEntre(0, 30);

            pantallaResultados.mostrarResultados(temp);
        }


        private void construirTablaEntre(int desde, int hasta)
        {
            for (int i = 100; i < 200; i++)
            {
                temp.Rows.Add(temp.NewRow());
                for (int j = desde; j < hasta; j++)
                {
                    temp.Rows[i][j] = resultados.Rows[i][j];
                }
            }
        }

        public void agregarColumna()
        {
            cantidadClientes++;
            this.resultados.Columns.Add("estado " + cantidadClientes);
            this.resultados.Columns.Add("hora " + cantidadClientes);

            this.temp.Columns.Add("estado " + cantidadClientes);
            this.temp.Columns.Add("hora " + cantidadClientes);
        }

        private void agregarLinea(Linea linea, int i)
        {
            DataRow row = resultados.NewRow();
            row[0] = linea.evento;
            row[1] = linea.reloj;
            row[2] = linea.llegadaCliente;
            row[3] = linea.rndEstadoFactura;
            row[4] = linea.estadoFactura;
            row[5] = linea.rndConoceProcedimiento;
            row[6] = linea.conoceProcedimiento;
            row[7] = linea.ventanillaInforme.finInforme;
            row[8] = linea.ventanillaActualizacion.finActualizacion;
            row[9] = linea.cajas[0].finCobro;
            row[10] = linea.cajas[1].finCobro;
            row[11] = linea.cajas[2].finCobro;
            row[12] = linea.cajas[3].finCobro;
            row[13] = linea.cajas[4].finCobro;
            row[14] = linea.ventanillaInforme.estado;
            row[15] = linea.ventanillaInforme.cola.Count;
            row[16] = linea.ventanillaActualizacion.estado;
            row[17] = linea.ventanillaActualizacion.cola.Count;
            row[18] = linea.cajas[0].estado;
            row[19] = linea.cajas[1].estado;
            row[20] = linea.cajas[2].estado;
            row[21] = linea.cajas[3].estado;
            row[22] = linea.cajas[4].estado;
            row[23] = linea.colaCaja;
            row[24] = linea.acumuladorTiemposEsperaEnCaja;
            row[25] = linea.cantidadClientesEsperan;
            row[26] = linea.acumuladorTiempoOcupacionVentanillaInformes;
            row[27] = linea.acumuladorTiempoOciosoVentanillaActualizacion;
            row[28] = linea.tiempoMaximoEsperaEnCola;

            indice = 28;
                for (int j = 0; j < cantidadClientes; j++)
                {
                    indice += 1;
                    row[indice] = linea.clientes[j].estado;
                    indice += 1;
                    row[indice] = linea.clientes[j].horaLLegadaACaja;
                }
            resultados.Rows.Add(row);

         
        }

    }
}
