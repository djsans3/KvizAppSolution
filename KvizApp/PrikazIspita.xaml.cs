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
    /// <summary>
    /// Interaction logic for PrikazIspita.xaml
    /// </summary>
    public partial class PrikazIspita : Window
    {
        public PrikazIspita()
        {
            InitializeComponent();
            UcitajIspite();
        }
        private void UcitajIspite()
        {
            var ispiti = new ObservableCollection<Ispit>
            {
                new Ispit { RedniBroj = 1, NazivIspita = "Matematika - Algebra", BrojPitanja = 20, Bodovi = 100, TipPitanja = TipPitanja.Tekstualni },
                new Ispit { RedniBroj = 2, NazivIspita = "Programiranje u C#", BrojPitanja = 15, Bodovi = 75, TipPitanja = TipPitanja.VisestrukiOdabir },
                new Ispit { RedniBroj = 3, NazivIspita = "Baze podataka", BrojPitanja = 25, Bodovi = 120, TipPitanja = TipPitanja.Tekstualni },
                new Ispit { RedniBroj = 4, NazivIspita = "Računalne mreže", BrojPitanja = 18, Bodovi = 90, TipPitanja = TipPitanja.VisestrukiOdabir },
                new Ispit { RedniBroj = 5, NazivIspita = "Web dizajn", BrojPitanja = 12, Bodovi = 60, TipPitanja = TipPitanja.Tekstualni }
            };

            dgIspiti.ItemsSource = ispiti;
        }
        private void btnIspitajSe_Click(object sender, RoutedEventArgs e)
        {
            if (sender is System.Windows.Controls.Button btn && btn.Tag is Ispit ispit)
            {
                // Otvori odgovarajući prozor ovisno o tipu pitanja
                if (ispit.TipPitanja == TipPitanja.Tekstualni)
                {
                    PitanjeTekstualno pitanje = new PitanjeTekstualno();
                    pitanje.ShowDialog();
                }
                else
                {
                    PitanjeVisestruki pitanje = new PitanjeVisestruki();
                    pitanje.ShowDialog();
                }
            }
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }
    }

    public enum TipPitanja
    {
        Tekstualni,
        VisestrukiOdabir
    }

    public class Ispit
    {
        public int RedniBroj { get; set; }
        public string NazivIspita { get; set; }
        public int BrojPitanja { get; set; }
        public int Bodovi { get; set; }
        public TipPitanja TipPitanja { get; set; }
    }
}
