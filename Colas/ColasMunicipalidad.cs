using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Colas
{
    class ColasMunicipalidad
    {
        double[] probabilidadesEstadosAcum = new double[] { 0.4, 1 };
        string[] estadosFactura = new string[] { "vencida", "al dia" };

        double[] probabilidadesConoceProcedimientoAcum = new double[] { 0.8, 1 };
        string[] conoceProcedimiento = new string[] { "si", "no" };

        DataTable resultados;
        List<string> lineaAnterior;
        List<string> lineaActual;

        private PantallaResultados pantallaResultados;

        public ColasMunicipalidad(PantallaResultados pantallaResultados)
        {
            this.pantallaResultados = pantallaResultados;
            resultados = new DataTable();
        }

        public void simular()
        {
            Linea lineaAnterior = new Linea(5);
            Linea lineaActual = new Linea(lineaAnterior);


            for (int i = 1; i < 100; i++)
            {
                lineaActual.calcularEvento();
                lineaActual.calcularSiguienteLlegada(60);
                lineaActual.calcularEstadoFactura(probabilidadesEstadosAcum, estadosFactura);
                lineaActual.calcularConoceProcedimiento(probabilidadesConoceProcedimientoAcum, conoceProcedimiento);
                lineaActual.calcularFinInforme(20);
                lineaActual.calcularFinActualizacion(40);
            }




            pantallaResultados.mostrarResultados(resultados);
        }

    }
}
