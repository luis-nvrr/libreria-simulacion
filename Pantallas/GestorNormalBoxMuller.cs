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

namespace Numeros_aleatorios.Pantallas
{
    class GestorNormalBoxMuller
    {
        GeneradorUniformeLenguaje generadorLenguaje;
        Truncador truncador;
        GraficadorExcelObservado graficador;

        double[] inicioIntervalos;
        double[] finIntervalos;

        int[] frecuenciasObservadas;

        double desviacion;
        double media;
        int cantidadIntervalos;
        int cantidadValores;
        double menor;
        double mayor;

        DataTable tablaAleatorios;
        PantallaVariablesAleatorias pantalla;

        public GestorNormalBoxMuller(PantallaVariablesAleatorias pantalla)
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


        public void generarNormalBoxMuller(double media, double desviacion, int cantidadValores, int cantidadIntervalos)
        {

            this.media = media;
            this.desviacion = desviacion;
            this.cantidadValores = cantidadValores;
            this.cantidadIntervalos = cantidadIntervalos;
            crearTabla();

            IGenerador generadorDistribucion = new GeneradorNormalBoxMuller(tablaAleatorios, generadorLenguaje, truncador, desviacion, media);
            generadorDistribucion.generarSerie(cantidadValores);

            this.menor = ((GeneradorNormalBoxMuller)generadorDistribucion).getMenor();
            this.mayor = ((GeneradorNormalBoxMuller)generadorDistribucion).getMayor();

            generarIntervalosNormal();
            obtenerFrecuenciasObservadasNormal();
            pantalla.mostrarResultados(tablaAleatorios);
            graficar();
        }

        private void generarIntervalosNormal()
        {
            GeneradorIntervalosNormal generadorIntervalos = new GeneradorIntervalosNormal(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);

            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
        }

        private void obtenerFrecuenciasObservadasNormal()
        {
            ContadorFrecuenciaObservada contadorFrecuencias = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            contadorFrecuencias.contarFrecuenciaSerie(tablaAleatorios);

            this.frecuenciasObservadas = contadorFrecuencias.obtenerFrecuencias();
        }

        public void probar()
        {
            IProbador probador = new ProbadorNormal(truncador, tablaAleatorios, media, desviacion, inicioIntervalos, finIntervalos, frecuenciasObservadas);
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
            graficador.nombre = "Normal por Box Muller";
            graficador.inicioIntervalos = this.inicioIntervalos;
            graficador.finIntervalos = this.finIntervalos;
            pantalla.mostrarGrafico(graficador);
        }
    }
}
