using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* Desarrollado por Matias Abregú
 * Guía Telefónica: Hacer un formulario que permita cargar, mostrar y borrar en una List nombres
 * de personas junto a sus telefonos.
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class guiaTel : Form
    {

        List<Persona> guiaTelefonica = new List<Persona>();

        public guiaTel()
        {
            InitializeComponent();
        }

        private class Persona
        {
            private long telefono;
            private String nombre, apellido;

            public Persona(long telefono, String nombre, String apellido)
            {
                this.telefono = telefono;
                this.nombre = nombre;
                this.apellido = apellido;
            }

            public long getTelefono()
            {
                return telefono;
            }

            public String getNombre()
            {
                return nombre;
            }

            public String getApellido()
            {
                return apellido;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsPunctuation(e.KeyChar) || Char.IsSymbol(e.KeyChar))
            {
                MessageBox.Show("Solo números.");
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
                MessageBox.Show("Rellena todos los campos antes de avanzar.");
            else
            {
                bool control = false;

                guiaTelefonica.ForEach(t =>
                {
                    if (t.getTelefono() == long.Parse(textBox1.Text))
                    {
                        control = true;
                    }
                });

                if (control)
                {
                    MessageBox.Show("Este telefono ya existe, prueba con otro");
                }
                else
                {
                    guiaTelefonica.Add(new Persona(long.Parse(textBox1.Text), textBox2.Text
                    , textBox3.Text));
                    cargarDatos();
                    MessageBox.Show("¡Registro exitoso!");
                }
            }
        }

        private void cargarDatos()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            guiaTelefonica.ForEach(t =>
            {
                textBox4.AppendText($"Número: {t.getTelefono()}\r\n");
            });
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingresa un telefono antes de buscar un contacto");
            }
            else
            {
                bool control = false;
                guiaTelefonica.ForEach(t =>
                {
                    if (long.Parse(textBox1.Text) == t.getTelefono())
                    {
                        MessageBox.Show($"¡Contacto Encontrado! \nDatos: \n" +
                            $"Telefono: {t.getTelefono()} \n" +
                            $"Nombre: {t.getNombre()} \n" +
                            $"Apellido: {t.getApellido()}");
                        textBox1.Text = t.getTelefono().ToString();
                        textBox2.Text = t.getNombre();
                        textBox3.Text = t.getApellido();
                        control = true;
                    }
                });

                if (!control)
                {
                    MessageBox.Show("¡No se encontro el contacto!");
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Ingresa un telefono antes de eliminar un contacto");
            }
            else
            {
                bool control = false;
                try
                {
                    foreach (Persona t in guiaTelefonica)
                    {
                        if (long.Parse(textBox1.Text) == t.getTelefono())
                        {
                            guiaTelefonica.Remove(t);
                            control = true;
                            break;
                        }
                    }
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }

                if (!control)
                {
                    MessageBox.Show("¡El contacto no existe!");
                    textBox2.Text = "";
                    textBox3.Text = "";
                }
                cargarDatos();
            }
        }
    }
}