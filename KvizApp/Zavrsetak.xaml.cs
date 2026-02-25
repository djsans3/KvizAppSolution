using Kviz.Core;
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

    public partial class Zavrsetak : Window
    {
        private string profesorUsername;
        private List<Pitanje> pitanja;

        public Zavrsetak(string profesorUsername, List<Pitanje> pitanja)
        {
            InitializeComponent();
            this.profesorUsername = profesorUsername;
            this.pitanja = pitanja;
        }

        private void btnZavrsi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivIspita.Text))
            {
                MessageBox.Show("Molimo unesite naziv ispita!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var db = new KvizDbContext())
                {
                    var ispit = new Kviz.Core.Ispit
                    {
                        Naziv = txtNazivIspita.Text.Trim(),
                        ProfesorUsername = profesorUsername
                    };

                    foreach (var pitanje in pitanja)
                    {
                        ispit.SkupPitanja.Add(pitanje);
                    }

                    db.Ispiti.Add(ispit);
                    db.SaveChanges();
                }

                MessageBox.Show("Ispit je uspješno kreiran i spremljen u bazu!", "Uspjeh",
                              MessageBoxButton.OK, MessageBoxImage.Information);

                DostupniIspitiProfesor dostupniIspiti = new DostupniIspitiProfesor(profesorUsername);
                dostupniIspiti.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                var poruka = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Greška pri spremanju ispita:\n{poruka}", "Greška",
                              MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
