using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        int dlugosc = 0;
        
        StringBuilder MyStringBuilder = new StringBuilder();
        StringBuilder temp = new StringBuilder();
        StringBuilder odbiornik = new StringBuilder();
        StringBuilder odwroc = new StringBuilder();
        StringBuilder nowy = new StringBuilder();
        


        public void button1_Click(object sender, EventArgs e)
        {
            zamiana();
            
        }

        public void button2_Click(object sender, EventArgs e)
        {
  
            textBox3.Text =nowy.ToString();
            nowy.Clear();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            nowy.Clear();
            temp.Clear();
            MyStringBuilder.Clear();

        }

        public void zamiana()
        {
            string a = "";
            a = textBox1.Text;
            StringBuilder MyStringBuilder = new StringBuilder(a);
            dlugosc = MyStringBuilder.Length;

            string[] Tab = new string[dlugosc];
            int i = 0;
            
            MyStringBuilder.Clear();
            foreach (char B in a)
            {
                MyStringBuilder.Append(Convert.ToString((B), 2));
                int ilerazy1 = 0;
                char z = '1';
                int parzystosc = 0;
                for (int l = 0; l < MyStringBuilder.Length; l++)

                    
                {
                    if (MyStringBuilder[l] == z) { 
                    ilerazy1++;
                    }
                    //odwracam rs232
                    temp.Insert(0, MyStringBuilder[l]);
                    
                }
                
                if (parzystosc == ilerazy1 % 2)
                {
                    temp.Append("0");
                }
                else
                {
                    temp.Append("1");
                }

                
                temp.Append("11");
                temp.Insert(0, "0");
                Tab[i] = temp.ToString();
                temp.Clear();
                MyStringBuilder.Clear();
                textBox2.Text = textBox2.Text + " " + Tab[i];
                i++;
                
            }

               

            int ilerazy2= 0;
            char p = '1';
            int parzystosc2= 0;

            for (int s = 0; s < dlugosc; s++)
            {
                //Dodaje do Stringbuildera tablice "znaków" np Tab[0] = 01010101 co symbolizuje np. litere a, potem Tab[1]=01010111 co symbolizuje b
                odbiornik.Append(Tab[s]);
                odbiornik.Remove(0, 1);
                int m = odbiornik.Length;
                string szukam_parzystej = odbiornik[m - 3].ToString();
                odbiornik.Remove((m - 3), 3); // usuwam łacznie z bitem parzystościa
                int d = odbiornik.Length;
               
                    for (int j = 0; j < d; j++)
                    {
                        if (odbiornik[j] == p)
                        {
                            ilerazy2++;
                        }
                    }
                
                parzystosc2 = ilerazy2 % 2; 
                ilerazy2 = 0;
                if (szukam_parzystej == parzystosc2.ToString())
                {
                    for (int k = 0; k < odbiornik.Length; k++)
                    {

                        odwroc.Insert(0, odbiornik[k]);
                    }



                    string temp2 = odwroc.ToString();
                    int znak = Convert.ToInt32(temp2, 2);
                    nowy.Append((char)znak);
                    odwroc.Clear();
                    odbiornik.Clear();

                }

                else
                {

                    label4.Text = "Błąd, nieprawidłowy ciag znaków";
                }

                }



            string sciezka = @"C:\Users\Katherine\source\repos\WindowsFormsApp6\WindowsFormsApp6\bin\Debug\slownik_grubianstw.txt";
            string[] readText = File.ReadAllLines(sciezka);
           
           
            for (int g = 0; g < readText.Length; g++)
            {
                string grubianstwo = readText[g];

                foreach (char r in grubianstwo)
                {
                    char h = '*';
                    grubianstwo = grubianstwo.Replace(r, h);

                }
                nowy.Replace(readText[g], grubianstwo);

            }

        }

    }
}

    
