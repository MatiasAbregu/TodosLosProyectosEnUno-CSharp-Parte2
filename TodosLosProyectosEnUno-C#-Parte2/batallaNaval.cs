using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Batalla naval - Formulario que tenga 3 arrays: uno para un barco grande (array de 4 
 * elementos), otro para uno mediano (array de 3 elementos) y uno pequeño (array de 2 
 * elementos). Los valores de los elementos del array surgen de combinar de manera aleatoria 
 * números del 0 al 5 y letras de la A a la F. Debe existir 2 groupbox de RadioButton con los
 * números del 0 al 5 y otro con las letras de la A a la F. Al seleccionar letra y número y 
 * presionar el boton "atacar" debe decir si hemos acertado en algúno de los barcos.
 */

namespace TodosLosProyectosEnUno_C__Parte2
{
    public partial class batallaNaval : Form
    {
        //○ = Vacio 🅞 = Barco ⨷ = Golpeado 
        private Label[] posiciones = new Label[36];
        private int x = 91, y = 56, posAlt = 0, posLet = 0, cantRestDeEspacios = 0,
            radioButtonActual = 0, numFicha = 0;
        private int[] alturas = { 1, 2, 3, 4, 5, 6 };
        private String[] letras = { "A", "B", "C", "D", "E", "F" };
        private bool control = false;
        private string primerFicha, segundaFicha, tercerFicha;
        private Random randomizadorPos = new Random();
        private List<String> posicionesAtacadas = new List<string>(),
            posicionesMostrar = new List<string>(), posicionesAtacadasXIA = new List<string>();

        //1 barco grande (4 casillas)
        //1 mediano (3 casillas) 
        //2 pequeño(2 casillas)
        private String[] barcoGrande = new string[4];
        private String[] barcoMediano = new string[3];
        private String[] barcoPeque1 = new string[2];
        private String[] barcoPeque2 = new string[2];

        public batallaNaval()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            String[] barcoFicha, barcoFicha2 = { }, posibilidades = new string[4];
            int posIni = 0, retroceso = 0, letraIniParaBarcoP = 0;
            bool chocando = false;

            //************************************************************************
            //BarcoGrande
            barcoGrande[0] = $"{letras[randomizadorPos.Next(0, 6)]}," +
                $"{alturas[randomizadorPos.Next(0, 6)]}";
            barcoFicha = barcoGrande[0].Split(',');

