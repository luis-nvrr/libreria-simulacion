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
        EjemploGrafico graficador;
        GeneradorCongruencialLineal lineal;
        Truncador truncador;
        FrecuenciaEsperadaObservada frecuenciaEsperadaObservada;

        public Prueba_Grafico_Generador()
        {
            InitializeComponent();
        }

        private void Prueba_Grafico_Generador_Load(object sender, EventArgs e)
        {
            graficador = new EjemploGrafico();
            truncador = new Truncador(4);
            frecuenciaEsperadaObservada = new FrecuenciaEsperadaObservada(30, 5, truncador); //8 es cantidad de numeros, 5 es cantidad de intervalos
           
            lineal = new GeneradorCongruencialLineal(truncador, 17,21,13,32); // parametros de la congruencial
            float[] aleatorios = lineal.generarSerie(30, frecuenciaEsperadaObservada);
            int[][] frecuencias = frecuenciaEsperadaObservada.obtenerFrecuencias();

            graficador.frecuenciaObservada = frecuencias[0];
            graficador.frecuenciaEsperada = frecuencias[1];
            graficador.cantidadIntervalos = 5;
            graficador.cantidadNumeros = 30;
            MessageBox.Show(frecuenciaEsperadaObservada.mostrarFrecuenciasEsperadas());
            graficador.ShowDialog();
        }
    }
}

