using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/* DESAROLLADO POR MATIAS ABREGU
 * Combinador de nombres - Crear un formulario que almacene en un array 10 nombres. Debe 
 * existir un RadioButton para combinar 2 y 3 nombres. Al presionar un botón debe combinar 
 * de forma aleatoria nombres siempre que sea diferentes.
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class combinarNombres : Form
    {
        private string[] nombres = new string[10];
        private int pos = 0;
        private Random random = new Random();

        public combinarNombres()
        {
            InitializeComponent();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsControl(e.KeyChar)) return;

            if (!Char.IsLetter(e.KeyChar))
            {
                MessageBox.Show("Solo letras.");
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Completa el campo antes de continuar");
            }
            else
            {
                if (pos > 9)
                {
                    MessageBox.Show("Limite alcanzado, reinicia la interfaz en caso de querer" +
                        " crear nuevos nombres.");
                }
                else
                {
                    bool control = false;
                    for (int i = 0; i < nombres.Length; i++)
                    {
                        if (nombres[i] == textBox1.Text)
                        {
                            control = true;
                            MessageBox.Show("Nombre repetido. No se pueden repetir.");
                            break;
                        }
                    }

                    if (!control)
                    {
                        nombres[pos] = textBox1.Text;
                        pos++;
                        cargarInfo();
                    }
                }
            }
        }

        private void cargarInfo()
        {
            textBox5.Text = "Nombres: ";
            for (int i = 0; i < nombres.Length; i++)
            {
                if (nombres[i] != null)
                {
                    textBox5.AppendText($"{nombres[i]}, ");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Selecciona una opción antes de continuar");
            }
            else
            {
                if (nombres[2] == null)
                {
                    MessageBox.Show("Ingresa más nombres antes de continuar. Min: 3");
                }
                else
                {
                    string nombre1 = "", nombre2 = "", nombre3 = "";
                    if (radioButton1.Checked)
                    {
                        nombre1 = nombres[random.Next(0, pos)];
                        do
                        {
                            nombre2 = nombres[random.Next(0, pos)];
                        } while (nombre1 == nombre2);

                        textBox5.AppendText($"\r\nNombre generado: {nombre1} {nombre2}");
                    }
                    else
                    {
                        nombre1 = nombres[random.Next(1, pos)];
                        do
                        {
                            nombre2 = nombres[random.Next(0, pos)];
                            nombre3 = nombres[random.Next(0, pos)];
                        } while (nombre1 == nombre2 || nombre1 == nombre3 || nombre2 == nombre3);
                        textBox5.AppendText($"\r\nNombre generado: {nombre1} {nombre2} {nombre3}");
                    }
                }
            }
        }
    }
}
