using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System;
using System.Data;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorUniformeLenguaje : IGenerador
    {
        Random random;
        Truncador truncador;
        private DataTable dataTable;
        private DataRow dataRow;

        private float aleatorio;

        public GeneradorUniformeLenguaje(Truncador truncador)
        {
            this.random = new Random();
            this.truncador = truncador;
            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("iteracion");
            this.dataTable.Columns.Add("aleatorio");
        }

        public float siguienteAleatorio()
        {
            return truncador.truncar(random.NextDouble());
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