            if (randomizadorPos.Next(1, 3) == 1) //Horizontal
            {
                for (int i = 0; i < letras.Length; i++) if (barcoFicha[0] == letras[i]) posIni = i;

                if (randomizadorPos.Next(1, 3) == 1) //Der
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (posIni + (i + 1) < 6)
                        {
                            barcoGrande[i + 1] = $"{letras[posIni + (i + 1)]},{barcoFicha[1]}";
                        }
                        else
                        {
                            retroceso++;
                            barcoGrande[i + 1] = $"{letras[posIni - retroceso]},{barcoFicha[1]}";
                        }
                    }
                }
                else //Izq
                {
                    int aux = 1;
                    for (int i = 0; i < 3; i++)
                    {
                        if (posIni - aux > -1)
                        {
                            barcoGrande[i + 1] = $"{letras[posIni - aux]},{barcoFicha[1]}";
                        }
                        else
                        {
                            retroceso++;
                            barcoGrande[i + 1] = $"{letras[posIni + retroceso]}," +
                                $"{barcoFicha[1]}";
                        }
                        aux++;
                    }
                }
            }
            else //Vertical
            {
                posIni = int.Parse(barcoFicha[1]);

                if (randomizadorPos.Next(1, 3) == 1) //Abajo
                {
                    for (int i = 0; i < 3; i++)
                    {
                        if (posIni + (i + 1) < 7)
                        {
                            barcoGrande[i + 1] = $"{barcoFicha[0]},{posIni + (i + 1)}";
                        }
                        else
                        {
                            retroceso++;
                            barcoGrande[i + 1] = $"{barcoFicha[0]},{posIni - retroceso}";
                        }
                    }
                }
                else //Arriba
                {
                    int aux = 1;
                    for (int i = 0; i < 3; i++)
                    {
                        if (posIni - aux > 0)
                        {
                            barcoGrande[i + 1] = $"{barcoFicha[0]},{posIni - aux}";
                        }
                        else
                        {
                            retroceso++;
                            barcoGrande[i + 1] = $"{barcoFicha[0]},{posIni + retroceso}";
                        }
                        aux++;
                    }
                }
            }

            //************************************************************************
            //BarcoMediano
            do
            {
                barcoMediano[0] = $"{letras[randomizadorPos.Next(0, 6)]}," +
                    $"{alturas[randomizadorPos.Next(0, 6)]}";
            } while (barcoMediano[0] == barcoGrande[0] || barcoMediano[0] == barcoGrande[1] ||
                     barcoMediano[0] == barcoGrande[2] || barcoMediano[0] == barcoGrande[3]);

            barcoFicha = barcoMediano[0].Split(',');
            retroceso = 0;

            if (randomizadorPos.Next(1, 3) == 1) //Horizontal
            {
                for (int i = 0; i < letras.Length; i++) if (barcoFicha[0] == letras[i]) posIni = i;

                if (randomizadorPos.Next(1, 3) == 1) //Der
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (posIni + (i + 1) < 6)
                        {
                            barcoMediano[i + 1] = $"{letras[posIni + (i + 1)]},{barcoFicha[1]}";
                        }
                        else
                        {
                            retroceso++;
                            barcoMediano[i + 1] = $"{letras[posIni - retroceso]},{barcoFicha[1]}";
                        }
                    }
                }
                else //Izq
                {
                    int aux = 1;
                    for (int i = 0; i < 2; i++)
                    {
                        if (posIni - aux > -1)
                        {
                            barcoMediano[i + 1] = $"{letras[posIni - aux]},{barcoFicha[1]}";
                        }
                        else
                        {
                            retroceso++;
                            barcoMediano[i + 1] = $"{letras[posIni + retroceso]}," +
                                $"{barcoFicha[1]}";
                        }
                        aux++;
                    }
                }
            }
            else //Vertical
            {
                posIni = int.Parse(barcoFicha[1]);

                if (randomizadorPos.Next(1, 3) == 1) //Abajo
                {
                    for (int i = 0; i < 2; i++)
                    {
                        if (posIni + (i + 1) < 7)
                        {
                            barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni + (i + 1)}";
                        }
                        else
                        {
                            retroceso++;
                            barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni - retroceso}";
                        }
                    }
                }
                else //Arriba
                {
                    int aux = 1;
                    for (int i = 0; i < 2; i++)
                    {
                        if (posIni - aux > 0)
                        {
                            barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni - aux}";
                        }
                        else
                        {
                            retroceso++;
                            barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni + retroceso}";
                        }
                        aux++;
                    }
                }
            }

            //Comprobar si choco
            for (int i = 0; i < barcoMediano.Length; i++)
            {
                for (int j = 0; j < barcoGrande.Length; j++)
                {
                    if (barcoMediano[i] == barcoGrande[j])
                    {
                        chocando = true;
                        barcoFicha = barcoMediano[i].Split(',');
                        barcoFicha2 = barcoGrande[j].Split(',');
                        break;
                    }
                }
            }

            retroceso = 0;
            if (chocando)
            {
                if (barcoFicha[0] == barcoFicha2[0]) //Chocaron en las letras (Eje X)
                {
                    barcoFicha = barcoMediano[0].Split(',');
                    posIni = int.Parse(barcoFicha[1]);

                    if (randomizadorPos.Next(1, 3) == 1) //Abajo
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (posIni + (i + 1) < 7)
                            {
                                barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni + (i + 1)}";
                            }
                            else
                            {
                                retroceso++;
                                barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni - retroceso}";
                            }
                        }
                    }
                    else //Arriba
                    {
                        int aux = 1;
                        for (int i = 0; i < 2; i++)
                        {
                            if (posIni - aux > 0)
                            {
                                barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni - aux}";
                            }
                            else
                            {
                                retroceso++;
                                barcoMediano[i + 1] = $"{barcoFicha[0]},{posIni + retroceso}";
                            }
                            aux++;
                        }
                    }
                }
                else //Chocaron en los numeros (Eje Y)
                {
                    barcoFicha = barcoMediano[0].Split(',');
                    for (int i = 0; i < letras.Length; i++) if (barcoFicha[0] == letras[i]) posIni = i;

                    if (randomizadorPos.Next(1, 3) == 1) //Der
                    {
                        for (int i = 0; i < 2; i++)
                        {
                            if (posIni + (i + 1) < 6)
                            {
                                barcoMediano[i + 1] = $"{letras[posIni + (i + 1)]},{barcoFicha[1]}";
                            }
                            else
                            {
                                retroceso++;
                                barcoMediano[i + 1] = $"{letras[posIni - retroceso]},{barcoFicha[1]}";
                            }
                        }
                    }
                    else //Izq
                    {
                        int aux = 1;
                        for (int i = 0; i < 2; i++)
                        {
                            if (posIni - aux > -1)
                            {
                                barcoMediano[i + 1] = $"{letras[posIni - aux]},{barcoFicha[1]}";
                            }
                            else
                            {
                                retroceso++;
                                barcoMediano[i + 1] = $"{letras[posIni + retroceso]}," +
                                    $"{barcoFicha[1]}";
                            }
                            aux++;
                        }
                    }
                }
            }

            //************************************************************************
            //BarcoPeque1 
            do
            {
                string arriba = "", abajo = "", derecha = "", izquierda = "";
                do
                {
                    barcoPeque1[0] = $"{letras[randomizadorPos.Next(0, 6)]}," +
                        $"{alturas[randomizadorPos.Next(0, 6)]}";
                } while (barcoPeque1[0] == barcoGrande[0] || barcoPeque1[0] == barcoGrande[1] ||
                     barcoPeque1[0] == barcoGrande[2] || barcoPeque1[0] == barcoGrande[3] ||
                     barcoPeque1[0] == barcoMediano[0] || barcoPeque1[0] == barcoMediano[1] ||
                     barcoPeque1[0] == barcoMediano[2]);

                barcoFicha = barcoPeque1[0].Split(',');
                posIni = int.Parse(barcoFicha[1]); //Num compañero de letra
                int pos = 0;

                for (int i = 0; i < letras.Length; i++) //Num Letra
                {
                    if (letras[i] == barcoFicha[0])
                    {
                        letraIniParaBarcoP = i;
                    }
                }

                for (int i = 0; i < barcoGrande.Length; i++)
                {
                    if (posIni - 1 > 0)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni - 1}" == barcoGrande[i])
                        {
                            arriba = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        }
                    }

                    if (posIni + 1 < 7)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni + 1}" == barcoGrande[i])
                        {
                            abajo = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        }
                    }

                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        if ($"{letras[letraIniParaBarcoP + 1]},{posIni}" == barcoGrande[i])
                        {
                            derecha = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        }
                    }

                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        if ($"{letras[letraIniParaBarcoP - 1]},{posIni - 1}" == barcoGrande[i])
                        {
                            izquierda = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                        }
                    }
                }

                for (int i = 0; i < barcoMediano.Length; i++)
                {
                    if (posIni - 1 > 0)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni - 1}" == barcoMediano[i])
                        {
                            arriba = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        }
                    }

                    if (posIni + 1 < 7)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni + 1}" == barcoMediano[i])
                        {
                            abajo = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        }
                    }

                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        if ($"{letras[letraIniParaBarcoP + 1]},{posIni}" == barcoMediano[i])
                        {
                            derecha = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        }
                    }

                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        if ($"{letras[letraIniParaBarcoP - 1]},{posIni - 1}" == barcoMediano[i])
                        {
                            izquierda = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                        }
                    }
                }

                if (arriba == "")
                {
                    if (posIni - 1 > 0)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        pos++;
                    }
                }
                if (abajo == "")
                {
                    if (posIni + 1 < 7)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        pos++;
                    }
                }
                if (derecha == "")
                {
                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        pos++;
                    }
                }
                if (izquierda == "")
                {
                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                    }
                }
            } while (posibilidades[0] == null);

            int pos2 = 0;
            for (int i = 0; i < posibilidades.Length; i++) if (posibilidades[i] != null) pos2++;

            if (posibilidades[1] == null) barcoPeque1[1] = posibilidades[0];
            else barcoPeque1[1] = posibilidades[randomizadorPos.Next(0, pos2)];

            //************************************************************************
            //BarcoPeque2
            posibilidades = new string[4];
            do
            {
                string arriba = "", abajo = "", derecha = "", izquierda = "";
                do
                {
                    barcoPeque2[0] = $"{letras[randomizadorPos.Next(0, 6)]}," +
                        $"{alturas[randomizadorPos.Next(0, 6)]}";
                } while (barcoPeque2[0] == barcoGrande[0] || barcoPeque2[0] == barcoGrande[1] ||
                     barcoPeque2[0] == barcoGrande[2] || barcoPeque2[0] == barcoGrande[3] ||
                     barcoPeque2[0] == barcoMediano[0] || barcoPeque2[0] == barcoMediano[1] ||
                     barcoPeque2[0] == barcoMediano[2] || barcoPeque2[0] == barcoPeque1[0] ||
                     barcoPeque2[0] == barcoPeque1[1]);

                barcoFicha = barcoPeque2[0].Split(',');
                posIni = int.Parse(barcoFicha[1]); //Num compañero de letra
                int pos = 0;

                for (int i = 0; i < letras.Length; i++) //Num Letra
                {
                    if (letras[i] == barcoFicha[0]) letraIniParaBarcoP = i;
                }

                for (int i = 0; i < barcoGrande.Length; i++)
                {
                    if (posIni - 1 > 0)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni - 1}" == barcoGrande[i])
                        {
                            arriba = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        }
                    }

                    if (posIni + 1 < 7)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni + 1}" == barcoGrande[i])
                        {
                            abajo = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        }
                    }

                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        if ($"{letras[letraIniParaBarcoP + 1]},{posIni}" == barcoGrande[i])
                        {
                            derecha = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        }
                    }

                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        if ($"{letras[letraIniParaBarcoP - 1]},{posIni - 1}" == barcoGrande[i])
                        {
                            izquierda = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                        }
                    }
                }

                for (int i = 0; i < barcoMediano.Length; i++)
                {
                    if (posIni - 1 > 0)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni - 1}" == barcoMediano[i])
                        {
                            arriba = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        }
                    }

                    if (posIni + 1 < 7)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni + 1}" == barcoMediano[i])
                        {
                            abajo = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        }
                    }

                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        if ($"{letras[letraIniParaBarcoP + 1]},{posIni}" == barcoMediano[i])
                        {
                            derecha = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        }
                    }

                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        if ($"{letras[letraIniParaBarcoP - 1]},{posIni - 1}" == barcoMediano[i])
                        {
                            izquierda = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                        }
                    }
                }

                for (int i = 0; i < barcoPeque1.Length; i++)
                {
                    if (posIni - 1 > 0)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni - 1}" == barcoPeque1[i])
                        {
                            arriba = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        }
                    }

                    if (posIni + 1 < 7)
                    {
                        if ($"{letras[letraIniParaBarcoP]},{posIni + 1}" == barcoPeque1[i])
                        {
                            abajo = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        }
                    }

                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        if ($"{letras[letraIniParaBarcoP + 1]},{posIni}" == barcoPeque1[i])
                        {
                            derecha = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        }
                    }

                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        if ($"{letras[letraIniParaBarcoP - 1]},{posIni - 1}" == barcoPeque1[i])
                        {
                            izquierda = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                        }
                    }
                }

                if (arriba == "")
                {
                    if (posIni - 1 > 0)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP]},{posIni - 1}";
                        pos++;
                    }
                }
                if (abajo == "")
                {
                    if (posIni + 1 < 7)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP]},{posIni + 1}";
                        pos++;
                    }
                }
                if (derecha == "")
                {
                    if (letraIniParaBarcoP + 1 < 6)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP + 1]},{posIni}";
                        pos++;
                    }
                }
                if (izquierda == "")
                {
                    if (letraIniParaBarcoP - 1 > -1)
                    {
                        posibilidades[pos] = $"{letras[letraIniParaBarcoP - 1]},{posIni}";
                    }
                }
            } while (posibilidades[0] == null);

            pos2 = 0;
            for (int i = 0; i < posibilidades.Length; i++) if (posibilidades[i] != null) pos2++;

            if (posibilidades[1] == null) barcoPeque2[1] = posibilidades[0];
            else barcoPeque2[1] = posibilidades[randomizadorPos.Next(0, pos2)];
        }

        private void batallaNaval_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < posiciones.Length; i++)
            {
                posiciones[i] = new Label();
                posiciones[i].Text = "○";
                if (i > 0)
                {
                    if (i == 6 || i == 12 || i == 18 || i == 24 || i == 30)
                    {
                        x = 91;
                        y += 40;
                        posAlt++;
                        posLet = 0;
                    }
                    else
                    {
                        x += 50;
                        posLet++;
                    }
                }
                posiciones[i].SetBounds(x, y, 35, 21);
                posiciones[i].Name = $"{letras[posLet]},{alturas[posAlt]}";
                posiciones[i].Font = new Font("Microsoft Sans Serif", 16);
                posiciones[i].Click += new EventHandler(clickEnLabel);
                this.Controls.Add(posiciones[i]);
            }
        }

        private void clickEnLabel(object sender, EventArgs e)
        {
            if (!radioButton1.Checked && !radioButton2.Checked && !radioButton3.Checked &&
                !radioButton4.Checked)
            {
                MessageBox.Show("Selecciona un barco antes de comenzar a colocar.");
            }
            else
            {
                var label = (Label)sender;
                control = true;

                if (label.Text == "🅞")
                {
                    MessageBox.Show("Espacio ocupado, prueba otro lugar.");
                }
                else
                {
                    if (numFicha == 0)
                    {
                        label.Text = "🅞";
                        cantRestDeEspacios--;
                        numFicha++;
                        primerFicha = label.Name;
                    }
                    else if (numFicha == 1)
                    {
                        string[] ficha = primerFicha.Split(',');
                        string[] labelCor = label.Name.Split(',');

                        if (ficha[0] == labelCor[0])
                        {
                            string numArriba = "", numAbajo = "";
                            for (int i = 0; i < alturas.Length; i++)
                            {
                                if (ficha[1] == alturas[i].ToString())
                                {
                                    if (alturas[i] == 1)
                                    {
                                        numArriba = "";
                                        numAbajo = alturas[i + 1].ToString();
                                    }
                                    else if (alturas[i] == 6)
                                    {
                                        numArriba = alturas[i - 1].ToString();
                                        numAbajo = "";
                                    }
                                    else
                                    {
                                        numArriba = alturas[i - 1].ToString();
                                        numAbajo = alturas[i + 1].ToString();
                                    }
                                }
                            }

                            if (labelCor[1] == numArriba || labelCor[1] == numAbajo)
                            {
                                label.Text = "🅞";
                                cantRestDeEspacios--;
                                numFicha++;
                                segundaFicha = label.Name;
                            }
                            else
                            {
                                MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                            }
                        }
                        else if (ficha[1] == labelCor[1])
                        {
                            string letraDer = "", letraIzq = "";
                            for (int i = 0; i < letras.Length; i++)
                            {
                                if (ficha[0] == letras[i].ToString())
                                {
                                    if (letras[i] == "A")
                                    {
                                        letraIzq = "";
                                        letraDer = letras[i + 1].ToString();
                                    }
                                    else if (letras[i] == "F")
                                    {
                                        letraIzq = letras[i - 1].ToString();
                                        letraDer = "";
                                    }
                                    else
                                    {
                                        letraIzq = letras[i - 1].ToString();
                                        letraDer = letras[i + 1].ToString();
                                    }
                                }
                            }

                            if (labelCor[0] == letraDer || labelCor[0] == letraIzq)
                            {
                                label.Text = "🅞";
                                cantRestDeEspacios--;
                                numFicha++;
                                segundaFicha = label.Name;
                            }
                            else
                            {
                                MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                            }
                        }
                        else
                        {
                            MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                        }
                    }
                    else if (numFicha == 2)
                    {
                        string[] ficha = primerFicha.Split(',');
                        string[] ficha2 = segundaFicha.Split(',');
                        string fichaAbajo, fichaArriba, fichaDer, fichaIzq;

                        if (ficha[0] == ficha2[0]) //Si letra es la misma trabaja en Eje Y
                        {
                            if (int.Parse(ficha[1]) > int.Parse(ficha2[1])) //Si ficha A, es mayor que ficha B
                            {
                                //Ficha 1, esta abajo de la ficha 2
                                fichaAbajo = $"{ficha[0]},{int.Parse(ficha[1]) + 1}";
                                fichaArriba = $"{ficha2[0]},{int.Parse(ficha2[1]) - 1}";
                            }
                            else
                            {
                                //Ficha 2, esta abajo de la ficha 1
                                fichaAbajo = $"{ficha2[0]},{int.Parse(ficha2[1]) + 1}";
                                fichaArriba = $"{ficha[0]},{int.Parse(ficha[1]) - 1}";
                            }

                            if (label.Name == fichaArriba || label.Name == fichaAbajo)
                            {
                                label.Text = "🅞";
                                cantRestDeEspacios--;
                                numFicha++;
                                tercerFicha = label.Name;
                            }
                            else
                            {
                                MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                            }
                        }
                        else //Si numero es el mismo trabaja en Eje X
                        {
                            int posF1 = 0, posF2 = 0;
                            // "A", "B", "C", "D", "E", "F"
                            for (int i = 0; i < letras.Length; i++)
                            {
                                if (ficha[0] == letras[i])
                                {
                                    posF1 = i;
                                }
                                else if (ficha2[0] == letras[i])
                                {
                                    posF2 = i;
                                }
                            }

                            if (posF1 > posF2)
                            {
                                if (posF1 != 5) fichaDer = $"{letras[posF1 + 1]},{ficha[1]}";
                                else fichaDer = "";

                                if (posF2 != 0) fichaIzq = $"{letras[posF2 - 1]},{ficha2[1]}";
                                else fichaIzq = "";
                            }
                            else
                            {
                                if (posF2 != 5) fichaDer = $"{letras[posF2 + 1]},{ficha2[1]}";
                                else fichaDer = "";

                                if (posF1 != 0) fichaIzq = $"{letras[posF1 - 1]},{ficha[1]}";
                                else fichaIzq = "";
                            }

                            if (label.Name == fichaDer || label.Name == fichaIzq)
                            {
                                label.Text = "🅞";
                                cantRestDeEspacios--;
                                numFicha++;
                                tercerFicha = label.Name;
                            }
                            else
                            {
                                MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                            }
                        }
                    }
                    else
                    {
                        string[] ficha = primerFicha.Split(',');
                        string[] ficha2 = segundaFicha.Split(',');
                        string[] ficha3 = tercerFicha.Split(',');
                        string fichaAbajo, fichaArriba, fichaDer, fichaIzq;

                        if (ficha[0] == ficha2[0]) //Si letra es la misma, trabaja en Eje Y
                        {
                            int opcion = 0;
                            if (int.Parse(ficha[1]) > int.Parse(ficha2[1]) &&
                                int.Parse(ficha[1]) > int.Parse(ficha3[1])) //Si ficha A, es mayor que ficha B y que fichaC
                            {
                                opcion = 1;
                                fichaAbajo = $"{ficha[0]},{int.Parse(ficha[1]) + 1}";

                                if (int.Parse(ficha2[1]) > int.Parse(ficha3[1]))
                                {
                                    fichaArriba = $"{ficha3[0]},{int.Parse(ficha3[1]) - 1}";
                                }
                                else
                                {
                                    fichaArriba = $"{ficha2[0]},{int.Parse(ficha2[1]) - 1}";
                                }
                            }
                            else if (int.Parse(ficha2[1]) > int.Parse(ficha3[1]))
                            {
                                opcion = 2;
                                fichaAbajo = $"{ficha2[0]},{int.Parse(ficha2[1]) + 1}";

                                if (int.Parse(ficha[1]) > int.Parse(ficha3[1]))
                                {
                                    fichaArriba = $"{ficha3[0]},{int.Parse(ficha3[1]) - 1}";
                                }
                                else
                                {
                                    fichaArriba = $"{ficha[0]},{int.Parse(ficha[1]) - 1}";
                                }
                            }
                            else
                            {
                                opcion = 3;
                                fichaAbajo = $"{ficha3[0]},{int.Parse(ficha3[1]) + 1}";

                                if (int.Parse(ficha[1]) > int.Parse(ficha2[1]))
                                {
                                    fichaArriba = $"{ficha2[0]},{int.Parse(ficha2[1]) - 1}";
                                }
                                else
                                {
                                    fichaArriba = $"{ficha[0]},{int.Parse(ficha[1]) - 1}";
                                }
                            }

                            if (label.Name == fichaArriba || label.Name == fichaAbajo)
                            {
                                label.Text = "🅞";
                                cantRestDeEspacios--;
                                numFicha++;
                                tercerFicha = label.Name;
                            }
                            else
                            {
                                MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                            }
                        }
                        else //Si numero es el mismo, trabaja en Eje X
                        {
                            int posF1 = 0, posF2 = 0, posF3 = 0;
                            // "A", "B", "C", "D", "E", "F"
                            for (int i = 0; i < letras.Length; i++)
                            {
                                if (ficha[0] == letras[i])
                                {
                                    posF1 = i;
                                }
                                else if (ficha2[0] == letras[i])
                                {
                                    posF2 = i;
                                }
                                else if (ficha3[0] == letras[i])
                                {
                                    posF3 = i;
                                }
                            }

                            //Mientras más grande, más a la derecha y viceversa
                            if (posF1 > posF2 && posF1 > posF3)
                            {
                                if (posF1 != 5) fichaDer = $"{letras[posF1 + 1]},{ficha[1]}";
                                else fichaDer = "";

                                if (posF2 > posF3)
                                {
                                    if (posF3 != 0) fichaIzq = $"{letras[posF3 - 1]},{ficha3[1]}";
                                    else fichaIzq = "";
                                }
                                else
                                {
                                    if (posF2 != 0) fichaIzq = $"{letras[posF2 - 1]},{ficha2[1]}";
                                    else fichaIzq = "";
                                }
                            }
                            else if (posF2 > posF3)
                            {
                                if (posF2 != 5) fichaDer = $"{letras[posF2 + 1]},{ficha2[1]}";
                                else fichaDer = "";

                                if (posF1 > posF3)
                                {
                                    if (posF3 != 0) fichaIzq = $"{letras[posF3 - 1]},{ficha3[1]}";
                                    else fichaIzq = "";
                                }
                                else
                                {
                                    if (posF1 != 0) fichaIzq = $"{letras[posF1 - 1]},{ficha[1]}";
                                    else fichaIzq = "";
                                }
                            }
                            else
                            {
                                if (posF3 != 5) fichaDer = $"{letras[posF3 + 1]},{ficha3[1]}";
                                else fichaDer = "";

                                if (posF1 > posF2)
                                {
                                    if (posF2 != 0) fichaIzq = $"{letras[posF2 - 1]},{ficha2[1]}";
                                    else fichaIzq = "";
                                }
                                else
                                {
                                    if (posF1 != 0) fichaIzq = $"{letras[posF1 - 1]},{ficha[1]}";
                                    else fichaIzq = "";
                                }
                            }

                            if (label.Name == fichaDer || label.Name == fichaIzq)
                            {
                                label.Text = "🅞";
                                cantRestDeEspacios--;
                                numFicha++;
                                tercerFicha = label.Name;
                            }
                            else
                            {
                                MessageBox.Show("La ficha no se puede colocar aca, prueba en otro lado.");
                            }
                        }
                    }

                    if (cantRestDeEspacios == 0)
                    {
                        if (radioButtonActual == 1)
                        {
                            radioButton1.Enabled = false;
                            radioButton1.Checked = false;
                        }
                        else if (radioButtonActual == 2)
                        {
                            radioButton2.Enabled = false;
                            radioButton2.Checked = false;
                        }
                        else if (radioButtonActual == 3)
                        {
                            radioButton3.Enabled = false;
                            radioButton3.Checked = false;
                        }
                        else if (radioButtonActual == 4)
                        {
                            radioButton4.Enabled = false;
                            radioButton4.Checked = false;
                        }
                        numFicha = 0;
                        cantRestDeEspacios = 0;
                        primerFicha = "";
                        segundaFicha = "";
                        tercerFicha = "";
                        control = false;
                    }
                }
            }
        }

        private void comboBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            MessageBox.Show("No se puede modificar este campo con el teclado.");
            e.Handled = true;
            return;
        }

        private void radioButton1_Click(object sender, EventArgs e)
        {
            if (control)
            {
                MessageBox.Show("No puedes seleccionar otro hasta que no hayas " +
                    "asignado todos los espacios.");
                if (radioButtonActual == 1)
                {
                    radioButton1.Checked = true;
                }
                else if (radioButtonActual == 2)
                {
                    radioButton2.Checked = true;
                }
                else if (radioButtonActual == 3)
                {
                    radioButton3.Checked = true;
                }
                else if (radioButtonActual == 4)
                {
                    radioButton4.Checked = true;
                }
            }
            else
            {
                if (radioButton1.Checked)
                {
                    radioButtonActual = 1;
                    cantRestDeEspacios = 4;
                }
                else if (radioButton2.Checked)
                {
                    radioButtonActual = 2;
                    cantRestDeEspacios = 3;
                }
                else if (radioButton3.Checked)
                {
                    radioButtonActual = 3;
                    cantRestDeEspacios = 2;
                }
                else
                {
                    radioButtonActual = 4;
                    cantRestDeEspacios = 2;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!radioButton1.Enabled == false && !radioButton2.Enabled == false &&
                !radioButton3.Enabled == false && !radioButton4.Enabled == false)
            {
                MessageBox.Show("Coloca todos los barcos antes de atacar.");
            }
            else
            {
                bool permitido = true;
                foreach (var item in posicionesAtacadas)
                {
                    if ($"{comboBox2.SelectedItem},{comboBox1.SelectedItem}" == item)
                    {
                        permitido = false;
                        break;
                    }
                }

                if (!permitido)
                {
                    MessageBox.Show("No puedes atacar aqui porque ya has atacado.");
                }
                else
                {
                    //Si golpea añadir iconos como si no golpea
                    bool golpeo = false;
                    for (int i = 0; i < barcoGrande.Length; i++)
                    {
                        if (barcoGrande[i] == $"{comboBox2.SelectedItem},{comboBox1.SelectedItem}")
                        {
                            golpeo = true;
                            break;
                        }
                    }

                    for (int i = 0; i < barcoMediano.Length; i++)
                    {
                        if (barcoMediano[i] == $"{comboBox2.SelectedItem},{comboBox1.SelectedItem}")
                        {
                            golpeo = true;
                            break;
                        }
                    }

                    for (int i = 0; i < barcoPeque1.Length; i++)
                    {
                        if (barcoPeque1[i] == $"{comboBox2.SelectedItem},{comboBox1.SelectedItem}")
                        {
                            golpeo = true;
                            break;
                        }
                    }

                    for (int i = 0; i < barcoPeque2.Length; i++)
                    {
                        if (barcoPeque2[i] == $"{comboBox2.SelectedItem},{comboBox1.SelectedItem}")
                        {
                            golpeo = true;
                            break;
                        }
                    }

                    if (golpeo)
                    {
                        posicionesMostrar.Add($"{comboBox2.SelectedItem}{comboBox1.SelectedItem}" +
                                                        $" = ⨷");
                    }
                    else
                    {
                        posicionesMostrar.Add($"{comboBox2.SelectedItem}{comboBox1.SelectedItem}" +
                                                                                $" = ○");
                    }

                    posicionesAtacadas.Add($"{comboBox2.SelectedItem},{comboBox1.SelectedItem}");
                    cargarInfo();
                    comprobarGanador();
                    atacarIA();
                    comprobarGanador();
                }
            }
        }

        private void cargarInfo()
        {
            listBox1.Items.Clear();
            foreach (var item in posicionesMostrar)
            {
                listBox1.Items.Add(item.ToString());
            }
        }

        private void comprobarGanador()
        {
            if (button1.Enabled == true)
            {
                int totalAcertadosIA = 0, totalAcertadosJugador = 0;
                foreach (var item in posicionesMostrar)
                {
                    if (item.ToString().Contains("⨷"))
                    {
                        totalAcertadosJugador++;
                    }
                }

                for (int i = 0; i < posiciones.Length; i++)
                {
                    if (posiciones[i].Text.Contains("⨷"))
                    {
                        totalAcertadosIA++;
                    }
                }

                if (totalAcertadosIA == 11)
                {
                    MessageBox.Show("¡Juego acabado! Ganador: IA");
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    button1.Enabled = false;
                }
                else if (totalAcertadosJugador == 11)
                {
                    MessageBox.Show("¡Juego acabado! Ganador: Jugador");
                    comboBox1.Enabled = false;
                    comboBox2.Enabled = false;
                    button1.Enabled = false;
                }
            }
        }

        private void atacarIA()
        {
            string tiro = 
                $"{letras[randomizadorPos.Next(0, 6)]},{alturas[randomizadorPos.Next(0, 6)]}";

            for (int i = 0; i < posicionesAtacadasXIA.Count; i++)
            {
                if (posicionesAtacadasXIA[i] == tiro)
                {
                    tiro = $"{letras[randomizadorPos.Next(0, 6)]},{alturas[randomizadorPos.Next(0, 6)]}";
                    i = 0;
                }
            }

            for(int i = 0; i < posiciones.Length; i++)
            {
                if (posiciones[i].Name == tiro) 
                    if (posiciones[i].Text == "🅞") posiciones[i].Text = "⨷";
                    else posiciones[i].Text = "◎";
            }

            posicionesAtacadasXIA.Add(tiro);  
        }
    }
}