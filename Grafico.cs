using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Numeros_aleatorios.Negocio
{
    public partial class Grafico : Form
    {
        public Grafico()
        {
            InitializeComponent();
        }

        private const int MIN_VALUE = 0;
        private const int MAX_VALUE = 100;

        private float[] DataValues = new float[10];

        // Make some random data.
        private void Form1_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();

            // Create data.
            for (int i = 0; i < DataValues.Length; i++)
                DataValues[i] = rnd.Next(MIN_VALUE + 5, MAX_VALUE - 5);
        }

        // Draw the histogram.
        private void picHisto_Paint(object sender, PaintEventArgs e)
        {
            DrawHistogram(e.Graphics, picHisto.BackColor, DataValues,
                picHisto.ClientSize.Width, picHisto.ClientSize.Height);
        }


        // Redraw.
        private void picHisto_Resize(object sender, EventArgs e)
        {
            picHisto.Refresh();
        }

        // Draw a histogram.
        private void DrawHistogram(Graphics gr, Color back_color,
            float[] values, int width, int height)
        {
            Color[] Colors = new Color[] {
        Color.Red, Color.LightGreen, Color.Blue,
        Color.Pink, Color.Green, Color.LightBlue,
        Color.Orange, Color.Yellow, Color.Purple
    };

            gr.Clear(back_color);

            // Make a transformation to the PictureBox.
            RectangleF data_bounds =
                new RectangleF(0, 0, values.Length, MAX_VALUE);
            PointF[] points =
            {
        new PointF(0, height),
        new PointF(width, height),
        new PointF(0, 0)
    };
            Matrix transformation = new Matrix(data_bounds, points);
            gr.Transform = transformation;

            // Draw the histogram.
            using (Pen thin_pen = new Pen(Color.Black, 0))
            {
                for (int i = 0; i < values.Length; i++)
                {
                    RectangleF rect = new RectangleF(i, 0, 1, values[i]);
                    using (Brush the_brush =
                        new SolidBrush(Colors[i % Colors.Length]))
                    {
                        gr.FillRectangle(the_brush, rect);
                        gr.DrawRectangle(thin_pen, rect.X, rect.Y,
                            rect.Width, rect.Height);
                    }
                }
            }

            gr.ResetTransform();
            gr.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
        }


        // Display the value clicked.
        private void picHisto_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine which data value was clicked.
            float bar_wid = picHisto.ClientSize.Width /
                (int)DataValues.Length;
            int i = (int)(e.X / bar_wid);
            MessageBox.Show("Item " + i + " has value " + DataValues[i],
                "Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
