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
using System.Windows.Shapes;

namespace Kviz.Wpf
{
    /// <summary>
    /// Interaction logic for DodajPitanjeVisestruki.xaml
    /// </summary>
    public partial class DodajPitanjeVisestruki : Window
    {
        private int brojPitanja = 1;

        public DodajPitanjeVisestruki()
        {
            InitializeComponent();
        }
        private void btnDodajOdgovor_Click(object sender, RoutedEventArgs e)
        {
            StackPanel noviOdgovor = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 0)
            };

            RadioButton rb = new RadioButton
            {
                GroupName = "TocanOdgovor",
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBox txt = new TextBox
            {
                Width = 500,
                Height = 30,
                Padding = new Thickness(5)
            };

            noviOdgovor.Children.Add(rb);
            noviOdgovor.Children.Add(txt);
            panelOdgovori.Children.Add(noviOdgovor);
        }

        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            if (brojPitanja > 1)
            {
                brojPitanja--;
                txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
            }
        }

        private void btnDodajVisestruki_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPitanje.Text))
            {
                MessageBox.Show("Molimo unesite pitanje!", "Upozorenje");
                return;
            }

            brojPitanja++;
            txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
            txtPitanje.Clear();
            MessageBox.Show("Pitanje dodano!", "Uspjeh");
        }

        private void btnDodajTekstualno_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeTekstualno tekstualno = new DodajPitanjeTekstualno();
            tekstualno.Show();
            this.Close();
        }

        private void btnZavrsi_Click(object sender, RoutedEventArgs e)
        {
            Zavrsetak zavrsetak = new Zavrsetak();
            zavrsetak.Show();
            this.Close();
        }
    }
}
