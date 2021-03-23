using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Drawing;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace Numeros_aleatorios.grafico_excel
{
    public partial class GraficadorExcel : Form
    {
        public int[] frecuenciaObservada { get; set; }
        public int[] frecuenciaEsperada { get; set; }


        public GraficadorExcel()
        {
            InitializeComponent();
        }

        private void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Excel.Application xlApp;
            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 2] = "Observado";
            xlWorkSheet.Cells[1, 3] = "Esperado";

            grdFrecuencias.Columns.Add("frecuencia", "Frecuencia / Intervalo");
            grdFrecuencias.Rows.Add();
            grdFrecuencias.Rows[0].Cells[0].Value = "Observada";
            grdFrecuencias.Rows.Add();
            grdFrecuencias.Rows[1].Cells[0].Value = "Esperada";

            int indice = 1;

            for (int i=0 ; i < frecuenciaEsperada.Length; i++)
            {
                xlWorkSheet.Cells[i + 2, 1] = (i + 1).ToString();
                xlWorkSheet.Cells[i+2, 2] = frecuenciaObservada[i].ToString();
                xlWorkSheet.Cells[i+2, 3] = frecuenciaEsperada[i].ToString();

                grdFrecuencias.Columns.Add("it"+indice, indice.ToString());
                grdFrecuencias.Rows[0].Cells[indice].Value = frecuenciaObservada[i];
                grdFrecuencias.Rows[1].Cells[indice].Value = frecuenciaEsperada[i];
                indice++;
            }

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(240, 120, 340, 290);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d"+(frecuenciaEsperada.Length+1));
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            //export chart as picture file;
            chartPage.Export(@"C:\\Users\"+Environment.UserName.ToString()+"\\histograma.png", "PNG", misValue);
            pictureBox1.Image = new Bitmap(@"C:\\Users\" + Environment.UserName.ToString() + "\\histograma.png");

            // PARA GUARDAR EL EXCEL
            //xlWorkBook.SaveAs("histograma", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(false, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

    }
}
