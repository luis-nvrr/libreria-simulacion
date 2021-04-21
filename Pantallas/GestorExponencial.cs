using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
using Numeros_aleatorios.LibreriaSimulacion.Probadores;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Pantallas
{
    class GestorExponencial
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;
        GraficadorExcelObservado graficador;

        float[] inicioIntervalos;
        float[] finIntervalos;

        int[] frecuenciasObservadas;

        double lambda;
        double media;
        int cantidadIntervalos;
        int cantidadValores;
        float menor;
        float mayor;

        DataTable tablaAleatorios;
        PantallaVariablesAleatorias pantalla;

        public GestorExponencial(PantallaVariablesAleatorias pantalla)
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

        public void generarExponencial(double lambda, double media, int cantidadValores, int cantidadIntervalos)
        {
            if (lambda < 0) { return; }

            this.lambda = lambda;
            this.media = media;
            this.cantidadIntervalos = cantidadIntervalos;
            this.cantidadValores = cantidadValores;

            crearTabla();

            IGenerador generadorDistribucion = new GeneradorExponencialNegativa(tablaAleatorios, generadorLenguaje, truncador, lambda);
            generadorDistribucion.generarSerie(cantidadValores);

            this.menor = ((GeneradorExponencialNegativa)generadorDistribucion).getMenor();
            this.mayor = ((GeneradorExponencialNegativa)generadorDistribucion).getMayor();

            generarIntervalosExponencial();
            obtenerFrecuenciasObservadasExponencial();
            pantalla.mostrarResultados(tablaAleatorios);
        }

        private void generarIntervalosExponencial()
        {
            GeneradorIntervalosNormal generadorIntervalos = new GeneradorIntervalosNormal(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);

            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        private void obtenerFrecuenciasObservadasExponencial()
        {
            ContadorFrecuenciaObservada contadorFrecuencias = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            contadorFrecuencias.contarFrecuenciaSerie(tablaAleatorios);

            this.frecuenciasObservadas = contadorFrecuencias.obtenerFrecuencias();
        }

        public void probar()
        {
            IProbador probador = new ProbadorExponencial(truncador, tablaAleatorios, media, lambda, cantidadIntervalos, inicioIntervalos, finIntervalos, frecuenciasObservadas);
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
            graficador.nombre = "Exponencial";
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            pantalla.mostrarGrafico(graficador);
        }

    }
}
