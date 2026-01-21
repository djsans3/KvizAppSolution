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
    /// Interaction logic for Zavrsetak.xaml
    /// </summary>
    public partial class Zavrsetak : Window
    {
        public Zavrsetak()
        {
            InitializeComponent();
        }
        private void btnZavrsi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivIspita.Text) ||
                string.IsNullOrWhiteSpace(txtBrojBodova.Text))
            {
                MessageBox.Show("Molimo unesite naziv ispita i broj bodova!",
                              "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Ispit je uspješno kreiran!", "Uspjeh",
                          MessageBoxButton.OK, MessageBoxImage.Information);

            DostupniIspitiProfesor dostupniIspiti = new DostupniIspitiProfesor();
            dostupniIspiti.Show();
            this.Close();
        }
    }
}
