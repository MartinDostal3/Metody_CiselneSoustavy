using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Metody_CiselneSoustavy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private int BinToDEC(string binCislo)
        {
          
               
              
       


            int mocnina = 1; //  mocnina 2 na 0
            int d = binCislo.Length;
            int decCislo = 0;

            for (int i = d - 1; i >= 0; i--)
            {
                if (binCislo[i] == '1')
                {
                    decCislo += mocnina;
                }
                mocnina *= 2;
            }

            return decCislo;
        }

        private string DecToBin(int decCislo)
        {
            string binCislo = string.Empty;

            
            while (decCislo > 0)
            {
                int zbytek = decCislo % 2;
                decCislo /= 2;
                binCislo = zbytek + binCislo;
            }


            return binCislo;


           
        }
        private int HexToDec(string hexCislo)
        {
           
            int d = hexCislo.Length;
            int decCislo = 0;
            int zaklad = 1;

            for (int i = d - 1; i >= 0; i--)
            {
                if (hexCislo[i] >= '0' && hexCislo[i] <= '9')
                {
                    decCislo += (hexCislo[i] - 48) * zaklad;
                    zaklad = zaklad * 16;
                }
                else if (hexCislo[i] >= 'A' && hexCislo[i] <= 'F')
                {
                    decCislo += (hexCislo[i] - 55) * zaklad;
                    zaklad = zaklad * 16;
                }
            }



            return decCislo;
        }

        private string DecToHex(int decCislo)
        {
            string hex = "";
            int zbytek = 0;
            while (decCislo > 0)
            {
                zbytek = decCislo % 16;
                if (zbytek >= 0 && zbytek <= 9)
                {
                    hex = hex.Insert(0, zbytek.ToString());
                }
                else
                {
                    char znakCifry = (char)('A' + zbytek - 10);
                    hex = hex.Insert(0, znakCifry.ToString());

                }

                decCislo /= 16;
            }
            return hex;
        }

        private string BinToHex(string binCislo)
        {
            int delka = binCislo.Length;
            string hexCislo = "";

            while (delka % 4 != 0)
            {
                binCislo = binCislo.Insert(0, "0");
                delka++;
            }

           
            while (delka > 0)
            {
                string substring = binCislo.Substring(binCislo.Length - 4, 4);
                binCislo = binCislo.Remove(binCislo.Length - 4, 4);
                delka -= 4;

                switch (substring)
                {
                    case "0000": hexCislo = hexCislo.Insert(0, "0"); break;
                    case "0001": hexCislo = hexCislo.Insert(0, "1"); break;
                    case "0010": hexCislo = hexCislo.Insert(0, "2"); break;
                    case "0011": hexCislo = hexCislo.Insert(0, "3"); break;
                    case "0100": hexCislo = hexCislo.Insert(0, "4"); break;
                    case "0101": hexCislo = hexCislo.Insert(0, "5"); break;
                    case "0110": hexCislo = hexCislo.Insert(0, "6"); break;
                    case "0111": hexCislo = hexCislo.Insert(0, "7"); break;
                    case "1000": hexCislo = hexCislo.Insert(0, "8"); break;
                    case "1001": hexCislo = hexCislo.Insert(0, "9"); break;
                    case "1010": hexCislo = hexCislo.Insert(0, "A"); break;
                    case "1011": hexCislo = hexCislo.Insert(0, "B"); break;
                    case "1100": hexCislo = hexCislo.Insert(0, "C"); break;
                    case "1101": hexCislo = hexCislo.Insert(0, "D"); break;
                    case "1110": hexCislo = hexCislo.Insert(0, "E"); break;
                    case "1111": hexCislo = hexCislo.Insert(0, "F"); break;
                    default:
                        return "Spatne cislo";
                }
            }

            return hexCislo.ToString();
        }

        private string HexToBin(string hexCislo)
        {
            string bin = string.Empty;
            int delka = hexCislo.Length - 1;
            for (int i = 0; i <= delka; i++)
            {
                switch (hexCislo
                    
                    [i])
                {
                    case '0':
                        bin = bin.Insert(bin.Length, "0000");
                        break;
                    case '1':
                        bin = bin.Insert(bin.Length, "0001");
                        break;
                    case '2':
                        bin = bin.Insert(bin.Length, "0010");
                        break;
                    case '3':
                        bin = bin.Insert(bin.Length, "0011");
                        break;
                    case '4':
                        bin = bin.Insert(bin.Length, "0100");
                        break;
                    case '5':
                        bin = bin.Insert(bin.Length, "0101");
                        break;
                    case '6':
                        bin = bin.Insert(bin.Length, "0110");
                        break;
                    case '7':
                        bin = bin.Insert(bin.Length, "0111");
                        break;
                    case '8':
                        bin = bin.Insert(bin.Length, "1000");
                        break;
                    case '9':
                        bin = bin.Insert(bin.Length, "1001");
                        break;
                    case 'A':
                    case 'a':
                        bin = bin.Insert(bin.Length, "1010");
                        break;
                    case 'B':
                    case 'b':
                        bin = bin.Insert(bin.Length, "1011");
                        break;
                    case 'C':
                    case 'c':
                        bin = bin.Insert(bin.Length, "1100");
                        break;
                    case 'D':
                    case 'd':
                        bin = bin.Insert(bin.Length, "1101");
                        break;
                    case 'E':
                    case 'e':
                        bin = bin.Insert(bin.Length, "1110");
                        break;
                    case 'F':
                    case 'f':
                        bin = bin.Insert(bin.Length, "1111");
                        break;
                    default:
                        return "\nŠpatné hexadecimální číslo";
                }

            }
            return bin;
        }
  

        private void button1_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            label1.Text = BinToDEC(s).ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            label1.Text = DecToBin(x);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String s = textBox1.Text;
            label1.Text = HexToDec(s).ToString();
        }
    

        private void button4_Click(object sender, EventArgs e)
        {
            int x = int.Parse(textBox1.Text);
            label1.Text = DecToHex(x);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            label1.Text = BinToHex(s);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string s = textBox1.Text;
            label1.Text = HexToBin(s);
        }
    }
}
