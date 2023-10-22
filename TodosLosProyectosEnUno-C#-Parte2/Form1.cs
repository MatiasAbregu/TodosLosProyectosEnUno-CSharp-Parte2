using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            new guiaTel().Visible = true;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Default;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            new tirarDados().Visible = true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            new encuestaAnonima().Visible = true;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            new estadisticaDescr().Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {
            new precioProductos().Visible = true;
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {
            new deportes().Visible = true;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            new combinarNombres().Visible = true;
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            new cartasIn().Visible = true;
        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {
            new batallaNaval().Visible = true;
        }
    }
}
