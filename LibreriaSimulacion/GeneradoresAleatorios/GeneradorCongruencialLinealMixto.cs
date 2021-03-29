﻿using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System.Data;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorCongruencialLinealMixto : IGenerador
    {
        // para la cantidad de decimales de los aleatorios
        private Truncador truncador;
        private DataTable dataTable;
        private DataRow dataRow;

        private long entradaAnterior;
        private long entradaActual;
        private double aleatorioActual;

        private float aleatorio;

        // parametros
        private int c;
        private int a;
        private long m;

        public GeneradorCongruencialLinealMixto(Truncador truncador, long semilla, int c, int a, long m)
        {
            this.entradaAnterior = semilla;
            this.truncador = truncador;
            this.a = a;
            this.c = c;
            this.m = m;
            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("iteracion");
            this.dataTable.Columns.Add("aleatorio");
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            entradaActual = ((a * entradaAnterior) + c) % (m);
            aleatorioActual = (double)entradaActual / (m - 1); // (m-1) para incluir el 1 
            entradaAnterior = entradaActual;
            return truncador.truncar(aleatorioActual);
        }

        public DataTable generarSerie(int cantidadAleatorios)
        {
            return this.generarSerie(cantidadAleatorios, null);
        }

        public DataTable generarSerie(int cantidadAleatorios, ContadorFrecuenciaObservada frecuenciaObservada)
        {
            dataTable.Rows.Clear();

            for (int i = 0; i < cantidadAleatorios; i++)
            {
                aleatorio = siguienteAleatorio();
                dataRow = dataTable.NewRow();
                dataRow["iteracion"] = i;
                dataRow["aleatorio"] = aleatorio;
                dataTable.Rows.Add(dataRow);

                if (frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
            }
            return dataTable;
        }

    }
}
