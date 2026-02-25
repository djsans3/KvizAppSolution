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

    public partial class DodajPitanjeTekstualno : Window
    {
        private int brojPitanja = 1;
        private List<Pitanje> pitanja;
        private string profesorUsername;

        public DodajPitanjeTekstualno(string profesorUsername, List<Pitanje>? postojecaPitanja = null)
        {
            InitializeComponent();
            this.profesorUsername = profesorUsername;
            pitanja = postojecaPitanja ?? new List<Pitanje>();
            brojPitanja = pitanja.Count + 1;
            txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
        }

        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            UspjesnaPrijavaProfesor uspjesnaPrijava = new UspjesnaPrijavaProfesor(profesorUsername);
            uspjesnaPrijava.Show();
            this.Close();
        }

        private void btnDodajTekstualno_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPitanje.Text) ||
                string.IsNullOrWhiteSpace(txtOdgovor.Text))
            {
                MessageBox.Show("Molimo unesite pitanje i odgovor!", "Upozorenje");
                return;
            }

            var novoPitanje = new InputPitanje
            {
                PitanjeTekst = txtPitanje.Text.Trim(),
                OdgovorTocan = new[] { txtOdgovor.Text.Trim() }
            };

            pitanja.Add(novoPitanje);
            brojPitanja++;
            txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
            txtPitanje.Clear();
            txtOdgovor.Clear();
            MessageBox.Show("Pitanje dodano!", "Uspjeh");
        }

        private void btnDodajVisestruki_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeVisestruki visestruki = new DodajPitanjeVisestruki(profesorUsername, pitanja);
            visestruki.Show();
            this.Close();
        }

        private void btnZavrsi_Click(object sender, RoutedEventArgs e)
        {
            if (pitanja.Count == 0)
            {
                MessageBox.Show("Morate dodati barem jedno pitanje!", "Upozorenje");
                return;
            }

            Zavrsetak zavrsetak = new Zavrsetak(profesorUsername, pitanja);
            zavrsetak.Show();
            this.Close();
        }
    }
}
