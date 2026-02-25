using Kviz.Core;
using KvizApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kviz.Wpf
{
    public partial class Rezultat : Window
    {
        private int ostvareniBodovi;
        private int maksimalniBodovi;
        private double postotak;
        private string ocjena;
        private int pozicijaRangListe;

        public Rezultat(int ostvareni, int maksimalni, int ispitId, string studentUsername)
        {
            InitializeComponent();

            ostvareniBodovi = ostvareni;
            maksimalniBodovi = maksimalni;

            postotak = maksimalniBodovi > 0
                ? ((double)ostvareniBodovi / maksimalniBodovi) * 100
                : 0;

            ocjena = OdrediOcjenu(postotak);

            // Izračunaj rang poziciju iz baze
            pozicijaRangListe = IzracunajRang(ispitId, ostvareni);

            txtBodovi.Text = $"{ostvareniBodovi}/{maksimalniBodovi}";
            txtPostotak.Text = $"{postotak:F1}%";
            txtOcjena.Text = ocjena;
            txtRangLista.Text = $"#{pozicijaRangListe}";
        }

        private int IzracunajRang(int ispitId, int bodovi)
        {
            try
            {
                using (var db = new KvizDbContext())
                {
                    var boljiRezultati = db.Rezultati
                        .Where(r => r.IspitId == ispitId && r.BrojTocnihOdgovora > bodovi)
                        .Count();
                    return boljiRezultati + 1;
                }
            }
            catch
            {
                return 0;
            }
        }

        private string OdrediOcjenu(double postotak)
        {
            if (postotak >= 90)
                return "Izvrstan (5)";
            else if (postotak >= 75)
                return "Vrlo dobar (4)";
            else if (postotak >= 60)
                return "Dobar (3)";
            else if (postotak >= 50)
                return "Dovoljan (2)";
            else
                return "Nedovoljan (1)";
        }

        private void btnPovratak_Click(object sender, RoutedEventArgs e)
        {
            PrikazIspita prikazIspita = new PrikazIspita();
            prikazIspita.Show();
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

