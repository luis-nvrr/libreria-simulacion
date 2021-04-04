﻿using Numeros_aleatorios.LibreriaSimulacion;
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
            grdResultados.DataSource = probador.obtenerTablaResultados();
        }
    }
}
