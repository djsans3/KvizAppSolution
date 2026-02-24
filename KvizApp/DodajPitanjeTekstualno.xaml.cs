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
    /// Interaction logic for DodajPitanjeTekstualno.xaml
    /// </summary>
    public partial class DodajPitanjeTekstualno : Window
    {
        private int brojPitanja = 1;
        public DodajPitanjeTekstualno()
        {
            InitializeComponent();
        }
        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            if (brojPitanja > 1)
            {
                brojPitanja--;
                txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
                txtPitanje.Clear();
                txtOdgovor.Clear();
            }
        }

        private void btnDodajTekstualno_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPitanje.Text) ||
                string.IsNullOrWhiteSpace(txtOdgovor.Text))
            {
                MessageBox.Show("Molimo unesite pitanje i odgovor!", "Upozorenje");
                return;
            }

            brojPitanja++;
            txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
            txtPitanje.Clear();
            txtOdgovor.Clear();
            MessageBox.Show("Pitanje dodano!", "Uspjeh");
        }

        private void btnDodajVisestruki_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeVisestruki visestruki = new DodajPitanjeVisestruki();
            visestruki.Show();
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
