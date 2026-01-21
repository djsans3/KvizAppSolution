using KvizApp;
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
    /// <summary>
    /// Interaction logic for Rezultat.xaml
    /// </summary>
    public partial class Rezultat : Window
    {
        private int ostvareniBodovi;
        private int maksimalniBodovi;
        private double postotak;
        private string ocjena;
        private int pozicijaRangListe;

        public Rezultat()
        {
            InitializeComponent();
            IzracunajRezultat(85, 100, 12);
        }

        public Rezultat(int ostvareni, int maksimalni, int rangLista)
        {
            InitializeComponent();
            IzracunajRezultat(ostvareni, maksimalni, rangLista);
        }

        private void IzracunajRezultat(int ostvareni, int maksimalni, int rang)
        {
            ostvareniBodovi = ostvareni;
            maksimalniBodovi = maksimalni;
            pozicijaRangListe = rang;
            
            postotak = ((double)ostvareniBodovi / maksimalniBodovi) * 100;

            ocjena = OdrediOcjenu(postotak);

            txtBodovi.Text = $"{ostvareniBodovi}/{maksimalniBodovi}";
            txtPostotak.Text = $"{postotak:F2}%";
            txtOcjena.Text = ocjena;
            txtRangLista.Text = pozicijaRangListe.ToString();
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
            PrikazIspita dostupniIspiti = new PrikazIspita();
            dostupniIspiti.Show();
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

