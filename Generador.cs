using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios
{
    public partial class Generador : Form
    {
        //DataTable dataTable;
        int CANT_ITERACIONES = 20;
        int x0;
        int k;
        int g;
        int c;
        int a;
        long m;
        int indice;
        long entradaAnterior;
        long entradaActual;
        double aleatorioActual;
        float aleatorioActualTruncado;

        public Generador()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            grdResultados.Rows.Clear();
            indice = -1;
            x0 = int.Parse(semilla.Text);
            k = int.Parse(enteroK.Text);
            g = int.Parse(enteroG.Text);
            a = int.Parse(constanteMultiplicativa.Text);
            m = long.Parse(modulo.Text);

            entradaAnterior = x0;

            if (rbLineal.Checked)
            {
                c = int.Parse(constanteAditiva.Text); 
                congruencialLineal(); 
            }
            else { congruencialMultiplicativo(); }
        }


        private void congruencialLineal()
        {
            for (int i = 1; i <= CANT_ITERACIONES; i++)
            {
                agregarCongruencialLineal();
            }
        }


        private void agregarCongruencialLineal()
        {
            generarAleatorioLineal();
            aleatorioActualTruncado = truncarDecimales(aleatorioActual);
            agregarFila(aleatorioActualTruncado);
        }

        private void generarAleatorioLineal()
        {
            entradaActual = ((a * entradaAnterior) + c) % (m);
            aleatorioActual = (double)entradaActual / (m-1); // (m-1) para incluir el 1 
            entradaAnterior = entradaActual;
        }

        private void agregarFila(float numeroAleatorio)
        {
            grdResultados.Rows.Add();
            ++indice;
            grdResultados.Rows[indice].Cells[0].Value = indice + 1;
            grdResultados.Rows[indice].Cells[1].Value = numeroAleatorio;
            enfocarFila();
        }

        private void enfocarFila()
        {
            grdResultados.CurrentCell = grdResultados.Rows[indice].Cells[0];
        }

        private float truncarDecimales(double numero)
        {
            int factor = 10000;
            return (float) Math.Truncate(factor * numero) / factor;
        }

        private void congruencialMultiplicativo()
        {
            for (int i = 1; i <= CANT_ITERACIONES; i++)
            {
                agregarCongruencialMultiplicativo();
            }
        }

        private void agregarCongruencialMultiplicativo()
        {
            generarAleatorioMultiplicativo();
            aleatorioActualTruncado = truncarDecimales(aleatorioActual);
            agregarFila(aleatorioActualTruncado);
        }

        private void generarAleatorioMultiplicativo()
        {
            entradaActual = (a * entradaAnterior) % (m);
            aleatorioActual = (double)entradaActual / (m-1); // (m-1) para incluir el 1 
            entradaAnterior = entradaActual;
        }


        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (rbLineal.Checked)
            {
                agregarCongruencialLineal();
            }
            else
            {
                agregarCongruencialMultiplicativo();
            }
        }


        private void enteroK_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                actualizarA();
                actualizarK();
            }
        }

        private void constanteMultiplicativa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                actualizarK();
                actualizarA();
            }
        }

        private void modulo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                actualizarG();
                actualizarM();
            }
        }

        private void enteroG_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {
                actualizarM();
                actualizarG();
            }
        }

        private void actualizarG()
        {
            m = long.Parse(modulo.Text);
            g = (int)Math.Log2(m);
            enteroG.Text = g + "";
        }

        private void actualizarM()
        {
            g = int.Parse(enteroG.Text);
            m = (long)Math.Pow(2, g);

            modulo.Text = m + "";
        }

        private void actualizarA()
        {
            k = int.Parse(enteroK.Text);
            if (rbLineal.Checked)
            {
                a = 1 + 4 * k;
                constanteMultiplicativa.Text = a + "";
            }
            else
            {
                a = 3 + 8 * k;
                constanteMultiplicativa.Text = a + "";
            }
        }

        private void actualizarK()
        {
            a = int.Parse(constanteMultiplicativa.Text);
            if (rbLineal.Checked)
            {
                k = (a - 1) / 4;
                enteroK.Text = k + "";
            }
            else
            {
                k = (a - 3) / 8;
                enteroK.Text = k + "";
            }
        }

        private void Ejercicio1_Load(object sender, EventArgs e)
        {

        }
    }
}