using Kviz.Wpf;
using System.Text;
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

            if (!string.IsNullOrWhiteSpace(korisnickoIme) &&
                !string.IsNullOrWhiteSpace(lozinka))
            {
                if (korisnickoIme == "profesor" && lozinka == "87654321")
                {
                    UspjesnaPrijavaProfesor uspjesnaPrijava = new UspjesnaPrijavaProfesor();
                    uspjesnaPrijava.Show();
                    this.Close();
                }
                else if (korisnickoIme=="student"&& lozinka == "1234")
                {
                    PrikazIspita uspjesnaPrijava=new PrikazIspita();
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
                    NeuspjelaPrijava neuspjelaPrijava = new NeuspjelaPrijava();
                    neuspjelaPrijava.Show();
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