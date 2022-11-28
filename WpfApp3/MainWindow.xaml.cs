using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            int ara = Convert.ToInt32(arabskaText.Text);
            String znak = "";
            while (ara != 0)
            {
                if (ara >= 1000)
                {
                    ara -=1000;
                    znak += "M";
                }
                else if(ara >= 500)
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
            
            for (int i = 0; i < witam2.Length; i++)
            {
                znak = znak.Replace(witam1[i], witam2[i]);
            }
            
            MessageBox.Show(znak);
        }
        private string witam(string ciagdozamienienia,string co_zamienic)
        {
            int indexGdzie = ciagdozamienienia.IndexOf(co_zamienic);
            if (indexGdzie!= -1)
            {
                string doZwrocenia = "";
                char[] costam = ciagdozamienienia.ToCharArray();
                for (int i = indexGdzie; i < co_zamienic.Length; i++)
                {
                    costam[i] = '1';
                }
                foreach (char el in costam)
                {
                    if (Convert.ToString(el) != "1") doZwrocenia += Convert.ToString(el);
                }
                return doZwrocenia;
            }
            else { return ciagdozamienienia; }
        }
        private void romToAra_Click(object sender, RoutedEventArgs e)
        {
            string rom = rzymskaText.Text;
            int suma = 0;
            String[] romZnaki = {"IX","IV","XC","XL","CM","CD","M","D","C","L","X","V","I"};
            //zamiana na arabskie WIP

            while(rom !="")
            {
                for (int i = 0; i < romZnaki.Length; i++)
                {
                    if (rom.IndexOf(romZnaki[i]) != -1)
                    {
                        switch (romZnaki[i])
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
                        rom = witam(rom, romZnaki[i]);
                    }
                }
            }
            MessageBox.Show(Convert.ToString(suma));
        }
    }
}