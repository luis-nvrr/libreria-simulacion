using Numeros_aleatorios.ejemplo_grafico;
using Numeros_aleatorios.grafico_excel;
using Numeros_aleatorios.Pruebas_de_bondad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Numeros_aleatorios.Pruebas_de_bondad;
using Numeros_aleatorios.LibreriaSimulacion;

namespace Numeros_aleatorios
{
    static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new PantallaGeneradores());
        }
    }
}
