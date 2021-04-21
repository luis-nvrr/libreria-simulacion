using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos;
using Numeros_aleatorios.LibreriaSimulacion.Probadores;
using Numeros_aleatorios.Pantallas;
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
        GestorUniforme gestorUniforme;
        GestorExponencial gestorExponencial;
        GestorNormalBoxMuller gestorNormalBoxMuller;
        GestorNormalConvolucion gestorNormalConvolucion;
        GestorPoisson gestorPoisson;

        int cantidadValores;
        int cantidadIntervalos;

        public PantallaVariablesAleatorias()
        {
            InitializeComponent();
        }

        private void PantallaPruebaGenerador_Load(object sender, EventArgs e)
        {
            this.cantidadValores = 1000;
            this.cantidadIntervalos = 20;
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            limpiarControles();
            tomasCantidadValores();
            tomarCantidadIntervalos();
            generarVariablesAleatorias();
        }

        private void limpiarControles()
        {
            gbGrafico.Controls.Clear();
            grdResultados.DataSource = null;
            gbGrafico.Controls.Clear();
        }

        private void tomasCantidadValores()
        {
            if (txtCantidadValores.Text.Equals("")) { return; }
            cantidadValores = int.Parse(txtCantidadValores.Text);
        }

        private void tomarCantidadIntervalos()
        {
            if(!rb5.Checked || !rb10.Checked || !rb15.Checked || !rb20.Checked) { return;  }
            if (rb5.Checked) { cantidadIntervalos = int.Parse(rb5.Text); }
            if (rb10.Checked) { cantidadIntervalos = int.Parse(rb10.Text); }
            if (rb15.Checked) { cantidadIntervalos = int.Parse(rb15.Text); }
            if (rb20.Checked) { cantidadIntervalos = int.Parse(rb20.Text); }
        }

        private void generarVariablesAleatorias()
        {
            if (rbUniforme.Checked)
            {
                generarUniforme();
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                generarNormalBoxMuller();
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                generarNormalConvolucion();
                return;
            }
            if (rbExponencial.Checked)
            {
                generarExponencial();
                return;
            }
            if (rbPoisson.Checked)
            {
                generarPoisson();
                return;
            }
        }

        private void generarUniforme()
        {
            if (txtA.Text.Equals("") || txtB.Text.Equals("")) { return; }
            gestorUniforme = new GestorUniforme(this);
            float a = float.Parse(txtA.Text);
            float b = float.Parse(txtB.Text);
            gestorUniforme.generarUniforme(a,b, cantidadValores, cantidadIntervalos);
        }

        private void generarExponencial()
        {
            if (txtLambdaExponencial.Text.Equals("") && txtMediaExponencial.Text.Equals("")) { return; }
            gestorExponencial = new GestorExponencial(this);
            double[] exponencial = calcularLambdaExponencial();
            double lambda = exponencial[0];
            double media = exponencial[1];
            gestorExponencial.generarExponencial(lambda, media, cantidadValores, cantidadIntervalos);
        }

        private void generarNormalBoxMuller()
        {
            if (txtMediaNormalBoxMuller.Text.Equals("") || txtDesviacionNormalBoxMuller.Text.Equals("")) { return; }
            gestorNormalBoxMuller = new GestorNormalBoxMuller(this);
            double desviacion = double.Parse(txtDesviacionNormalBoxMuller.Text);
            double media = double.Parse(txtMediaNormalBoxMuller.Text);
            gestorNormalBoxMuller.generarNormalBoxMuller(media, desviacion, cantidadValores, cantidadIntervalos);
        }

        private void generarNormalConvolucion()
        {
            if (txtMediaNormalConvolucion.Text.Equals("") || txtDesviacionNormalConvolucion.Text.Equals("")) { return;  }
            gestorNormalConvolucion = new GestorNormalConvolucion(this);
            double desviacion = double.Parse(txtDesviacionNormalConvolucion.Text);
            double media = double.Parse(txtMediaNormalConvolucion.Text);
            gestorNormalConvolucion.generarNormalConvolucion(media, desviacion, cantidadValores, cantidadIntervalos);
        }

        private void generarPoisson()
        {
            if (txtLambdaPoisson.Text.Equals("") && txtMediaPoisson.Text.Equals("")) { return; }
            gestorPoisson = new GestorPoisson(this);
            double[] parametros = calcularLambdaPoisson();
            double lambda = parametros[0];
            double media = parametros[1];
            gestorPoisson.generarPoisson(lambda, media, cantidadValores);
        }

        private double[] calcularLambdaExponencial()
        {
            double lambda;
            double media;

         
            if (txtLambdaExponencial.Text.Equals(""))
            {
                media = double.Parse(txtMediaExponencial.Text);
                lambda = 1 / media;
                txtLambdaExponencial.Text = lambda.ToString();
            }

            lambda = double.Parse(txtLambdaExponencial.Text);
            media = 1 / lambda;
            txtMediaExponencial.Text = media.ToString();

            return new double[] { lambda, media };
        }

        public void mostrarResultados(DataTable resultados)
        {
            this.grdResultados.DataSource = resultados;
        }

        private double[] calcularLambdaPoisson()
        {
            double lambda;
            double media;

            if (txtLambdaPoisson.Text.Equals(""))
            {
                media = double.Parse(txtMediaPoisson.Text);
                lambda = media;
                txtLambdaPoisson.Text = lambda.ToString();
            }

            lambda = double.Parse(txtLambdaPoisson.Text);
            media = lambda;
            txtMediaPoisson.Text = media.ToString();

            return new double[] { lambda, media };
        }

        public void mostrarGrafico(GraficadorExcelObservado graficador)
        {
            gbGrafico.Controls.Clear();
            graficador.TopLevel = false;
            graficador.AutoScroll = true;
            graficador.FormBorderStyle = FormBorderStyle.None;
            graficador.Dock = DockStyle.Fill;
            gbGrafico.Controls.Add(graficador);
            graficador.Show();
        }

        private void manejarSeleccionDistribucion()
        {
            if (rbUniforme.Checked)
            {
                activarRadioButtons();
                gbUniforme.Visible = true;
                gbExponencial.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbPoisson.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                activarRadioButtons();
                gbNormalBoxMuller.Visible = true;
                gbUniforme.Visible = false;
                gbExponencial.Visible = false;
                gbPoisson.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                activarRadioButtons();
                gbNormalConvolucion.Visible = true;
                gbNormalBoxMuller.Visible = false;
                gbUniforme.Visible = false;
                gbPoisson.Visible = false;
                gbExponencial.Visible = false;
                return;
            }
            if (rbExponencial.Checked)
            {
                activarRadioButtons();
                gbExponencial.Visible = true;
                gbUniforme.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbNormalConvolucion.Visible = false;
                gbPoisson.Visible = false;
                return;
            }
            if (rbPoisson.Checked)
            {
               desactivarRadioButtons();
                gbPoisson.Visible = true;
                gbExponencial.Visible = false;
                gbUniforme.Visible = false;
                gbNormalBoxMuller.Visible = false;
                gbNormalConvolucion.Visible = false;
                return;
            }
        }

        private void desactivarRadioButtons()
        {
            rb5.Enabled = false;
            rb10.Enabled = false;
            rb15.Enabled = false;
            rb20.Enabled = false;
        }

        private void activarRadioButtons()
        {
            if(!rb5.Enabled) { rb5.Enabled = true; }
            if (!rb10.Enabled) { rb10.Enabled = true; }
            if (!rb15.Enabled) { rb15.Enabled = true; }
            if (!rb20.Enabled) { rb20.Enabled = true; }
        }

        private void probar()
        {
            if (rbUniforme.Checked)
            {
                gestorUniforme.probar();
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                gestorNormalBoxMuller.probar();
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                gestorNormalConvolucion.probar();
                return;
            }
            if (rbExponencial.Checked)
            {
                gestorExponencial.probar();
                return;
            }
            if (rbPoisson.Checked)
            {
                gestorPoisson.probar();
                return;
            }
        }

        private String copiarTabla()
        {
            if (rbUniforme.Checked)
            {
                return gestorUniforme.copiar();
                
            }
            if (rbNormalBoxMuller.Checked)
            {
                return gestorNormalBoxMuller.copiar();
                
            }
            if (rbNormalConvolucion.Checked)
            {
                return gestorNormalConvolucion.copiar();

            }
            if (rbExponencial.Checked)
            {
                return gestorExponencial.copiar();

            }
            if (rbPoisson.Checked)
            {
                return gestorPoisson.copiar();
            }
            return "";
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (rbUniforme.Checked)
            {
                gestorUniforme.graficar();
                return;
            }
            if (rbNormalBoxMuller.Checked)
            {
                gestorNormalBoxMuller.graficar();
                return;
            }
            if (rbNormalConvolucion.Checked)
            {
                gestorNormalConvolucion.graficar();
                return;
            }
            if (rbExponencial.Checked)
            {
                gestorExponencial.graficar();
                return;
            }
            if (rbPoisson.Checked)
            {
                gestorPoisson.graficar();
                return;
            }
        }

        private void rbUniforme_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void rbExponencial_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void rbNormal_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void rbPoisson_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccionDistribucion();
        }

        private void btnJi_Click(object sender, EventArgs e)
        {
            probar();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(copiarTabla());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
