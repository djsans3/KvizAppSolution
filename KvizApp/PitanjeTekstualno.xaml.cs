using Kviz.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kviz.Wpf
{
    public partial class PitanjeTekstualno : Window
    {
        private Kviz.Core.Ispit ispit;
        private List<Pitanje> pitanja;
        private int trenutnoIndex;
        private int brojTocnih;
        private string studentUsername;

        public PitanjeTekstualno(Kviz.Core.Ispit ispit, string studentUsername)
            : this(ispit, studentUsername, 0, 0)
        {
        }

        public PitanjeTekstualno(Kviz.Core.Ispit ispit, string studentUsername, int trenutnoIndex, int brojTocnih)
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

            if (pitanje is InputPitanje inputPitanje)
            {
                txtPitanjeTekst.Text = inputPitanje.PitanjeTekst;
                txtOdgovor.Text = "";
                txtOdgovor.Focus();
            }
            else if (pitanje is SingleChoicePitanje scPitanje)
            {
                // Prebaci na PitanjeVisestruki prozor za ovo pitanje
                var visestruki = new PitanjeVisestruki(ispit, studentUsername, trenutnoIndex, brojTocnih);
                visestruki.Show();
                this.Close();
            }
        }

        private void btnNastavi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtOdgovor.Text))
            {
                MessageBox.Show("Molimo unesite odgovor!", "Upozorenje");
                return;
            }

            var pitanje = pitanja[trenutnoIndex];
            if (pitanje is InputPitanje inputPitanje)
            {
                inputPitanje.OdgovorUnesen = txtOdgovor.Text.Trim();

                bool tocan = inputPitanje.OdgovorTocan
                    .Any(o => o.Equals(txtOdgovor.Text.Trim(), StringComparison.OrdinalIgnoreCase));
                if (tocan)
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
                MessageBox.Show($"Greška pri spremanju rezultata:\n{ex.InnerException?.Message ?? ex.Message}", "Greška", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            var rezultatProzor = new Rezultat(brojTocnih, pitanja.Count, ispit.Sifra, studentUsername);
            rezultatProzor.Show();
            this.Close();
        }
    }
}
