using Numeros_aleatorios.LibreriaSimulacion;
using Numeros_aleatorios.LibreriaSimulacion.Probadores;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Pantallas
{
    partial class PantallaPruebaChi2 : Form
    {
        private DataTable dataTable;

        public IProbador probador;
        public PantallaPruebaChi2()
        {
            InitializeComponent();
        }

        private void PantallaPruebaChi2_Load(object sender, EventArgs e)
        {
            probador.probar();
            if (probador.esAceptado()) { lblResultado.Text = "No se rechaza la hipotesis nula"; }
            else { lblResultado.Text = "Se rechaza la hipotesis nula"; }

            txtValorCritico.Text = probador.getValorCritico().ToString();
            txtEstadisticoPruebaAcumulado.Text = probador.obtenerTotalAcumuladoEstadisticoPrueba().ToString();
            dataTable = probador.obtenerTablaResultados();
            grdResultados.DataSource = dataTable;
        }

        private String tablaToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (DataRow row in dataTable.Rows)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    stringBuilder.Append(row[i].ToString()).Append("\t");
                }
                stringBuilder.Append("\n");
            }
            return stringBuilder.ToString();
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(tablaToString());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
