using Kviz.Wpf;
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

namespace KvizApp
{
    /// <summary>
    /// Interaction logic for NeuspjelaPrijava.xaml
    /// </summary>
    public partial class NeuspjelaPrijava : Window
    {
        public NeuspjelaPrijava()
        {
            InitializeComponent();
        }

        private void btnPrijava2_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = txtKorisnickoIme2.Text;
            string lozinka = txtLozinka2.Password;

            if (!string.IsNullOrWhiteSpace(korisnickoIme) &&
                !string.IsNullOrWhiteSpace(lozinka))
            {
                if (lozinka == "12345678")
                {
                    // Otvori sučelje za uspješnu prijavu
                    UspjesnaPrijava uspjesnaPrijava = new UspjesnaPrijava();
                    uspjesnaPrijava.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neispravna lozinka!", "Greška",
                                  MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Molimo unesite korisničko ime i lozinku!",
                              "Greška", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}

