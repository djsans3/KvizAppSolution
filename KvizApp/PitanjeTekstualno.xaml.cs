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
       
        private void btnNastavi_Click(object sender, RoutedEventArgs e)
        {
            string odgovor = txtOdgovor.Text;
        }
        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            PrikazIspita prikazIspita = new PrikazIspita();
            prikazIspita.Show();
            this.Close();
        }
    }
}
