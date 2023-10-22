using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*DESARROLLADO POR MATIAS ABREGU
 *
 * 2) Hacer un formulario que permita almacenar en un array [3] los 3 tiros de 5 dados. Mostrar 
 * resultados de las 3 tiradas
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class tirarDados : Form
    {
        private static Random valorDado = new Random();
        private todosLosDados[] tiros = new todosLosDados[3];

        public tirarDados()
        {
            InitializeComponent();
        }

        private class todosLosDados
        {
            private int dado1, dado2, dado3, dado4, dado5;
            public todosLosDados(int dado1, int dado2, int dado3, int dado4, int dado5)
            {
                this.dado1 = dado1;
                this.dado2 = dado2;
                this.dado3 = dado3;
                this.dado4 = dado4;
                this.dado5 = dado5;
            }

            public int[] devolverDados()
            {
                int[] dados = { dado1, dado2, dado3, dado4, dado5 };
                return dados;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try {
                tiros = new todosLosDados[3];
                for (int i = 0; i < tiros.Length; i++)
                {
                    tiros[i] = new todosLosDados(valorDado.Next(1, 6), valorDado.Next(1, 6),
                    valorDado.Next(1, 6), valorDado.Next(1, 6), valorDado.Next(1, 6));
                }

                for (int i = 0; i < tiros.Length; i++)
                {
                    if (i == 0) textBox4.AppendText("Primer tirada: \r\n");
                    else if (i == 1) textBox4.AppendText("\r\nSegunda tirada: \r\n");
                    else textBox4.AppendText("\r\nTercer tirada: \r\n");

                    int[] valores = tiros[i].devolverDados();
                    int numDado = 1;
                    foreach (int valorD in valores)
                    {
                        textBox4.AppendText($"Dado {numDado}: {valorD} \r\n");
                        numDado++;
                    }
                }
            }
            catch(Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
