using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.LibreriaSimulacion.Probadores
{
    class ProbadorExponencial : IProbador
    {
        private DataTable numeros;
        private float[] inicioIntervalos;

        private float[] finIntervalos;
        private int[] frecuenciasObservadas;
        private int cantidadIntervalos;
        private DataTable resultado;
        private Truncador truncador;
        private float valorCritico;
        private float menor;
        private float mayor;
        private double lambda;
        private double media;

        public ProbadorExponencial(Truncador truncador, DataTable numeros,
                                   double media, double lambda,
                                   int cantidadIntervalos, float mayor, float menor)
        {
            this.numeros = numeros;
            this.truncador = truncador;
            this.media = media;
            this.lambda = lambda;
            this.cantidadIntervalos = cantidadIntervalos;
            this.mayor = mayor;
            this.menor = menor;

            this.resultado = new DataTable();
            crearTabla(resultado);
        }
        private void crearTabla(DataTable tabla)
        {
            resultado.Columns.Add("intervalo");
            resultado.Columns.Add("MC");
            resultado.Columns.Add("FO");
            resultado.Columns.Add("P(x)");
            resultado.Columns.Add("FE");
            resultado.Columns.Add("C");
            resultado.Columns.Add("C(AC)");
        }
        private void obtenerIntervalos()
        {
            GeneradorIntervalosNormal generadorIntervalos = new GeneradorIntervalosNormal(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);
            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }
        private void obtenerFrecuenciasObservadas()
        {
            ContadorFrecuenciaObservada contadorFrecuencias = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            contadorFrecuencias.contarFrecuenciaSerie(numeros);
            frecuenciasObservadas = contadorFrecuencias.obtenerFrecuencias();
        }

        public bool esAceptado()
        {
            return compararEstadisticoConAcumulado();
        }

        public float getValorCritico()
        {
            return valorCritico;
        }
        private int calcularGradosLibertad()
        {
            return cantidadIntervalos - 1;
        }

        public DataTable obtenerTablaResultados()
        {
            return resultado;
        }

        public float obtenerTotalAcumuladoEstadisticoPrueba()
        {
            return float.Parse(resultado.Rows[resultado.Rows.Count - 1][6].ToString());
        }

        public void probar()
        {
            obtenerIntervalos();
            obtenerFrecuenciasObservadas();
            construirTabla();
        }

        private void construirTabla()
        {
            DataRow row;
            double estadisticoPrueba;
            double estadisticoPruebaAcumuladoAnterior = 0;
            float marcaClase;
            double funcionDensidad;
            double probabilidad;
            float cantidadNumeros = numeros.Rows.Count;
            double frecuenciaEsperada;

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                row = resultado.NewRow();
                row[0] = "[" + inicioIntervalos[i] + "-" + finIntervalos[i] + "]";

                marcaClase = truncador.truncar((inicioIntervalos[i] + finIntervalos[i]) / 2.0f);
                row[1] = marcaClase;

                row[2] = frecuenciasObservadas[i];

                probabilidad = (1 - Math.Exp(-lambda * finIntervalos[i])) - (1 - Math.Exp(-lambda * inicioIntervalos[i]));
                row[3] = truncador.truncar(probabilidad);

                frecuenciaEsperada = probabilidad * cantidadNumeros;
                row[4] = truncador.truncar(frecuenciaEsperada);

                estadisticoPrueba = (Math.Pow((frecuenciaEsperada - frecuenciasObservadas[i]), 2) / frecuenciaEsperada);
                row[5] = truncador.truncar(estadisticoPrueba);

                row[6] = truncador.truncar(estadisticoPruebaAcumuladoAnterior + estadisticoPrueba);
                estadisticoPruebaAcumuladoAnterior += estadisticoPrueba;

                resultado.Rows.Add(row); //Agrega una fila completa


            }
        }
        private float obtenerValorCritico(int gradosLibertad)
        {
            return ValorCriticoChi2.obtenerValorCritico(gradosLibertad);
        }
        private Boolean compararEstadisticoConAcumulado()
        {
            int gradosLibertad = calcularGradosLibertad();
            valorCritico = obtenerValorCritico(gradosLibertad);

            if (valorCritico > obtenerTotalAcumuladoEstadisticoPrueba())
            {
                return true;
            }
            return false;
        }

        public int[] getFrecuenciasObservadas()
        {
            return this.frecuenciasObservadas;
        }

        public float[] getInicioIntervalos()
        {
            return this.inicioIntervalos;
        }

        public float[] getFinIntervalos()
        {
            return this.finIntervalos;
        }

    }
}
