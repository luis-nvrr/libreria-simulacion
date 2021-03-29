using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System.Data;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    class GeneradorUniformeAB : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorUniforme;
        private DataTable dataTable;
        private DataRow dataRow;

        private float aleatorio01;
        private float aleatorio;

        // parametros
        private float b;
        private float a;

        public GeneradorUniformeAB(Truncador truncador, double a, double b)
        {
            this.truncador = truncador;
            this.a = truncador.truncar(a);
            this.b = truncador.truncar(b);

            this.generadorUniforme = new GeneradorUniformeLenguaje(truncador);

            this.dataTable = new DataTable();
            this.dataTable.Columns.Add("iteracion");
            this.dataTable.Columns.Add("aleatorio");
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            aleatorio01 = generadorUniforme.siguienteAleatorio();
            return truncador.truncar(a + aleatorio01 * (b - a));
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

                if( frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
            }
            return dataTable;
        }
    }
}
