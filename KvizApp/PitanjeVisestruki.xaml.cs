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
    /// Interaction logic for PitanjeVisestruki.xaml
    /// </summary>
    public partial class PitanjeVisestruki : Window
    {
        public PitanjeVisestruki()
        {
            InitializeComponent();
        }
        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Povratak na prethodno pitanje", "Info");
            // Ovdje dodaj logiku za prethodno pitanje
        }

        private void btnNastavi_Click(object sender, RoutedEventArgs e)
        {
            if (!rbOdgovor1.IsChecked.GetValueOrDefault() &&
                !rbOdgovor2.IsChecked.GetValueOrDefault() &&
                !rbOdgovor3.IsChecked.GetValueOrDefault() &&
                !rbOdgovor4.IsChecked.GetValueOrDefault())
            {
                MessageBox.Show("Molimo odaberite odgovor!", "Upozorenje",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Prelazak na sljedeće pitanje", "Info");
            // Ovdje dodaj logiku za sljedeće pitanje
        }
    }
}
