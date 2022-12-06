using System;
using System.Windows;

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void araToRom_Click(object sender, RoutedEventArgs e)
        {
            try { 
                int ara = Convert.ToInt32(arabskaText.Text);
                String znak = "";
                while (ara != 0)
                {
                    if (ara >= 1000)
                    {
                        ara -= 1000;
                        znak += "M";
                    }
                    else if (ara >= 500)
                    {
                        ara -= 500;
                        znak += "D";
                    }
                    else if (ara >= 100)
                    {
                        ara -= 100;
                        znak += "C";
                    }
                    else if (ara >= 50)
                    {
                        ara -= 50;
                        znak += "L";
                    }
                    else if (ara >=10)
                    {
                        ara-=10;
                        znak += "X";
                    }
                    else if (ara >= 5)
                    {
                        ara -= 5;
                        znak += "V";
                    }
                    else
                    {
                        ara -= 1;
                        znak += "I";
                    }

                }
                String[] witam1 = { "VIIII", "IIII", "LXXXX", "XXXX", "DCCCC", "CCCC" };
                String[] witam2 = { "IX", "IV", "XC", "XL", "CM", "CD" };

                for (int i = 0; i < witam2.Length; i++)//zamienianie bledow na prawidlowe wartosci
                {
                    znak = znak.Replace(witam1[i], witam2[i]);
                }

                rzymskaText.Text = znak;
            } catch (FormatException)//debilo odporne zabespieczenie
            {
                MessageBox.Show("niepoprawna wartosc", "debil");
            }            
            
        }
        private string witam(string ciagdozamienienia, string co_zamienic) //profesjonalne usuwanie znaków
        {
            int indexGdzie = ciagdozamienienia.IndexOf(co_zamienic);
            if (indexGdzie!= -1)
            {
                string doZwrocenia = "";
                char[] costam = ciagdozamienienia.ToCharArray();
                for (int i = indexGdzie; i < indexGdzie+co_zamienic.Length; i++)
                {
                    costam[i] = '1';//przykladowa wartosc ktora nie bedzie w tej tablicy
                }
                foreach (char el in costam)
                {
                    if (Convert.ToString(el) != "1") doZwrocenia += Convert.ToString(el); //pomijanie "1" i dodawanie reszty do stringa
                }
                return doZwrocenia;
            }
            else return ciagdozamienienia;
        }
        private void romToAra_Click(object sender, RoutedEventArgs e)
        {
            string rom = rzymskaText.Text;
            int suma = 0;
            String[] romZnaki = { "IX", "IV", "XC", "XL", "CM", "CD", "M", "D", "C", "L", "X", "V", "I" }; // wszystkie mozliwe znaki rzymskie z ktorych mozna zrobic liczby
            bool jestCos = false;
            foreach(string znaki in romZnaki)
            {
                if (rom.IndexOf(znaki) != -1) jestCos = true;

            }
            if(!jestCos) MessageBox.Show("niepoprawna wartosc", "debil"); 
            while (rom !="" && jestCos)
            {
                for (int i = 0; i < romZnaki.Length; i++)
                {
                    if (rom.IndexOf(romZnaki[i]) != -1)
                    {
                        switch (romZnaki[i]) //szukanie co dodac
                        {
                            case "IX":
                                suma+=9;
                                break;
                            case "IV":
                                suma+=4;
                                break;
                            case "XC":
                                suma+=90;
                                break;
                            case "XL":
                                suma+=40;
                                break;
                            case "CM":
                                suma+=900;
                                break;
                            case "CD":
                                suma+=400;
                                break;
                            case "M":
                                suma+=1000;
                                break;
                            case "D":
                                suma+=500;
                                break;
                            case "C":
                                suma+=100;
                                break;
                            case "L":
                                suma+=50;
                                break;
                            case "X":
                                suma+=10;
                                break;
                            case "V":
                                suma+=5;
                                break;
                            case "I":
                                suma+=1;
                                break;
                        }
                        rom = witam(rom, romZnaki[i]);//usuwanie wartosci z "rom"
                    }
                }
            }
            arabskaText.Text = Convert.ToString(suma);
        }
    }
}