using Kviz.Core;
using Microsoft.EntityFrameworkCore;
using KvizApp;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

    public partial class PrikazIspita : Window
    {
        public PrikazIspita()
        {
            InitializeComponent();
            UcitajIspite();
        }

        private void UcitajIspite()
        {
            using (var db = new KvizDbContext())
            {
                var ispitiIzBaze = db.Ispiti
                    .Include(i => i.SkupPitanja)
                    .ToList();
                var ispiti = new ObservableCollection<Kviz.Core.Ispit>(ispitiIzBaze);
                dgIspiti.ItemsSource = ispiti;
            }
        }

        private void btnIspitajSe_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Kviz.Core.Ispit ispit)
            {
                if (ispit.SkupPitanja == null || ispit.SkupPitanja.Count == 0)
                {
                    MessageBox.Show("Ovaj ispit nema pitanja!", "Upozorenje");
                    return;
                }

                // Započni ispit s prvim pitanjem
                var prvoPitanje = ispit.SkupPitanja.First();
                if (prvoPitanje is SingleChoicePitanje)
                {
                    var prozor = new PitanjeVisestruki(ispit, "student", 0, 0);
                    prozor.Show();
                    this.Close();
                }
                else
                {
                    var prozor = new PitanjeTekstualno(ispit, "student");
                    prozor.Show();
                    this.Close();
                }
            }
        }

        private void btnRangLista_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Kviz.Core.Ispit ispit)
            {
                var rangLista = new RangLista(ispit.Sifra, ispit.Naziv);
                rangLista.Show();
            }
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
