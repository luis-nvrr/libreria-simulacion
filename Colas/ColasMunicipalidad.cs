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
        double[] probabilidadesEstadosAcum = new double[] { 0.0, 1 };
        string[] estadosFactura = new string[] { "vencida", "al dia" };

        double[] probabilidadesConoceProcedimientoAcum = new double[] { 0.6, 1 };
        string[] conoceProcedimiento = new string[] { "si", "no" };

        DataTable resultados;
        DataTable temp;
        private PantallaResultados pantallaResultados;
        private int cantidadClientes;
        private int indice;
        private int cantidadPaginas;
        private List<DataTable> paginas;


        public ColasMunicipalidad(PantallaResultados pantallaResultados)
        {
            this.pantallaResultados = pantallaResultados;
            resultados = new DataTable();
            crearTabla(resultados);
            this.paginas = new List<DataTable>();
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("iteracion");
            tabla.Columns.Add("evento");
            tabla.Columns.Add("reloj");
            tabla.Columns.Add("llegada cliente");
            tabla.Columns.Add("RND estado factura.");
            tabla.Columns.Add("estado factura");
            tabla.Columns.Add("RND conoce");
            tabla.Columns.Add("conoce procedimiento");
            tabla.Columns.Add("fin informacion");
            tabla.Columns.Add("fin actualizacion");
            tabla.Columns.Add("fin caja 1");
            tabla.Columns.Add("fin caja 2");
            tabla.Columns.Add("fin caja 3");
            tabla.Columns.Add("fin caja 4");
            tabla.Columns.Add("fin caja 5");
            tabla.Columns.Add("estado informes");
            tabla.Columns.Add("cola informes");
            tabla.Columns.Add("estado actualizacion");
            tabla.Columns.Add("cola actualizacion");
            tabla.Columns.Add("estado caja 1");
            tabla.Columns.Add("estado caja 2");
            tabla.Columns.Add("estado caja 3");
            tabla.Columns.Add("estado caja 4");
            tabla.Columns.Add("estado caja 5");
            tabla.Columns.Add("cola caja");
            tabla.Columns.Add("acumulado tiempo espera en caja");
            tabla.Columns.Add("cantidad que espera");
            tabla.Columns.Add("tiempo ocupacion informes");
            tabla.Columns.Add("tiempo ocioso actualizacion");
            tabla.Columns.Add("maxima espera en caja");
        }


        public void simular(int filaDesde, int filaHasta)
        {
            Linea lineaAnterior = new Linea(5);
            Linea lineaActual = null;


            for (int i = 1; i <= 1000; i++)
            {
                lineaActual = new Linea(lineaAnterior, this, filaDesde, filaHasta, i);
                lineaActual.calcularEvento();
                lineaActual.calcularSiguienteLlegada(20);
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

            construirPaginas();
        }

        private void construirPaginas()
        {
            MessageBox.Show("Columnas-" + (resultados.Columns.Count-1).ToString());
            cantidadPaginas = (int)Math.Ceiling((double)(resultados.Columns.Count-1) / (double)10);

            int columnasPorPagina = 7;
            for (int i = 1; i <= cantidadPaginas; i++)
            {
                int columnaDesde = i * columnasPorPagina - columnasPorPagina + 1;
                int columnaHasta = i * columnasPorPagina + 1;
                MessageBox.Show(columnaDesde.ToString() + "-" + columnaHasta.ToString());
                construirTablaEntre(columnaDesde, columnaHasta);
                paginas.Add(temp);
            }
        }

        public void mostrarPagina(int pagina)
        {
            if(pagina >=1 && pagina <= cantidadPaginas)
            {
                pantallaResultados.mostrarResultados(paginas[pagina - 1]);
            } 
        }


        private void construirTablaEntre(int desde, int hasta)
        {
            if(hasta > resultados.Columns.Count-1)
            {
                hasta = resultados.Columns.Count-1;
            }

            temp = new DataTable();

            temp.Columns.Add(resultados.Columns[0].ColumnName);
            for (int i = desde; i < hasta; i++)
            {
                temp.Columns.Add(resultados.Columns[i].ColumnName);
            }

            foreach(DataRow row in resultados.Rows)
            {
                var r = temp.Rows.Add();
                r[0] = row[0];
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
            this.resultados.Columns.Add("estado " + cantidadClientes);
            this.resultados.Columns.Add("hora espera " + cantidadClientes);
        }

        private void agregarLinea(Linea linea, int i)
        {
            DataRow row = resultados.NewRow();
            row[0] = i;
            row[1] = linea.evento;
            row[2] = linea.reloj;
            row[3] = linea.llegadaCliente;
            row[4] = linea.rndEstadoFactura;
            row[5] = linea.estadoFactura;
            row[6] = linea.rndConoceProcedimiento;
            row[7] = linea.conoceProcedimiento;
            row[8] = linea.ventanillaInforme.finInforme;
            row[9] = linea.ventanillaActualizacion.finActualizacion;
            row[10] = linea.cajas[0].finCobro;
            row[11] = linea.cajas[1].finCobro;
            row[12] = linea.cajas[2].finCobro;
            row[13] = linea.cajas[3].finCobro;
            row[14] = linea.cajas[4].finCobro;
            row[15] = linea.ventanillaInforme.estado;
            row[16] = linea.ventanillaInforme.cola.Count;
            row[17] = linea.ventanillaActualizacion.estado;
            row[18] = linea.ventanillaActualizacion.cola.Count;
            row[19]  = linea.cajas[0].estado;
            row[20] = linea.cajas[1].estado;
            row[21] = linea.cajas[2].estado;
            row[22] = linea.cajas[3].estado;
            row[23] = linea.cajas[4].estado;
            row[24] = linea.colaCaja;
            row[25] = linea.acumuladorTiemposEsperaEnCaja;
            row[26] = linea.cantidadClientesEsperan;
            row[27] = linea.acumuladorTiempoOcupacionVentanillaInformes;
            row[28] = linea.acumuladorTiempoOciosoVentanillaActualizacion;
            row[29] = linea.tiempoMaximoEsperaEnCola;

            indice = 29;
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
