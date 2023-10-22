using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

/*DESARROLLADO POR MATIAS ABREGU
 * 3) Encuesta Anónima - Hacer una lista que guarde en una List las respuestas a 3 preguntas 
 * (las preguntas deben usarse 1 con RadioButton, otra con CheckList y otra con ComboBox)
 * Cada vez que se agrega un nuevo elemento debe mostrarse los resultados en un control a 
 * elección.
 */
namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class encuestaAnonima : Form
    {

        Dictionary<String, int> listaVotos = new Dictionary<String, int>()
        {
            {"Hombre", 0 }, {"Mujer", 0}, {"PC", 0}, {"Switch", 0}, {"Nintendo3DS", 0},
            {"PSP", 0}, {"PS3", 0}, {"PS4", 0}, {"Xbox360", 0}, {"XboxOne", 0}, {"Wii", 0},
            {"MH", 0}, {"MHF", 0}, {"MH2", 0}, {"MHFU", 0}, {"MH3", 0}, {"MH3U", 0}, {"MH4", 0},
            {"MH4U", 0}, {"MHG", 0}, {"MHWI", 0}, {"MHRS", 0}
        };

        public encuestaAnonima()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            radioButton1.Checked = false;
            radioButton2.Checked = false;
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("Este campo no es modificable");
            e.Handled = true;
            return;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Selecciona un sexo antes de continuar.");
            }
            else if (checkedListBox1.CheckedItems.Count == 0)
            {
                MessageBox.Show("Selecciona un juego antes de continuar.");
            }
            else
            {
                textBox4.Text = "Votos totales: \r\n\r\n";
                contarVotos();

                for (int i = 0; i < listaVotos.Count; i++)
                {
                    if(i == 0) textBox4.AppendText($"Hombres: {listaVotos["Hombre"]}\r\n");
                    else if (i == 1) textBox4.AppendText($"Mujeres: {listaVotos["Mujer"]}\r\n\r\n");
                    else if (i == 2) textBox4.AppendText($"PC: {listaVotos["PC"]}\r\n");
                    else if (i == 3) textBox4.AppendText($"Switch: {listaVotos["Switch"]}\r\n");
                    else if (i == 4) textBox4.AppendText($"Nintendo 3DS: " +
                        $"{listaVotos["Nintendo3DS"]}\r\n");
                    else if (i == 5) textBox4.AppendText($"PSP: {listaVotos["PSP"]}\r\n");
                    else if (i == 6) textBox4.AppendText($"PS3: {listaVotos["PS3"]}\r\n");
                    else if (i == 7) textBox4.AppendText($"PS4: {listaVotos["PS4"]}\r\n");
                    else if (i == 8) textBox4.AppendText($"Xbox 360: {listaVotos["Xbox360"]}\r\n");
                    else if (i == 9) textBox4.AppendText($"Xbox One: {listaVotos["XboxOne"]}\r\n");
                    else if (i == 10) textBox4.AppendText($"Wii: {listaVotos["Wii"]}\r\n\r\n");
                    else if (i == 11) textBox4.AppendText($"Monster Hunter: {listaVotos["MH"]}\r\n");
                    else if (i == 12) textBox4.AppendText($"Monster Hunter Freedom: " +
                        $"{listaVotos["MHF"]}\r\n");
                    else if (i == 13) textBox4.AppendText($"Monster Hunter 2: {listaVotos["MH2"]}\r\n");
                    else if (i == 14) textBox4.AppendText($"Monster Hunter Freedom United: " +
                        $"{listaVotos["MHFU"]}\r\n");
                    else if (i == 15) textBox4.AppendText($"Monster Hunter 3: {listaVotos["MH3"]}\r\n");
                    else if (i == 16) textBox4.AppendText($"Monster Hunter 3 Ultimate: " +
                        $"{listaVotos["MH3U"]}\r\n");
                    else if (i == 17) textBox4.AppendText($"Monster Hunter 4: {listaVotos["MH4"]}\r\n");
                    else if (i == 18) textBox4.AppendText($"Monster Hunter 4 Ultimate: " +
                        $"{listaVotos["MH4U"]}\r\n");
                    else if (i == 19) textBox4.AppendText($"Monster Hunter Generations: " +
                        $"{listaVotos["MHG"]}\r\n");
                    else if (i == 20) textBox4.AppendText($"Monster Hunter World Iceborne: " +
                        $"{listaVotos["MHWI"]}\r\n");
                    else if (i == 21) textBox4.AppendText($"Monster Hunter Rise Sunbreak: " +
                        $"{listaVotos["MHRS"]}\r\n");
                }
            }
        }

        private void contarVotos()
        {
            if (radioButton1.Checked) listaVotos["Hombre"] += 1;
            else listaVotos["Mujer"] += 1;

            if (comboBox1.SelectedItem.ToString() == "PC") listaVotos["PC"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "Switch") listaVotos["Switch"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "Nintendo 3DS") listaVotos["Nintendo3DS"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "PSP") listaVotos["PSP"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "PS3") listaVotos["PS3"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "PS4") listaVotos["PS4"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "Xbox 360") listaVotos["Xbox360"] += 1;
            else if (comboBox1.SelectedItem.ToString() == "Xbox One") listaVotos["XboxOne"] += 1;
            else listaVotos["Wii"] += 1;

            foreach (var item in checkedListBox1.CheckedItems)
            {
                switch (item.ToString())
                {
                    case "Monster Hunter":
                        listaVotos["MH"] += 1;
                        break;
                    case "Monster Hunter Freedom":
                        listaVotos["MHF"] += 1;
                        break;
                    case "Monster Hunter 2":
                        listaVotos["MH2"] += 1;
                        break;
                    case "Monster Hunter Freedom United":
                        listaVotos["MHFU"] += 1;
                        break;
                    case "Monster Hunter 3":
                        listaVotos["MH3"] += 1;
                        break;
                    case "Monster Hunter 3 Ultimate":
                        listaVotos["MH3U"] += 1;
                        break;
                    case "Monster Hunter 4":
                        listaVotos["MH4"] += 1;
                        break;
                    case "Monster Hunter 4 Ultimate":
                        listaVotos["MH4U"] += 1;
                        break;
                    case "Monster Hunter Generations":
                        listaVotos["MHG"] += 1;
                        break;
                    case "Monster Hunter World Iceborne":
                        listaVotos["MHWI"] += 1;
                        break;
                    case "Monster Hunter Rise Sunbreak":
                        listaVotos["MHRS"] += 1;
                        break;
                }
            }

        }
    }
}
