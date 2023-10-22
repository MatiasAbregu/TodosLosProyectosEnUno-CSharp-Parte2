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
 * Estadística Descriptiva - Crear un formulario que permita almacenar en un array de 10 
 * posiciones números enteros positivos. Debe poder mostrarse y calcular la media de dichos 
 * números.
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class estadisticaDescr : Form
    {
        private int[] numeros = new int[10];
        private int pos = 0;

        public estadisticaDescr()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pos > 9)
            {
                MessageBox.Show("Array lleno, vuelve a iniciar la interfaz");
            } else if(int.Parse(textBox1.Text) == 0)
            {
                MessageBox.Show("No se permite el 0, solo números enteros positivos.");
            }
            else
            {
                textBox4.Text = "";
                numeros[pos] = int.Parse(textBox1.Text);
                pos++;
                for (int i = 0; i < numeros.Length; i++)
                {
                    if (numeros[i] != 0)
                    {
                        textBox4.AppendText($"Pos: {i + 1}, Valor: {numeros[i]}\r\n");
                    }
                }
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (Char.IsLetter(e.KeyChar) || Char.IsSymbol(e.KeyChar) ||
             Char.IsPunctuation(e.KeyChar))
            {
                MessageBox.Show("Solo se admiten números enteros positivos.");
                e.Handled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            double promedio = 0;
            int cantNumeros = 0;
            for (int i = 0; i < numeros.Length; i++)
            {
                if (numeros[i] != 0)
                {
                    promedio += numeros[i];
                    cantNumeros++;
                }
            }

            textBox4.AppendText($"\r\nPromedio: {promedio / cantNumeros}");
        }
    }
}
