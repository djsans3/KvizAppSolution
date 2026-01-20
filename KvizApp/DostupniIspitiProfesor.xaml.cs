using KvizApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
using System.Collections.ObjectModel;

namespace Kviz.Wpf
{
    /// <summary>
    /// Interaction logic for DostupniIspitiProfesor.xaml
    /// </summary>
    public partial class DostupniIspitiProfesor : Window
    {
        private ObservableCollection<Ispit> ispiti;
        public DostupniIspitiProfesor()
        {
            InitializeComponent();
            UcitajIspite();
        }

        private void UcitajIspite()
        {
            ispiti = new ObservableCollection<Ispit>
            {
                new Ispit { RedniBroj = 1, NazivIspita = "Matematika - Algebra", BrojPitanja = 20, Bodovi = 100 },
                new Ispit { RedniBroj = 2, NazivIspita = "Programiranje u C#", BrojPitanja = 15, Bodovi = 75 },
                new Ispit { RedniBroj = 3, NazivIspita = "Baze podataka", BrojPitanja = 25, Bodovi = 120 },
                new Ispit { RedniBroj = 4, NazivIspita = "Računalne mreže", BrojPitanja = 18, Bodovi = 90 },
                new Ispit { RedniBroj = 5, NazivIspita = "Web dizajn", BrojPitanja = 12, Bodovi = 60 }
            };

            dgIspiti.ItemsSource = ispiti;
        }

        private void btnUredi_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Ispit ispit)
            {
                MessageBox.Show($"Uređivanje ispita: {ispit.NazivIspita}", "Info");
                DodajPitanjeTekstualno urediIspit = new DodajPitanjeTekstualno();
                urediIspit.Show();
                this.Close();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Ispit ispit)
            {
                var rezultat = MessageBox.Show(
                    $"Jeste li sigurni da želite obrisati ispit '{ispit.NazivIspita}'?",
                    "Potvrda brisanja",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    ispiti.Remove(ispit);
                    MessageBox.Show("Ispit je uspješno obrisan!", "Uspjeh");
                }
            }
        }

        private void btnDodajIspit_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeTekstualno dodajIspit = new DodajPitanjeTekstualno();
            dodajIspit.Show();
            this.Close();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }
}
