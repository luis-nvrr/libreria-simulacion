using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios
{
    class GeneradorExponencialNegativa : IGenerador
    {

        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private float aleatorio01;
        private float aleatorio;

        // parametros
        private double lambda;

        public GeneradorExponencialNegativa(Truncador truncador, double lambda)
        {
            this.truncador = truncador;
            this.lambda = lambda;

            this.generadorLenguaje = new GeneradorUniformeLenguaje(truncador);

            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("iteracion");
            this.dataTable.Columns.Add("aleatorio");
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            aleatorio01 = generadorLenguaje.siguienteAleatorio();
            return truncador.truncar((-1/lambda)*(Math.Log(1-aleatorio01)));
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
