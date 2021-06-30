using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Colas
{
    class Simulacion
    {
        double[] probabilidadesEstadosAcum = new double[] { 0.4, 1 };
        string[] estadosFactura = new string[] { "vencida", "al dia" };

        double[] probabilidadesConoceProcedimientoAcum = new double[] { 0.8, 1 };
        string[] conoceProcedimiento = new string[] { "si", "no" };

        DataTable resultados;
        DataTable temp;
        private PantallaResultados pantallaResultados;
        private int cantidadClientes;
        private int indice;
        private int cantidadPaginas;
        private List<DataTable> paginas;
        private LineaVector lineaActual;


        public Simulacion(PantallaResultados pantallaResultados)
        {
            this.pantallaResultados = pantallaResultados;
            resultados = new DataTable();
            crearTabla(resultados);
            this.paginas = new List<DataTable>();
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("i");
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


        public void simular(int filaDesde, int filaHasta, int cantSimulaciones, int TiempoLlegada, int TiempoFinInforme, int TiempoFinActualizacion, int TiempoFinCobro)
        {
            LineaVector lineaAnterior = new LineaVector(5,TiempoLlegada);
            int i;

            agregarLinea(lineaAnterior, 0);

            for (i = 1; i <= cantSimulaciones; i++)
            {
                lineaActual = new LineaVector(lineaAnterior, this, filaDesde, filaHasta, i);
                lineaActual.calcularEvento();
                lineaActual.calcularSiguienteLlegada(TiempoLlegada);
                lineaActual.calcularEstadoFactura(probabilidadesEstadosAcum, estadosFactura);
                lineaActual.calcularConoceProcedimiento(probabilidadesConoceProcedimientoAcum, conoceProcedimiento);
                lineaActual.calcularFinInforme(TiempoFinInforme);
                lineaActual.calcularColumnaFinActualizacion(TiempoFinActualizacion);
                lineaActual.calcularFinCobro(TiempoFinCobro);
                lineaAnterior = lineaActual;

                if (i >= filaDesde && i <= filaHasta)
                {
                    agregarLinea(lineaActual, i);
                }
            }

            agregarLinea(lineaActual, lineaActual.idFila);
            pantallaResultados.mostrarResultados(resultados);
            //construirPaginas();
        }

        private void construirPaginas()
        {
            int columnasPorPagina = 8;
            cantidadPaginas = (int)Math.Ceiling((double)(resultados.Columns.Count-1) / (double)columnasPorPagina);

            for (int i = 1; i <= cantidadPaginas; i++)
            {
                int columnaDesde = i * columnasPorPagina - columnasPorPagina + 1;
                int columnaHasta = i * columnasPorPagina + 1;
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

        public void calcularEstadisticas()
        {
            int tamañoTabla = resultados.Rows.Count-1;
            string tiempoEspera = resultados.Rows[tamañoTabla][25].ToString();
            string cantidadEspera = resultados.Rows[tamañoTabla][26].ToString();
            double tiempoPromedioEsperaEnCajas = cantidadEspera != "0" ?
                                                    double.Parse(tiempoEspera) / double.Parse(cantidadEspera) : 0;


            string ocupacionInformes = resultados.Rows[tamañoTabla][27].ToString();
            double tiempoOcupacionInformes = double.Parse(ocupacionInformes);

            string ociosoActualizacion = resultados.Rows[tamañoTabla][28].ToString();
            double tiempoOciosoActualizacion = double.Parse(ociosoActualizacion);

            string maximaEsperaCaja = resultados.Rows[tamañoTabla][29].ToString();
            double tiempoMaximoEsperaCaja = double.Parse(maximaEsperaCaja);

            pantallaResultados.mostrarEstadisticas(tiempoPromedioEsperaEnCajas, tiempoOcupacionInformes, 
                tiempoOciosoActualizacion, tiempoMaximoEsperaCaja);
        }


        private void construirTablaEntre(int desde, int hasta)
        {
            if(hasta > resultados.Columns.Count)
            {
                hasta = resultados.Columns.Count;
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

        private void agregarLinea(LineaVector linea, int i)
        {
            DataRow row = resultados.NewRow();
            row[0] = i;
            row[1] = linea.evento;
            row[2] = linea.reloj;
            row[3] = linea.llegadaCliente;
            row[4] = linea.rndEstadoFactura.ToString() != "-1" ? linea.rndEstadoFactura.ToString() : "";
            row[5] = linea.estadoFactura;
            row[6] = linea.rndConoceProcedimiento.ToString() != "-1" ? linea.rndConoceProcedimiento.ToString() : "";
            row[7] = linea.conoceProcedimiento;
            row[8] = linea.ventanillaInforme.finInforme.ToString() != "-1" ? linea.ventanillaInforme.finInforme.ToString() : "";
            row[9] = linea.ventanillaActualizacion.finActualizacion.ToString() != "-1" ? linea.ventanillaActualizacion.finActualizacion.ToString() : "";
            row[10] = linea.cajas[0].finCobro.ToString() != "-1" ? linea.cajas[0].finCobro.ToString() : "" ;
            row[11] = linea.cajas[1].finCobro.ToString() != "-1" ? linea.cajas[1].finCobro.ToString() : "";
            row[12] = linea.cajas[2].finCobro.ToString() != "-1" ? linea.cajas[2].finCobro.ToString() : "";
            row[13] = linea.cajas[3].finCobro.ToString() != "-1" ? linea.cajas[3].finCobro.ToString() : "";
            row[14] = linea.cajas[4].finCobro.ToString() != "-1" ? linea.cajas[4].finCobro.ToString() : "";
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
                    row[indice] = linea.clientes[j].horaLLegadaACaja.ToString() != "-1" ? linea.clientes[j].horaLLegadaACaja.ToString() : ""; ;
                }
            resultados.Rows.Add(row);

         
        }

    }
}
