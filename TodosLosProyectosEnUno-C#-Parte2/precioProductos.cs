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
 * Precios de productos - Hacer un formulario que permita cargar en un List de precios 3 
 * productos. Estos productos deben estar en un ComboBox. La lista de precios debe visualizarse
 * pudiendo filtrarse por producto.
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class precioProductos : Form
    {
        private List<Productos> listaPrecios = new List<Productos>();

        public precioProductos()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Este campo no se puede alterar.");
            e.Handled = true;
            return;
        }

        private class Productos
        {
            private double price;
            private string name;

            public Productos(string name, double price)
            {
                this.name = name;
                this.price = price;
            }

            public string getName()
            {
                return name;
            }

            public double getPrice()
            {
                return price;
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar.ToString() == "." || Char.IsControl(e.KeyChar))
            {
                return;
            }

            if (!Char.IsNumber(e.KeyChar))
            {
                MessageBox.Show("Solo números.");
                e.Handled = true;
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") MessageBox.Show("Ingresa un precio antes de continuar");
            else
            {
                listaPrecios.Add(new Productos(comboBox1.SelectedItem.ToString(),
                    double.Parse(textBox1.Text)));
                filtrarProducto("");
            }
        }

        private void filtrarProducto(string producto)
        {
            textBox4.Text = "";
            if (producto == "")
            {
                foreach (var item in listaPrecios)
                {
                    textBox4.AppendText($"Producto: {item.getName()}, Precio: {item.getPrice()}\r\n");
                }
            }
            else
            {
                foreach (var item in listaPrecios)
                {
                    if (item.getName() == producto)
                    {
                        textBox4.Text = $"Producto: {item.getName()}, Precio: {item.getPrice()}\r\n" + textBox4.Text;
                    }
                    else
                        textBox4.Text += $"Producto: {item.getName()}, Precio: {item.getPrice()}\r\n";
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            filtrarProducto(comboBox1.SelectedItem.ToString());
        }
    }
}
