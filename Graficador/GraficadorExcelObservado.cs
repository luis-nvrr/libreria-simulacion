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
using Numeros_aleatorios.LibreriaSimulacion;

namespace Numeros_aleatorios.grafico_excel
{
    public partial class GraficadorExcelObservado : Form
    {

        Excel.Application xlApp;
        Excel.Workbook xlWorkBook;
        Excel.Worksheet xlWorkSheet;
        object misValue = System.Reflection.Missing.Value;
        public int[] frecuenciaObservada { get; set; }
        public double[] inicioIntervalos { get; set; }
        public double[] finIntervalos { get; set; }

        public int[] valoresDiscretos { get; set; }

        public string nombre { get; set; }

        DataTable dataTable;
        DataRow dataRow;

        public GraficadorExcelObservado()
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

            xlApp = new Excel.Application();
            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 2] = nombre;

            dataTable = new DataTable();
            dataTable.Columns.Add("int.");
            dataTable.Columns.Add("FO");
            
            int indice = 1;

            for (int i=0 ; i < frecuenciaObservada.Length; i++)
            {
                xlWorkSheet.Cells[i+2, 2] = frecuenciaObservada[i].ToString();

                dataRow = dataTable.NewRow();

                if (inicioIntervalos != null) { 
                    dataRow[0] = "[" + inicioIntervalos[i] + ";" + finIntervalos[i] + "]";
                    xlWorkSheet.Cells[i + 2, 1] = ("[" + inicioIntervalos[i] + ";" + finIntervalos[i] + "]").ToString();
                } 
                if(valoresDiscretos != null) { 
                    dataRow[0] = valoresDiscretos[i] + ";";
                    xlWorkSheet.Cells[i + 2, 1] = valoresDiscretos[i].ToString();
                }

                dataRow[1] = frecuenciaObservada[i];
                dataTable.Rows.Add(dataRow);
            }

            grdFrecuencias.DataSource = dataTable;

            Excel.Range chartRange;

            Excel.ChartObjects xlCharts = (Excel.ChartObjects)xlWorkSheet.ChartObjects(Type.Missing);
            Excel.ChartObject myChart = (Excel.ChartObject)xlCharts.Add(240, 120, 340, 290);
            Excel.Chart chartPage = myChart.Chart;
       

            chartRange = xlWorkSheet.get_Range("A1", "b"+(frecuenciaObservada.Length+1));
            chartPage.SetSourceData(chartRange, misValue);
            chartPage.ChartType = Excel.XlChartType.xlColumnClustered;
            chartPage.Legend.LegendEntries(chartPage.Legend.LegendEntries().Count).Delete();


            Excel.ChartGroup group = chartPage.ChartGroups(1);
            group.GapWidth = 0;
            group.Overlap = 0;

            Excel.Series series = (Excel.Series)chartPage.SeriesCollection(1);
            series.Border.Color = (int)Excel.XlRgbColor.rgbBlack;

            //export chart as picture file;
            Random random = new Random();
            string time = random.Next().ToString();
            chartPage.Export(@"C:\\Users\"+Environment.UserName.ToString()+"\\histograma"+time+".png", "PNG", misValue);
            pictureBox1.Image = new Bitmap(@"C:\\Users\" + Environment.UserName.ToString() + "\\histograma"+time+".png");


            // PARA GUARDAR EL EXCEL
            //xlWorkBook.SaveAs("histograma", Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
            xlWorkBook.Close(false, misValue, misValue);
            xlApp.Quit();

            releaseObject(xlWorkSheet);
            releaseObject(xlWorkBook);
            releaseObject(xlApp);
        }

        private void GraficadorExcelObservado_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private String copiarTabla()
        {
            return CopiadorTabla.tablaToString(dataTable);
        }

        private void btnCopiar_Click(object sender, EventArgs e)
        {
            Clipboard.SetText(copiarTabla());
            MessageBox.Show("Texto copiado!", "Clipboard", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
