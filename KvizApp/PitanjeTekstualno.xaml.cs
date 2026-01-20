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
    /// Interaction logic for PitanjeTekstualno.xaml
    /// </summary>
    public partial class PitanjeTekstualno : Window
    {
        public PitanjeTekstualno()
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
            string odgovor = txtOdgovor.Text;

            if (string.IsNullOrWhiteSpace(odgovor))
            {
                MessageBox.Show("Molimo unesite odgovor!", "Upozorenje",
                              MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            MessageBox.Show("Prelazak na sljedeće pitanje", "Info");
            // Ovdje dodaj logiku za sljedeće pitanje
        }
    }
}
