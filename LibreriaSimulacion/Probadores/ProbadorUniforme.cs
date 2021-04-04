﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class ProbadorUniforme
    {
        private DataTable numeros;
        private float[] inicioIntervalos;
        private float[] finIntervalos;
        private int[] frecuenciasObservadas;
        private int cantidadIntervalos;
        private DataTable resultado;
        private Truncador truncador;
        private float valorCritico;

        public ProbadorUniforme(Truncador truncador, DataTable numeros,
            float[] inicioIntervalos, float[] finIntervalos, int[] frecuenciasObservadas)
        {
            this.truncador = truncador;
            this.numeros = numeros;
            this.inicioIntervalos = inicioIntervalos;
            this.finIntervalos = finIntervalos;
            this.cantidadIntervalos = inicioIntervalos.Length;
            this.frecuenciasObservadas = frecuenciasObservadas;

            this.resultado = new DataTable();
            crearTabla();
        }
        
        public float getValorCritico()
        {
            return valorCritico;
        }

        private void crearTabla()
        {
            this.resultado.Columns.Add("intervalo");
            this.resultado.Columns.Add("FO");
            this.resultado.Columns.Add("FE");
            this.resultado.Columns.Add("C");
            this.resultado.Columns.Add("C(AC)");
        }

        public void probar()
        {
            double frecuenciaEsperada = truncador.truncar(numeros.Rows.Count / cantidadIntervalos);
            contruirTabla(frecuenciaEsperada);
        }
        public Boolean esAceptado() {
            return compararEstadisticoConAcumulado();
        }

        public DataTable obtenerTablaResultados()
        {
            return resultado;
        }

        private Boolean compararEstadisticoConAcumulado()
        {
            int gradosLibertad = calcularGradosLibertad();
            valorCritico = obtenerValorCritico(gradosLibertad);
            
            if(valorCritico > obtenerTotalAcumuladoEstadisticoPrueba())
            {
                return true;
            }
            return false;
        }

        private int calcularGradosLibertad()
        {
            return cantidadIntervalos - 1;
        }

        private float obtenerValorCritico(int gradosLibertad)
        {
            return ValorCriticoChi2.obtenerValorCritico(gradosLibertad);
        }

        public float obtenerTotalAcumuladoEstadisticoPrueba()
        {
            return float.Parse(resultado.Rows[resultado.Rows.Count - 1][4].ToString());
        }

        private void contruirTabla(double frecuenciaEsperada)
        {
            DataRow row;
            double estadisticoPrueba;
            double estadisticoPruebaAcumuladoAnterior = 0;

            for (int i = 0; i < cantidadIntervalos; i++)
            {
                row = resultado.NewRow();
                row[0] = "[" + inicioIntervalos[i] + "-" + finIntervalos[i] + "]";
                row[1] = frecuenciasObservadas[i];
                row[2] = frecuenciaEsperada;
                estadisticoPrueba = (Math.Pow((frecuenciaEsperada - frecuenciasObservadas[i]), 2) / frecuenciaEsperada);
                row[3] = truncador.truncar(estadisticoPrueba);
                row[4] = truncador.truncar(estadisticoPruebaAcumuladoAnterior + estadisticoPrueba);
                estadisticoPruebaAcumuladoAnterior += estadisticoPrueba;
                resultado.Rows.Add(row);
            }
        }


    }
}