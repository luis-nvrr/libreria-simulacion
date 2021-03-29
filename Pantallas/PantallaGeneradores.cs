using Numeros_aleatorios.LibreriaSimulacion;
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
    public partial class PantallaGeneradores : Form
    {
        int CANT_ITERACIONES = 20;

        // parametros
        int x0;
        int k;
        int g;
        int c;
        int a;
        long m;

        // indice para agregar fila
        int indice;

        // generadores
        GeneradorCongruencialLinealMixto lineal;
        GeneradorCongruencialMultiplicativo multiplicativo;

        Truncador truncador;
        DataTable dataTable;


        public PantallaGeneradores()
        {
            InitializeComponent();
        }

        private void Ejercicio1_Load(object sender, EventArgs e)
        {
            truncador = new Truncador(4);
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            grdResultados.DataSource = null;
            indice = -1;

            x0 = int.Parse(semilla.Text);
            k = int.Parse(enteroK.Text);
            g = int.Parse(enteroG.Text);
            a = int.Parse(constanteMultiplicativa.Text);
            m = long.Parse(modulo.Text);

            if (rbLineal.Checked)
            {
                c = int.Parse(constanteAditiva.Text); 
                congruencialLineal(); 
            }
            else { congruencialMultiplicativo(); }
        }


        private void congruencialLineal()
        {
            lineal = new GeneradorCongruencialLinealMixto(truncador, x0, c, a, m);
            dataTable = lineal.generarSerie(CANT_ITERACIONES);

            grdResultados.DataSource = dataTable;
        }

        private void congruencialMultiplicativo()
        {
            multiplicativo = new GeneradorCongruencialMultiplicativo(truncador, x0, a, m);
            dataTable = multiplicativo.generarSerie(CANT_ITERACIONES);

            grdResultados.DataSource = dataTable;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (rbLineal.Checked)
            {
                agregarFila(lineal.siguienteAleatorio());
            }
            else
            {
                agregarFila(multiplicativo.siguienteAleatorio());
            }
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
            enteroG.Text = g.ToString();
        }

        private void actualizarM()
        {
            g = int.Parse(enteroG.Text);
            m = (long)Math.Pow(2, g);

            modulo.Text = m.ToString() ;
        }

        private void actualizarA()
        {
            k = int.Parse(enteroK.Text);
            if (rbLineal.Checked)
            {
                a = 1 + 4 * k;
                constanteMultiplicativa.Text = a.ToString();
            }
            else
            {
                a = 3 + 8 * k;
                constanteMultiplicativa.Text = a.ToString();
            }
        }

        private void actualizarK()
        {
            a = int.Parse(constanteMultiplicativa.Text);
            if (rbLineal.Checked)
            {
                k = (a - 1) / 4;
                enteroK.Text = k.ToString();
            }
            else
            {
                k = (a - 3) / 8;
                enteroK.Text = k.ToString();
            }
        }


    }
}