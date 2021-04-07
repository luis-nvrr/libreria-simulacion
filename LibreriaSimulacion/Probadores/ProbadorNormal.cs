using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.LibreriaSimulacion.Probadores
{
    class ProbadorNormal : IProbador
    {
        private DataTable numeros;
        private float[] inicioIntervalos;
        private float[] finIntervalos;
        private int[] frecuenciasObservadas;
        private float[] frecuenciasEsperadas;
        private float[] probabilidades;
        private DataTable resultado;
        private Truncador truncador;
        private float valorCritico;
        private double media;
        private double desviacion;

        public ProbadorNormal(Truncador truncador, DataTable numeros,
            double media, double desviacion, float[] inicioIntervalos, float[] finIntervalos, int[] frecuenciasObservadas)
        {
            this.numeros = numeros;
            this.media = media;
            this.desviacion = desviacion;
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
            this.frecuenciasObservadas = frecuenciasObservadas;
            this.truncador = truncador;
        }

        private void crearTabla(DataTable tabla)
        {
            tabla.Columns.Add("intervalo");
            tabla.Columns.Add("MC");
            tabla.Columns.Add("FO");
            tabla.Columns.Add("P(x)");
            tabla.Columns.Add("FE");
            tabla.Columns.Add("C");
            tabla.Columns.Add("C(AC)");
        }

        public void probar()
        {
            construirTablaInicial();
            reestructurarTabla();
            construirTablaFinal();
        }

        private void construirTablaInicial()
        {
            this.resultado = new DataTable();
            crearTabla(resultado);
            DataRow row;
            double estadisticoPrueba;
            double estadisticoPruebaAcumuladoAnterior = 0;
            float marcaClase;
            double funcionDensidad;
            double probabilidad;
            float cantidadNumeros = numeros.Rows.Count;
            double frecuenciaEsperada;

            for (int i = 0; i < inicioIntervalos.Length; i++)
            {
                row = resultado.NewRow();
                row[0] = "[" + inicioIntervalos[i] + "-" + finIntervalos[i] + "]";

                marcaClase = truncador.truncar((inicioIntervalos[i] + finIntervalos[i]) / 2.0f);
                row[1] = marcaClase;

                row[2] = frecuenciasObservadas[i];

                // utiliza marcas de clase
                //funcionDensidad = (1.0f / (desviacion * Math.Sqrt(2 * Math.PI))) * Math.Exp((-0.5f) * Math.Pow((marcaClase - media) / desviacion, 2));
                //probabilidad = funcionDensidad * (finIntervalos[i] - inicioIntervalos[i]);
                //row[3] = truncador.truncar(probabilidad);  // probabilidad

                // utiliza tabla normal
                probabilidad = TablaNormal.normal((finIntervalos[i] - media) / desviacion) - TablaNormal.normal((inicioIntervalos[i] - media) / desviacion);
                row[3] = truncador.truncar(probabilidad);
                MessageBox.Show(TablaNormal.normal(1.45f).ToString());

                frecuenciaEsperada = (probabilidad * cantidadNumeros);
                row[4] = truncador.truncar(frecuenciaEsperada); // frecuenciaEsperada

                // a partir de aqui no es necesario
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
            return inicioIntervalos.Length - 1;
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

        private void reestructurarTabla()
        {
            float esperadaTablaVieja;
            double esperadaAcumulada = 0;
            int observadaAcumulada = 0;
            float probabilidadTablaVieja;
            double probabilidadAcumulada = 0;
            List<float> nuevoInicioIntervalos = new List<float>();
            List<float> nuevoFinIntervalos = new List<float>();
            List<int> nuevaFrecuenciaObservada = new List<int>();
            List<float> nuevaFrecuenciaEsperada = new List<float>();
            List<float> nuevaProbabilidad = new List<float>();
            float nuevoInicioIntervalo = 0;
            float nuevoFinIntervalo = 0;

            for (int i = 0; i < inicioIntervalos.Length; i++)
            {
                if (esperadaAcumulada == 0) { nuevoInicioIntervalo = inicioIntervalos[i]; }
                esperadaTablaVieja = float.Parse(resultado.Rows[i][4].ToString());
                esperadaAcumulada += esperadaTablaVieja;
                probabilidadTablaVieja= float.Parse(resultado.Rows[i][3].ToString());
                probabilidadAcumulada += probabilidadTablaVieja;
                observadaAcumulada += frecuenciasObservadas[i];

                if (esperadaAcumulada > 5) 
                { 
                    nuevoFinIntervalo = finIntervalos[i];
              
                    nuevoInicioIntervalos.Add(nuevoInicioIntervalo);
                    nuevoFinIntervalos.Add(nuevoFinIntervalo);
                    nuevaFrecuenciaObservada.Add(observadaAcumulada);
                    nuevaFrecuenciaEsperada.Add(truncador.truncar(esperadaAcumulada));
                    nuevaProbabilidad.Add(truncador.truncar(probabilidadAcumulada));

                    probabilidadAcumulada = 0;
                    esperadaAcumulada = 0;
                    observadaAcumulada = 0;
                }
            }

            nuevoFinIntervalos[nuevoFinIntervalos.Count - 1] = finIntervalos[inicioIntervalos.Length - 1];
            nuevaFrecuenciaObservada[nuevoFinIntervalos.Count - 1] += observadaAcumulada;
            nuevaFrecuenciaEsperada[nuevoFinIntervalos.Count - 1] = truncador.truncar(esperadaAcumulada + nuevaFrecuenciaEsperada[nuevoFinIntervalos.Count - 1]);
            nuevaProbabilidad[nuevoFinIntervalos.Count - 1] = truncador.truncar(nuevaProbabilidad[nuevoFinIntervalos.Count - 1] + probabilidadAcumulada);

            this.inicioIntervalos = nuevoInicioIntervalos.ToArray();
            this.finIntervalos = nuevoFinIntervalos.ToArray();
            this.frecuenciasObservadas = nuevaFrecuenciaObservada.ToArray();
            this.frecuenciasEsperadas = nuevaFrecuenciaEsperada.ToArray();
            this.probabilidades = nuevaProbabilidad.ToArray();
            //MessageBox.Show(mostrarNuevosIntervalos(nuevoInicioIntervalos, nuevoFinIntervalos));
        }


        private void arreglarUltimaFila()
        {

        }

        private void construirTablaFinal()
        {
            this.resultado = new DataTable();
            crearTabla(resultado);
            DataRow row;
            double estadisticoPrueba;
            double estadisticoPruebaAcumuladoAnterior = 0;
            float marcaClase;
            float frecuenciaEsperada;

            for (int i = 0; i < inicioIntervalos.Length; i++)
            {
                row = resultado.NewRow();
                row[0] = "[" + inicioIntervalos[i] + "-" + finIntervalos[i] + "]";

                marcaClase = truncador.truncar((inicioIntervalos[i] + finIntervalos[i]) / 2.0f);
                row[1] = marcaClase;

                row[2] = frecuenciasObservadas[i];

                row[3] = probabilidades[i];  // probabilidad

                frecuenciaEsperada = frecuenciasEsperadas[i];
                row[4] = frecuenciaEsperada; // frecuenciaEsperada

                estadisticoPrueba = (Math.Pow((frecuenciaEsperada - frecuenciasObservadas[i]), 2) / frecuenciaEsperada);
                row[5] = truncador.truncar(estadisticoPrueba);
                row[6] = truncador.truncar(estadisticoPruebaAcumuladoAnterior + estadisticoPrueba);
                estadisticoPruebaAcumuladoAnterior += estadisticoPrueba;
                resultado.Rows.Add(row);
            }
        }

        private String mostrarNuevosIntervalos(List<float> inicio, List<float> fin)
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < inicio.Count; i++)
            {
                stringBuilder.Append(inicio[i]).Append(" ").Append(fin[i]);
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

    }
}
