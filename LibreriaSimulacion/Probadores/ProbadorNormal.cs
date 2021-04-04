﻿using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
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
        private double media;
        private double desviacion;

        public ProbadorNormal(Truncador truncador, DataTable numeros,
            double media, double desviacion, float[] inicioIntervalos, float[] finIntervalos, int[] frecuenciasObservadas)
        {
            this.numeros = numeros;
            this.media = media;
            this.desviacion = desviacion;
            this.cantidadIntervalos = inicioIntervalos.Length;
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
            this.frecuenciasObservadas = frecuenciasObservadas;
            this.truncador = truncador;
            this.resultado = new DataTable();

            crearTabla(resultado);
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

        private void reestructurarTabla()
        {
            DataTable nuevaTabla = new DataTable();
            crearTabla(nuevaTabla);

            float esperadaTablaVieja;
            float esperadaAcumulada = 0;

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                esperadaTablaVieja = float.Parse(resultado.Rows[i][4].ToString());
                esperadaAcumulada += esperadaTablaVieja;

            }
        }

    }
}