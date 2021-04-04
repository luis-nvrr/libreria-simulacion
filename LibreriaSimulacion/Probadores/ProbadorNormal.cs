using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion.Probadores
{
    class ProbadorNormal : IProbador
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
        private double media;
        private double desviacion;

        public ProbadorNormal(Truncador truncador, DataTable numeros,
            double media, double desviacion,
            int cantidadIntervalos, float menor, float mayor)
        {
            this.numeros = numeros;
            this.media = media;
            this.desviacion = desviacion;
            this.cantidadIntervalos = cantidadIntervalos;
            this.menor = menor;
            this.mayor = mayor;
            this.truncador = truncador;
            this.resultado = new DataTable();

            crearTabla();
        }

        private void crearTabla()
        {
            resultado.Columns.Add("intervalo");
            resultado.Columns.Add("MC");
            resultado.Columns.Add("FO");
            resultado.Columns.Add("P(x)");
            resultado.Columns.Add("FE");
            resultado.Columns.Add("C");
            resultado.Columns.Add("C(AC)");
        }

        public void probar()
        {
            obtenerIntervalos();
            obtenerFrecuenciasObservadas();
            construirTabla();
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

                funcionDensidad = (1.0f / (desviacion * Math.Sqrt(2 * Math.PI))) * Math.Exp((-0.5f) * Math.Pow((marcaClase - media) / desviacion, 2));
                probabilidad = funcionDensidad * (finIntervalos[i] - inicioIntervalos[i]);
                row[3] = truncador.truncar(probabilidad);  // probabilidad

                frecuenciaEsperada = (probabilidad * cantidadNumeros);
                row[4] = truncador.truncar(frecuenciaEsperada); // frecuenciaEsperada

                estadisticoPrueba = (Math.Pow((frecuenciaEsperada - frecuenciasObservadas[i]), 2) / frecuenciaEsperada);
                row[5] = truncador.truncar(estadisticoPrueba);
                row[6] = truncador.truncar(estadisticoPruebaAcumuladoAnterior + estadisticoPrueba);
                estadisticoPruebaAcumuladoAnterior += estadisticoPrueba;
                resultado.Rows.Add(row);
            }
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

        private int calcularGradosLibertad()
        {
            return cantidadIntervalos - 1;
        }

        public bool esAceptado()
        {
            return compararEstadisticoConAcumulado();
        }

        private float obtenerValorCritico(int gradosLibertad)
        {
            return ValorCriticoChi2.obtenerValorCritico(gradosLibertad);
        }

        public DataTable obtenerTablaResultados()
        {
            return resultado;
        }

        public float obtenerTotalAcumuladoEstadisticoPrueba()
        {
            return float.Parse(resultado.Rows[resultado.Rows.Count - 1][6].ToString());
        }

        public float getValorCritico()
        {
            return valorCritico;
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
