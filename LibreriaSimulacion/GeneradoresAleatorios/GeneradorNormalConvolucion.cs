using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios
{
    class GeneradorNormalConvolucion : IGenerador
    {
        private Truncador truncador;
        private GeneradorUniformeLenguaje generadorLenguaje;
        private DataTable dataTable;
        private DataRow dataRow;

        private float[] aleatorios;
        private float aleatorio01;

        private double acumulado;
        private float aleatorio;

        // parametros
        private double desviacion;
        private double media;

        public GeneradorNormalConvolucion(DataTable tabla, GeneradorUniformeLenguaje generadorLenguaje, Truncador truncador, double desviacion, double media)
        {
            this.truncador = truncador;
            this.desviacion = desviacion;
            this.media = media;

            this.acumulado = 0;
            this.aleatorios = new float[12];
            this.generadorLenguaje = generadorLenguaje;
            this.dataTable = tabla; 
        }

        // retorna un aleatorio
        public float siguienteAleatorio()
        {
            acumulado = 0;
            for (int i = 0; i < aleatorios.Length; i++)
            {
                aleatorio01 = generadorLenguaje.siguienteAleatorio();
                aleatorios[i] = aleatorio01;
                acumulado += aleatorio01;
            }
            return truncador.truncar((acumulado - 6)*desviacion + media);
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
                dataRow[0] = i;
                dataRow[1] = aleatorio;
                dataTable.Rows.Add(dataRow);

                if (frecuenciaObservada != null) { frecuenciaObservada.contarNumero(aleatorio); }
            }
            return dataTable;
        }
    }
}
