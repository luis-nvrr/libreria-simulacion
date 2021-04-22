using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using Numeros_aleatorios.LibreriaSimulacion.Probadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Numeros_aleatorios.Pantallas
{
    class GestorPoisson
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;

        int[] valoresDiscretos;
        int[] frecuenciasObservadas;

        double lambda;
        int cantidadValores;
        float menor;
        float mayor;

        DataTable tablaAleatorios;
        PantallaVariablesAleatorias pantalla;

        public GestorPoisson(PantallaVariablesAleatorias pantalla)
        {
            this.truncador = new Truncador(4);
            this.generadorLenguaje = new GeneradorUniformeLenguaje(truncador);
            this.pantalla = pantalla;
        }

        private void crearTabla()
        {
            tablaAleatorios = new DataTable();
            tablaAleatorios.Columns.Add("iteracion");
            tablaAleatorios.Columns.Add("aleatorio");
        }

        public void generarPoisson(double lambda, double media, int cantidadValores)
        {
            this.cantidadValores = cantidadValores;
            this.lambda = lambda;

            crearTabla();
            ContadorFrecuenciaObservada contador = new ContadorFrecuenciaObservada();
            IGenerador generadorDistribucion = new GeneradorPoisson(tablaAleatorios, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores, contador);

            contador.ordenarSeriePoisson();
            frecuenciasObservadas = contador.getFrecuenciasPoisson();
            valoresDiscretos = contador.getValoresPoisson();

            pantalla.mostrarResultados(tablaAleatorios);
            graficar();
        }

        public void probar()
        {
            double[] temp = valoresDiscretos.Select(l => (double)l - 0.00001).ToArray();
            IProbador probador;
            probador = new ProbadorPoisson(truncador, tablaAleatorios, lambda, valoresDiscretos, frecuenciasObservadas);
 
            PantallaPruebaChi2 pantallaPrueba = new PantallaPruebaChi2();
            pantallaPrueba.probador = probador;
            pantallaPrueba.Show();
        }
        public String copiar()
        {
            return CopiadorTabla.tablaToString(tablaAleatorios);
        }
        public void graficar()
        {
            GraficadorExcelObservado graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = this.frecuenciasObservadas;
            graficador.nombre = "Poisson";
            graficador.valoresDiscretos = this.valoresDiscretos;
            pantalla.mostrarGrafico(graficador);
        }
    }
}
