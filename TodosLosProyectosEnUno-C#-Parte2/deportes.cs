using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* DESARROLLADO POR MATIAS ABREGU
 *  Partido - Formulario de alta de partidos de un deporte donde pida nombre del equipo A, 
 *  nombre del Equipo B, cantidad de puntos de A y cantidad de puntos de B, y 2  RadioButton 
 *  con el criterio de ganador (si es el que tiene más puntos o el que tiene menos). 
 *  Al presionar el boton debe anexarse a una List a los demás datos cargados. Debe mostrarse
 *  por nombre de equipos, puntos y quien fue el ganador.
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class deportes : Form
    {
        List<partido> listaPartidos = new List<partido>();
        public deportes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" ||
                textBox4.Text == "" || (!radioButton1.Checked && !radioButton2.Checked))
            {
                MessageBox.Show("Rellena todos los campos antes de continuar");
            }
            else
            {
                if (radioButton1.Checked) listaPartidos.Add(new partido(textBox1.Text, textBox2.Text,
                    int.Parse(textBox3.Text), int.Parse(textBox4.Text), true));
                else listaPartidos.Add(new partido(textBox1.Text, textBox2.Text,
                    int.Parse(textBox3.Text), int.Parse(textBox4.Text), false));
                cargarPartidos();
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar))
            {
                return;
            }

            if(!Char.IsNumber(e.KeyChar)) {
                MessageBox.Show("Solo se puede números enteros");
                e.Handled = true;
                return;
            }
        }

        private void cargarPartidos()
        {
            textBox5.Text = "";
            foreach (var partido in listaPartidos)
            {
                textBox5.AppendText($"Nombre Equipo A: {partido.getNombreA()} \r\n" +
                     $"Puntaje obtenido: {partido.getPuntajeA()} \r\n" +
                     $"Nombre Equipo B: {partido.getNombreB()} \r\n" +
                     $"Puntaje obtenido: {partido.getPuntajeB()} \r\n");
                if (partido.getVictoria())
                {
                    textBox5.AppendText($"Criterio de victoria: Mayor Puntaje \r\n");
                    if (partido.getPuntajeA() > partido.getPuntajeB())
                    {
                        textBox5.AppendText($"Equipo Ganador: {partido.getNombreA()} \r\n\r\n");
                    }
                    else if(partido.getPuntajeA() < partido.getPuntajeB())
                    {
                        textBox5.AppendText($"Equipo Ganador: {partido.getNombreB()} \r\n\r\n");
                    } else
                    {
                        textBox5.AppendText($"¡¡EMPATE!!\r\n\r\n");
                    }
                } else
                {
                    textBox5.AppendText($"Criterio de victoria: Menor Puntaje\r\n");
                    if (partido.getPuntajeA() > partido.getPuntajeB())
                    {
                        textBox5.AppendText($"Equipo Ganador: {partido.getNombreB()} \r\n\r\n");
                    }
                    else if(partido.getPuntajeA() < partido.getPuntajeB())
                    {
                        textBox5.AppendText($"Equipo Ganador: {partido.getNombreA()} \r\n\r\n");
                    } else
                    {
                        textBox5.AppendText($"¡¡EMPATE!!\r\n\r\n");
                    }
                }
            }
        }

        private class partido
        {
            private string nombreA, nombreB;
            private int puntajeA, puntajeB;
            private bool victoriaMayorPuntaje;

            public partido(string nombreA, string nombreB, int puntajeA, int puntajeB, bool victoriaMayorPuntaje)
            {
                this.nombreA = nombreA;
                this.nombreB = nombreB;
                this.puntajeA = puntajeA;
                this.puntajeB = puntajeB;
                this.victoriaMayorPuntaje = victoriaMayorPuntaje;
            }

            public string getNombreA()
            {
                return nombreA;
            }
            public string getNombreB()
            {
                return nombreB;
            }
            public int getPuntajeA()
            {
                return puntajeA;
            }
            public int getPuntajeB()
            {
                return puntajeB;
            }
            public bool getVictoria()
            {
                return victoriaMayorPuntaje;
            }
        }
    }
}