using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Colas
{
    public partial class PantallaResultados : Form
    {
        private int paginaActual;
        private ColasMunicipalidad colas;
        private int filaSeleccionada;
        public PantallaResultados()
        {
            InitializeComponent();
            paginaActual = 1;
        }

        private void PantallaResultados_Load(object sender, EventArgs e)
        {
            grdRangoResultados.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            colas = new ColasMunicipalidad(this);
            colas.simular(0,500); // 0 es la fila 1, la 0 es inicializacion
            colas.mostrarPagina(paginaActual);
        }

        public void mostrarResultados(DataTable resultados)
        {
            DataView dataView = new DataView(resultados);
            this.grdRangoResultados.DataSource = dataView;
        }

        private void grdRangoResultados_ColumnAdded(object sender, DataGridViewColumnEventArgs e)
        {
            e.Column.FillWeight = 1;
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            filaSeleccionada = grdRangoResultados.CurrentCell.RowIndex; 
            paginaActual++;
            colas.mostrarPagina(paginaActual);
            //grdRangoResultados.Rows[filaSeleccionada].Selected = true;
            grdRangoResultados.CurrentCell = grdRangoResultados.Rows[filaSeleccionada].Cells[0];
        }

        private void btnAnterior_Click(object sender, EventArgs e)
        {
            filaSeleccionada = grdRangoResultados.CurrentCell.RowIndex;
            paginaActual--;
            colas.mostrarPagina(paginaActual);
            //grdRangoResultados.Rows[filaSeleccionada].Selected = true;
            grdRangoResultados.CurrentCell = grdRangoResultados.Rows[filaSeleccionada].Cells[0];
        }

        private void grdRangoResultados_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            grdRangoResultados.ClearSelection();
        }
    }
}
