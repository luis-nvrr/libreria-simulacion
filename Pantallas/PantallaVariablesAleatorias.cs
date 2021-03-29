using Numeros_aleatorios.grafico_excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.LibreriaSimulacion
{
    public partial class PantallaVariablesAleatorias : Form
    {
        GeneradorUniformeAB uniforme;
        Truncador truncador;
        GeneradorIntervalosUniformeAB generadorIntervalos;
        GraficadorExcelObservado graficador;
        ContadorFrecuenciaObservada contador;

        float[] inicioIntervalos;
        float[] finIntervalos;

        int cantidadValores;
        int cantidadIntervalos;
        int[] frecuenciasObservadas;

        DataTable dataTable;

        public PantallaVariablesAleatorias()
        {
            InitializeComponent();
        }

        private void PantallaPruebaGenerador_Load(object sender, EventArgs e)
        {
            truncador = new Truncador(4);
            grdResultados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            dataTable = new DataTable();
            dataTable.Columns.Add("iteracion");
            dataTable.Columns.Add("aleatorio");
        }

        private void inicializarVariables()
        {
            cantidadValores = int.Parse(txtCantidadValores.Text);
            cantidadIntervalos = int.Parse(txtCantidadIntervalos.Text);
            frecuenciasObservadas = new int[cantidadIntervalos];
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            gbGrafico.Controls.Clear();
            grdResultados.DataSource = null;
            dataTable.Rows.Clear();

            inicializarVariables();

            if (rbUniforme.Checked)
            {
                generarUniforme();
                return;
            }
            if (rbNormal.Checked)
            {
                return;
            }
            if (rbExponencial.Checked)
            {
                return;
            }
            if (rbPoisson.Checked)
            {
                return;
            }
        }


        private void generarUniforme()
        {
            float a = float.Parse(txtA.Text);
            float b = float.Parse(txtB.Text);

            if (b < a) { return; }

            generarIntervalosUniforme(a,b);
            contador = new ContadorFrecuenciaObservada(inicioIntervalos, finIntervalos);
            uniforme = new GeneradorUniformeAB(truncador, a, b);
            dataTable = uniforme.generarSerie(cantidadValores, contador); 
            grdResultados.DataSource = dataTable;
            frecuenciasObservadas = contador.obtenerFrecuencias();
        }

        private void generarIntervalosUniforme(float a, float b)
        {
            generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
            generadorIntervalos.generarIntervalos(cantidadIntervalos, a, b);
            inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            finIntervalos = generadorIntervalos.obtenerFinIntervalos();

            MessageBox.Show(generadorIntervalos.mostrarIntervalos());
        }


        private void btnMostrar_Click(object sender, EventArgs e)
        {
            graficador = new GraficadorExcelObservado();
            graficador.frecuenciaObservada = frecuenciasObservadas;
            graficador.nombre = gbDistribuciones.Controls.OfType<RadioButton>().FirstOrDefault(n => n.Checked).Text;

            gbGrafico.Controls.Clear();
            graficador.TopLevel = false;
            graficador.AutoScroll = true;
            graficador.FormBorderStyle = FormBorderStyle.None;
            graficador.Dock = DockStyle.Fill;
            gbGrafico.Controls.Add(graficador);
            graficador.Show();
        }
    }
}
