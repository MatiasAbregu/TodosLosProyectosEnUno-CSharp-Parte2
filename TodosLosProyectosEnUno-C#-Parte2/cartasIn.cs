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
 * Cartas - Hacer un formulario que baraje 3 cartas de manera aleatoria (las cartas posibles 
 * tienen valor de 1 a 12 y pueden ser 4 variedades -espada, basto, copas, oro-). Dichas
 * posibilidades deben estar en 2 arrays separados (uno para los valores del 1 al 12 y otro 
 * para los palos)
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class cartasIn : Form
    {
        private string[] variedad = {"Espada", "Basto", "Copas", "Oro"};
        private int[] valores = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12};
        private Random rand = new Random();

        public cartasIn()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.AppendText($"{variedad[rand.Next(0,4)]}\r\n" +
                $"{valores[rand.Next(0, 12)]}");

            textBox2.Text = "";
            textBox2.AppendText($"{variedad[rand.Next(0, 4)]}\r\n" +
                $"{valores[rand.Next(0, 12)]}");

            textBox3.Text = "";
            textBox3.AppendText($"{variedad[rand.Next(0, 4)]}\r\n" +
                $"{valores[rand.Next(0, 12)]}");
        }
    }
}
