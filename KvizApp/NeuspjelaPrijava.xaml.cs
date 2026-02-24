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
                if (korisnickoIme == "profesor" && lozinka == "87654321")
                {
                    UspjesnaPrijavaProfesor uspjesnaPrijava = new UspjesnaPrijavaProfesor();
                    uspjesnaPrijava.Show();
                    this.Close();
                }
                else if (korisnickoIme == "student" && lozinka == "1234")
                {
                    PrikazIspita uspjesnaPrijava = new PrikazIspita();
                    uspjesnaPrijava.Show();
                    this.Close();
                }
                else if (korisnickoIme == "student" && lozinka == "12345678")
                {
                    UspjesnaPrijava uspjesnaPrijava = new UspjesnaPrijava();
                    uspjesnaPrijava.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Neispravni podatci", "Greška",
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

