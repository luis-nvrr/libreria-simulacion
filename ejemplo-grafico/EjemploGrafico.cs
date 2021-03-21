using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using System.Drawing.Drawing2D;

namespace Numeros_aleatorios
{
    public partial class EjemploGrafico : Form
    {
        public EjemploGrafico()
        {
            InitializeComponent();
        }

        private const int MIN_VALUE = 0;
        private int MAX_VALUE; //cantidad de numeros

        // private float[] frecuenciaObservada = new float[]{0.15f, 0.22f, 0.41f, 0.65f, 0.84f, 0.81f, 0.62f, 0.45f, 0.32f, 0.07f, 0.11f, 0.29f, 0.58f, 0.73f, 0.93f,0.97f, 0.79f, 0.55f, 0.35f, 0.09f,
        //   0.99f, 0.51f, 0.35f, 0.02f, 0.19f, 0.24f, 0.98f, 0.10f, 0.31f, 0.17f};

        //private float[] frecuenciaObservada = new float[] { 8f, 7f, 5f, 4f, 6f }; // arreglo con las frecuencias
        //private Label[] Labels = new Label[5]; // 5 es la cantidad de intervalos
        //private float[] rangeValuesStart = new float[] { 0f, 0.2f, 0.4f, 0.6f, 0.8f }; // inicio de cada intervalo
        //private float[] rangeValuesEnd = new float[] { 0.19f, 0.39f, 0.59f, 0.79f, 0.99f }; // inicio de cada intervalo
        //private Label[] rangeLabels = new Label[10]; // 10 es 2* la cantidad de intervalos

        public int[] frecuenciaObservada { get; set; }
        public int[] frecuenciaEsperada { get; set; }
        private Label[] Labels;
        //public float[] rangeValuesStart { get; set; } // no hace falta poner rangos
        //public float[] rangeValuesEnd { get; set; }
        private Label[] rangeLabels;
        public int cantidadIntervalos { get; set; }
        public int cantidadNumeros { get; set; }

        // Make some random data.
        private void Form1_Load(object sender, EventArgs e)
        {
            Labels = new Label[cantidadIntervalos];
            rangeLabels = new Label[cantidadIntervalos];
            MAX_VALUE = cantidadNumeros/(cantidadIntervalos/3);
            //Random rnd = new Random();

            // Create data.
            for (int i = 0; i < frecuenciaObservada.Length; i++)
            {

               // Random rnd = new Random(); // esto es para generar valores random

                // Create data.
               // for (int i = 0; i < frecuenciaObservada.Length; i++)
               //    frecuenciaObservada[i] = rnd.Next(MIN_VALUE + 5, MAX_VALUE - 5);

                // Make a range label.
                rangeLabels[i] = new Label();
                rangeLabels[i].Parent = picHisto;
                rangeLabels[i].Text = (i+1).ToString();
                rangeLabels[i].ForeColor = Color.Black;
                rangeLabels[i].BackColor = Color.White;
                rangeLabels[i].AutoSize = true;

                // Make a Label
                Labels[i] = new Label();
                Labels[i].Parent = picHisto;
                Labels[i].Text = frecuenciaObservada[i].ToString();
                Labels[i].ForeColor = Color.Black;
                Labels[i].BackColor = Color.Transparent;
                Labels[i].AutoSize = true;
            }
        }

        // Draw the histogram.
        private void picHisto_Paint(object sender, PaintEventArgs e)
        {
            DrawHistogram(e.Graphics, picHisto.BackColor, frecuenciaObservada,
                picHisto.ClientSize.Width, picHisto.ClientSize.Height);
        }

        // Redraw.
        private void picHisto_Resize(object sender, EventArgs e)
        {
            picHisto.Refresh();
        }

        // Draw a histogram.
        private void DrawHistogram(Graphics gr, Color back_color,
            int[] values, int width, int height)
        {
            Color[] Colors = new Color[] {
        Color.Black, Color.DarkRed, Color.DarkGreen};

            gr.Clear(back_color);

            // Make a transformation to the PictureBox.
            RectangleF data_bounds =
                new RectangleF(0, -3f*MAX_VALUE/100, values.Length, MAX_VALUE);
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
                     // primer rectangulo del grupo
                    RectangleF rect = new RectangleF(i, 0, 1/3f, values[i]);
                    using (Brush the_brush =
                         new SolidBrush(Colors[0]))
                    {
                        gr.FillRectangle(the_brush, rect);
                        gr.DrawRectangle(thin_pen, rect.X, rect.Y,
                            rect.Width, rect.Height);
                    }

                    // segundo rectangulo del grupo
                    RectangleF rect2 = new RectangleF(i+(1/3f), 0, 1 / 3f, frecuenciaEsperada[i]);
                    using (Brush the_brush =
                         new SolidBrush(Colors[1]))
                    {
                        gr.FillRectangle(the_brush, rect2);
                        gr.DrawRectangle(thin_pen, rect2.X, rect2.Y,
                            rect2.Width, rect2.Height);
                    }


                    // Position the value's label.
                    PointF[] point =
                    {
                new PointF(rect.Left + rect.Width / 2f, rect.Bottom),
            };
                    transformation.TransformPoints(point);
                    Labels[i].Location = new Point(
                        (int)point[0].X - Labels[i].Width / 2,
                        (int)point[0].Y - Labels[i].Height);

                    // Position the range's values
                    PointF[] pointRange =
                     {
                new PointF(rect.Left + rect.Width / 2f, rect.Y-3f*MAX_VALUE/100),
            };
                    transformation.TransformPoints(pointRange);
                    rangeLabels[i].Location = new Point(
                        (int)pointRange[0].X - Labels[i].Width / 2,
                        (int)pointRange[0].Y - Labels[i].Height);

                }
            }

            gr.ResetTransform();
            gr.DrawRectangle(Pens.Black, 0, 0, width - 1, height - 1);
        }


        // Display the value clicked.
        private void picHisto_MouseDown(object sender, MouseEventArgs e)
        {
            // Determine which data value was clicked.
            float bar_wid = picHisto.ClientSize.Width / (int)frecuenciaObservada.Length;
            int i = (int)(e.X / bar_wid);
            MessageBox.Show("Item " + i + " has value " + frecuenciaObservada[i],
                "Value", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
