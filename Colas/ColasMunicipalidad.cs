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
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("evento");
            tabla.Columns.Add("reloj");
            tabla.Columns.Add("LL CL");
            tabla.Columns.Add("RND E.F.");
            tabla.Columns.Add("E.F.");
            tabla.Columns.Add("RND C.P.");
            tabla.Columns.Add("C.P.");
            tabla.Columns.Add("F.I.");
            tabla.Columns.Add("F.A.");
            tabla.Columns.Add("FC 1");
            tabla.Columns.Add("FC 2");
            tabla.Columns.Add("FC 3");
            tabla.Columns.Add("FC 4");
            tabla.Columns.Add("FC 5");
            tabla.Columns.Add("E Inf");
            tabla.Columns.Add("C Inf");
            tabla.Columns.Add("E Act");
            tabla.Columns.Add("C Act");
            tabla.Columns.Add("EC 1");
            tabla.Columns.Add("EC 2");
            tabla.Columns.Add("EC 3");
            tabla.Columns.Add("EC 4");
            tabla.Columns.Add("EC 5");
            tabla.Columns.Add("C Caj");
            tabla.Columns.Add("Acum TEC");
            tabla.Columns.Add("Cant Esperan");
            tabla.Columns.Add("Acum ocup inf");
            tabla.Columns.Add("Acum ocioso act");
            tabla.Columns.Add("Max espera caja");
        }


        public void simular()
        {
            Linea lineaAnterior = new Linea(5);
            Linea lineaActual = null;

            int filaDesde = 0;
            int filaHasta = 100;

            for (int i = 0; i < 1000000; i++)
            {
                lineaActual = new Linea(lineaAnterior, this, filaDesde, filaHasta, i);
                lineaActual.calcularEvento();
                lineaActual.calcularSiguienteLlegada(40);
                lineaActual.calcularEstadoFactura(probabilidadesEstadosAcum, estadosFactura);
                lineaActual.calcularConoceProcedimiento(probabilidadesConoceProcedimientoAcum, conoceProcedimiento);
                lineaActual.calcularFinInforme(20);
                lineaActual.calcularFinActualizacion(20);
                lineaActual.calcularFinCobro(60);
                lineaAnterior = lineaActual;

                if (i >= filaDesde && i <= filaHasta)
                {
                    agregarLinea(lineaActual, i);
                }
            }

            MessageBox.Show("Promedio - " + ((double)lineaActual.acumuladorTiemposEsperaEnCaja / (double)lineaActual.cantidadClientesEsperan).ToString());
            construirTablaEntre(0, 10);

            pantallaResultados.mostrarResultados(temp);
        }


        private void construirTablaEntre(int desde, int hasta)
        {
            temp = new DataTable();
            for (int i = desde; i < hasta; i++)
            {
                temp.Columns.Add(resultados.Columns[i].ColumnName);
            }

            foreach(DataRow row in resultados.Rows)
            {
                var r = temp.Rows.Add();
                for (int j = desde; j < hasta; j++)
                {
                    var column = resultados.Columns[j].ColumnName;
                    r[column] = row[column];
                }
            }
        }

        public void agregarColumna()
        {
            cantidadClientes++;
            this.resultados.Columns.Add("E " + cantidadClientes);
            this.resultados.Columns.Add("HE " + cantidadClientes);
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
