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
        public string[] nombresFrecuencias { get; set; }
        public int[] frecuenciaObservada { get; set; }
        public int[] frecuenciaEsperada { get; set; }
        public int cantidadNumeros { get; set; }


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

            //add data 

            xlWorkSheet.Cells[1, 1] = "";
            xlWorkSheet.Cells[1, 2] = "Lineal";
            xlWorkSheet.Cells[1, 3] = "Esperado";

            for (int i=0 ; i < frecuenciaEsperada.Length; i++)
            {
                xlWorkSheet.Cells[i + 2, 1] = (i + 1).ToString();
                xlWorkSheet.Cells[i+2, 2] = frecuenciaObservada[i].ToString();
                xlWorkSheet.Cells[i+2, 3] = frecuenciaEsperada[i].ToString();
            }

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(240, 120, 340, 290);
            Excel.Chart chartPage = myChart.Chart;

            chartRange = xlWorkSheet.get_Range("A1", "d"+(frecuenciaEsperada.Length+1));
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;

            //export chart as picture file;
            // PONER UBICACION DONDE GUARDAR
            chartPage.Export(@"C:\\Users\luis\histograma.bmp", "BMP", misValue);

            //load picture to picturebox;
            // PONER UBICACION DONDE SE GUARDO
            pictureBox1.Image = new Bitmap(@"C:\\Users\luis\histograma.bmp");

            xlWorkBook.SaveAs("histograma", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file c:\\histograma.xls");
        }

    }
}
