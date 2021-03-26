using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.ejemplo_grafico
{
    public partial class Prueba_Grafico_Generador : Form
    {
        GraficadorExcelObservado excel;
        GeneradorCongruencialLinealMixto lineal;
        Truncador truncador;
        GeneradorIntervalosUniforme intervalos;
        FrecuenciaObservada frecuenciaObservada;
        FrecuenciaEsperadaUniforme frecuenciaEsperada;

        public Prueba_Grafico_Generador()
        {
            InitializeComponent();
        }

        private void Prueba_Grafico_Generador_Load(object sender, EventArgs e)
        {
            excel = new GraficadorExcelObservado();
            truncador = new Truncador(4);

            intervalos = new GeneradorIntervalosUniforme(truncador);
            intervalos.generarIntervalos(20);
            float[] inicio = intervalos.obtenerInicioIntervalos();
            float[] fin = intervalos.obtenerFinIntervalos();

            frecuenciaObservada = new FrecuenciaObservada(inicio, fin);
            frecuenciaEsperada = new FrecuenciaEsperadaUniforme(100, inicio, fin);
           
            lineal = new GeneradorCongruencialLinealMixto(truncador, 17,21,13,32); // parametros de la congruencial
            float[] aleatorios = lineal.generarSerie(100, frecuenciaObservada);
            int[] frecuenciasObservadas = frecuenciaObservada.obtenerFrecuencias();
            int[] frecuenciasEsperadas = frecuenciaEsperada.obtenerFrecuencias();

            //excel.frecuenciaEsperada = frecuenciasEsperadas;
            excel.frecuenciaObservada = frecuenciasObservadas;
            excel.ShowDialog();
        }
    }
}

