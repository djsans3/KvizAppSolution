using Kviz.Core;
using KvizApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace Kviz.Wpf
{
    public partial class RangLista : Window
    {
        private int ispitId;

        public RangLista(int ispitId, string nazivIspita)
        {
            InitializeComponent();

            this.ispitId = ispitId;
            txtNaslov.Text = $"Rang lista - {nazivIspita}";

            UcitajRangListu();
        }

        private void UcitajRangListu()
        {
            try
            {
                using (var db = new KvizDbContext())
                {
                    var rezultati = db.Rezultati
                        .Where(r => r.IspitId == ispitId)
                        .OrderByDescending(r => r.BrojTocnihOdgovora)
                        .ThenBy(r => r.Datum)
                        .ToList();

                    if (rezultati.Count == 0)
                    {
                        dgRangLista.Visibility = Visibility.Collapsed;
                        txtNemaRezultata.Visibility = Visibility.Visible;
                        return;
                    }

                    var rangLista = new List<RangListaStavka>();
                    for (int i = 0; i < rezultati.Count; i++)
                    {
                        rangLista.Add(new RangListaStavka
                        {
                            Pozicija = i + 1,
                            StudentUsername = rezultati[i].StudentUsername,
                            BrojTocnihOdgovora = rezultati[i].BrojTocnihOdgovora,
                            Datum = rezultati[i].Datum
                        });
                    }

                    dgRangLista.ItemsSource = rangLista;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greška pri u?itavanju rang liste: {ex.Message}", "Greška");
            }
        }

        private void btnPovratak_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }

    public class RangListaStavka
    {
        public int Pozicija { get; set; }
        public string StudentUsername { get; set; } = "";
        public int BrojTocnihOdgovora { get; set; }
        public DateTime Datum { get; set; }
    }
}
