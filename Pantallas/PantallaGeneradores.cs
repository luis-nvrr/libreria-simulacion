using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.GeneradoresAleatorios;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace Numeros_aleatorios
{
    public partial class PantallaGeneradores : Form
    {

        // parametros
        int cantidad;
        int x0;
        int k;
        int g;
        int c;
        int a;
        long m;

        // indice para agregar fila
        int indice;

        // generadores
        IGenerador generador;

        Truncador truncador;
        DataTable dataTable;
        DataRow dataRow;

        public PantallaGeneradores()
        {
            InitializeComponent();
        }

        private void Ejercicio1_Load(object sender, EventArgs e)
        {
            grdResultados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            truncador = new Truncador(4);
            dataTable = new DataTable();
            dataTable.Columns.Add("iteracion");
            dataTable.Columns.Add("aleatorio");
            txtCantidad.Text = "20";
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            grdResultados.DataSource = null;
            grdResultados.Refresh();
            dataTable.Rows.Clear();


            x0 = int.Parse(semilla.Text);
            k = int.Parse(enteroK.Text);
            g = int.Parse(enteroG.Text);
            a = int.Parse(constanteMultiplicativa.Text);
            m = long.Parse(modulo.Text);
            cantidad = int.Parse(txtCantidad.Text);
            indice = cantidad - 1;


            if (rbLineal.Checked)
            {
                if(constanteAditiva.Text == "") { return;  }
                c = int.Parse(constanteAditiva.Text); 
                congruencialLineal(); 
            }
            else { congruencialMultiplicativo(); }
        }


        private void congruencialLineal()
        {
            generador = new GeneradorCongruencialLinealMixto(dataTable, truncador, x0, c, a, m);
            generador.generarSerie(cantidad);
            grdResultados.DataSource = dataTable;
        }

        private void congruencialMultiplicativo()
        {
            generador = new GeneradorCongruencialMultiplicativo(dataTable, truncador, x0, a, m);
            generador.generarSerie(cantidad);
            grdResultados.DataSource = dataTable;
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            agregarFila(generador.siguienteAleatorio());
        }

        private void agregarFila(float numeroAleatorio)
        {
            ++indice;
            dataRow = dataTable.NewRow();
            dataRow[0] = indice + 1;
            dataRow[1] = numeroAleatorio;
            dataTable.Rows.Add(dataRow);
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

        private void limpiarCampos()
        {
            enteroG.Text = "";
            enteroK.Text = "";
            constanteAditiva.Text = "";
            constanteMultiplicativa.Text = "";
            modulo.Text = "";
            semilla.Text = ""; 
        }

        private String tablaToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                stringBuilder.Append(row[0].ToString()).Append("\t").Append(row[1].ToString());
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {

            Clipboard.SetText(tablaToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void manejarSeleccion()
        {
            limpiarCampos();
            if (rbLineal.Checked) {
                constanteAditiva.Enabled = true;
                return;
            }
            if (rbMultiplicativo.Checked) {
                constanteAditiva.Enabled = false;
                return;
            }
        }

        private void rbLineal_CheckedChanged(object sender, EventArgs e)
        {
            manejarSeleccion();
        }
    }
}