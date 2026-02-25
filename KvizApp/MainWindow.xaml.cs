using Kviz.Core;
using Kviz.Wpf;
using System.Windows;

namespace KvizApp
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

        private void btnPrijava_Click(object sender, RoutedEventArgs e)
        {
            string korisnickoIme = txtKorisnickoIme.Text;
            string lozinka = txtLozinka.Password;

            if (!string.IsNullOrWhiteSpace(korisnickoIme) && !string.IsNullOrWhiteSpace(lozinka))
            {
                // Koristi factory metodu iz Korisnik klase
                Korisnik korisnik = Korisnik.ProvjeriKorisnika(korisnickoIme, lozinka);

                if (korisnik != null)
                {
                    TipKorisnika tip = korisnik.Prijava();

                    if (tip == TipKorisnika.Profesor)
                    {
                        UspjesnaPrijavaProfesor prozor = new UspjesnaPrijavaProfesor(korisnik.Username);
                        prozor.Show();
                        this.Close();
                    }
                    else if (tip == TipKorisnika.Student)
                    {
                       PrikazIspita prozor = new PrikazIspita();
                        prozor.Show();
                        this.Close();
                    }
                }
                else
                {
                    NeuspjelaPrijava prozor = new NeuspjelaPrijava();
                    prozor.Show();
                    this.Close();
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