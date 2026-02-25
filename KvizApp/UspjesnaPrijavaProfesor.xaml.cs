using Kviz.Core;
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

    public partial class UspjesnaPrijavaProfesor : Window
    {
        private string profesorUsername;

        public UspjesnaPrijavaProfesor(string profesorUsername)
        {
            InitializeComponent();
            this.profesorUsername = profesorUsername;
        }

        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnDodajIspit_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeTekstualno dodajPitanje = new DodajPitanjeTekstualno(profesorUsername);
            dodajPitanje.Show();
            this.Close();
        }

        private void btnPregledajIspite_Click(object sender, RoutedEventArgs e)
        {
            DostupniIspitiProfesor dostupniIspiti = new DostupniIspitiProfesor(profesorUsername);
            dostupniIspiti.Show();
            this.Close();
        }
    }
}
