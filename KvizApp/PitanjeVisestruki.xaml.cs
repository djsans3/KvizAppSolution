using Kviz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kviz.Wpf
{
    /// <summary>
    /// Interaction logic for PitanjeVisestruki.xaml
    /// </summary>
    public partial class PitanjeVisestruki : Window
    {
        private Kviz.Core.Ispit ispit;
        private List<Pitanje> pitanja;
        private int trenutnoIndex;
        private int brojTocnih;
        private string studentUsername;

        public PitanjeVisestruki(Kviz.Core.Ispit ispit, string studentUsername, int trenutnoIndex, int brojTocnih)
        {
            InitializeComponent();
            this.ispit = ispit;
            this.studentUsername = studentUsername;
            pitanja = ispit.SkupPitanja.ToList();
            this.trenutnoIndex = trenutnoIndex;
            this.brojTocnih = brojTocnih;
            PrikaziPitanje();
        }

        private void PrikaziPitanje()
        {
            if (trenutnoIndex >= pitanja.Count)
            {
                ZavrsiIspit();
                return;
            }

            var pitanje = pitanja[trenutnoIndex];
            txtBrojPitanja.Text = $"Pitanje {trenutnoIndex + 1}/{pitanja.Count}:";

            if (pitanje is SingleChoicePitanje scPitanje)
            {
                txtPitanjeTekst.Text = scPitanje.PitanjeTekst;
                panelOdgovori.Children.Clear();

                char oznaka = 'a';
                foreach (var odgovor in scPitanje.PonudeniOdg)
                {
                    var rb = new RadioButton
                    {
                        Content = $"{oznaka}) {odgovor}",
                        FontSize = 14,
                        Margin = new Thickness(0, 5, 0, 5),
                        GroupName = "Odgovori",
                        Tag = oznaka
                    };
                    panelOdgovori.Children.Add(rb);
                    oznaka++;
                }
            }
            else if (pitanje is InputPitanje)
            {
                // Prebaci na PitanjeTekstualno prozor
                var tekstualni = new PitanjeTekstualno(ispit, studentUsername, trenutnoIndex, brojTocnih);
                tekstualni.Show();
                this.Close();
            }
        }

        private void btnNastavi_Click(object sender, RoutedEventArgs e)
        {
            var odabrani = panelOdgovori.Children.OfType<RadioButton>()
                .FirstOrDefault(rb => rb.IsChecked == true);

            if (odabrani == null)
            {
                MessageBox.Show("Molimo odaberite odgovor!", "Upozorenje");
                return;
            }

            var pitanje = pitanja[trenutnoIndex];
            if (pitanje is SingleChoicePitanje scPitanje)
            {
                char odgovor = (char)odabrani.Tag;
                scPitanje.OdgovorUneseni = odgovor;

                if (odgovor == scPitanje.OdgovorTocan)
                    brojTocnih++;
            }

            trenutnoIndex++;
            PrikaziPitanje();
        }

        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            var result = MessageBox.Show("Jeste li sigurni da želite odustati od ispita?",
                "Odustani", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                PrikazIspita prikazIspita = new PrikazIspita();
                prikazIspita.Show();
                this.Close();
            }
        }

        private void ZavrsiIspit()
        {
            try
            {
                using (var db = new KvizDbContext())
                {
                    var rezultat = new Kviz.Core.Rezultat
                    {
                        IspitId = ispit.Sifra,
                        StudentUsername = studentUsername,
                        BrojTocnihOdgovora = brojTocnih,
                        Datum = DateTime.Now
                    };
                    db.Rezultati.Add(rezultat);
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri spremanju rezultata:\n{ex.InnerException?.Message ?? ex.Message}",
                    "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var rezultatProzor = new Rezultat(brojTocnih, pitanja.Count, ispit.Sifra, studentUsername);
            rezultatProzor.Show();
            this.Close();
        }
    }
}
