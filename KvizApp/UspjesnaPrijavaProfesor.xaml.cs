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
    /// Interaction logic for UspjesnaPrijavaProfesor.xaml
    /// </summary>
    public partial class UspjesnaPrijavaProfesor : Window
    {
        public UspjesnaPrijavaProfesor()
        {
            InitializeComponent();
        }
        private void btnOdjava_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            this.Close();
        }

        private void btnDodajIspit_Click(object sender, RoutedEventArgs e)
        {
            DodajPitanjeTekstualno dodajPitanje = new DodajPitanjeTekstualno();
            dodajPitanje.Show();
            this.Close();
        }
    }
}
