﻿using Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace modeloParcial2
{
    /*
     * Formulario:
        a. Crearemos el atributo hilos.
        b. El evento x de hilos deberá estar relacionado con el método MostrarMensajeFin del
        formulario.
        c. MostrarMensajeFin mostrará por pantalla el mensaje recibido.
        d. Al presionar el botón Lanzar se deberá, mediante la sobrecarga del +, agregar un nuevo hilo
        al atributo hilos. En caso de error, se mostrará mediante un MessageBox.
        e. Al presionar el botón Bitacora se deberá mostrar por pantalla la bitacora guardada por hilos
     */
    public partial class Form1 : Form
    {

        private LosHilos hilos;
        
        public Form1()
        {
            InitializeComponent();
            hilos = new LosHilos();


        }

        private void btnLanzar_Click(object sender, EventArgs e)
        {
            //agregar  con la sobrecarga

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        
        public void MostrarMensajeFin(string mensaje)
        {
           //muestra un  msgBox
        }
    }
}
