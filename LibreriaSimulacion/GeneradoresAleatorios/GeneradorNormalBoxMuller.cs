using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios
{
    class GeneradorNormalBoxMuller : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private float aleatorio01_1;
        private float aleatorio01_2;
        private float aleatorio;

        // parametros
        private double desviacion;
        private double media;

        private Boolean esNecesarioGenerar;

        public GeneradorNormalBoxMuller(DataTable tabla, GeneradorUniformeLenguaje generadorLenguaje, Truncador truncador, double desviacion, double media)
        {
            this.truncador = truncador;
            this.desviacion = desviacion;
            this.media = media;

            this.generadorLenguaje = generadorLenguaje;

            this.dataTable = tabla;
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            if (esNecesarioGenerar)
            {
                aleatorio01_1 = generadorLenguaje.siguienteAleatorio();
                aleatorio01_2 = generadorLenguaje.siguienteAleatorio();

                return truncador.truncar((Math.Sqrt(-2 * Math.Log(aleatorio01_1)) * Math.Cos(2 * Math.PI * aleatorio01_2)) * desviacion + media);
            }
            return truncador.truncar((Math.Sqrt(-2 * Math.Log(aleatorio01_1)) * Math.Sin(2 * Math.PI * aleatorio01_2)) * desviacion + media);
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
                if(i % 2 == 0) { esNecesarioGenerar = true; }
                aleatorio = siguienteAleatorio();
                dataRow = dataTable.NewRow();
                dataRow[0] = i+1;
                dataRow[1] = aleatorio;
                dataTable.Rows.Add(dataRow);

                if (frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
            }
            return dataTable;
        }
    }
}
