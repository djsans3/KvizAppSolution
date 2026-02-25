using Kviz.Core;
using Microsoft.EntityFrameworkCore;
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

namespace Kviz.Wpf
{
    /// <summary>
    /// Interaction logic for DostupniIspitiProfesor.xaml
    /// </summary>
    public partial class DostupniIspitiProfesor : Window
    {
        private ObservableCollection<Kviz.Core.Ispit> ispiti;
        private string profesorUsername;

        public DostupniIspitiProfesor(string profesorUsername = "profesor")
        {
            InitializeComponent();
            this.profesorUsername = profesorUsername;
            UcitajIspite();
        }

        private void UcitajIspite()
        {
            using (var db = new KvizDbContext())
            {
                var ispitiIzBaze = db.Ispiti
                    .Include(i => i.SkupPitanja)
                    .Where(i => i.ProfesorUsername == profesorUsername)
                    .ToList();
                ispiti = new ObservableCollection<Kviz.Core.Ispit>(ispitiIzBaze);
            }
            dgIspiti.ItemsSource = ispiti;
        }

        private void btnUredi_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Kviz.Core.Ispit ispit)
            {
                MessageBox.Show($"Uređivanje ispita: {ispit.Naziv}", "Info");
                DodajPitanjeTekstualno urediIspit = new DodajPitanjeTekstualno(profesorUsername);
                urediIspit.Show();
                this.Close();
            }
        }

        private void btnObrisi_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Kviz.Core.Ispit ispit)
            {
                var rezultat = MessageBox.Show(
                    $"Jeste li sigurni da želite obrisati ispit '{ispit.Naziv}'?",
                    "Potvrda brisanja",
                    MessageBoxButton.YesNo,
                    MessageBoxImage.Question);

                if (rezultat == MessageBoxResult.Yes)
                {
                    using (var db = new KvizDbContext())
                    {
                        db.Ispiti.Remove(ispit);
                        db.SaveChanges();
                    }
                    ispiti.Remove(ispit);
                    MessageBox.Show("Ispit je uspješno obrisan!", "Uspjeh");
                }
            }
        }

        private void btnDodajIspit_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeTekstualno dodajIspit = new DodajPitanjeTekstualno(profesorUsername);
            dodajIspit.Show();
            this.Close();
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void dgIspiti_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
