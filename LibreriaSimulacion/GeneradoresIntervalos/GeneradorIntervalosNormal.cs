using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.LibreriaSimulacion.GeneradoresIntervalos
{
    class GeneradorIntervalosNormal
    {
        private float[] inicioIntervalos;
        private float[] finIntervalos;

        Truncador truncador; 
        GeneradorIntervalosUniformeAB generadorIntervalos;

        public GeneradorIntervalosNormal(Truncador truncador)
        {
            this.truncador = truncador;
            this.generadorIntervalos = new GeneradorIntervalosUniformeAB(truncador);
        }

        public void generarIntervalos(int cantidadIntervalos, float menor, float mayor)
        {
            generadorIntervalos.generarIntervalos(cantidadIntervalos, menor, mayor);
            this.inicioIntervalos = generadorIntervalos.obtenerInicioIntervalos();
            this.finIntervalos = generadorIntervalos.obtenerFinIntervalos();
            //MessageBox.Show(generadorIntervalos.mostrarIntervalos());
        }

        public float[] obtenerInicioIntervalos()
        {
            return inicioIntervalos;
        }

        public float[] obtenerFinIntervalos()
        {
            return finIntervalos;
        }
    }
}
