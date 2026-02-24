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
            PrikazIspita prikazIspita = new PrikazIspita();
            prikazIspita.Show();
            this.Close();
        }

        private void btnNastavi_Click(object sender, RoutedEventArgs e)
        {
            PitanjeTekstualno pitanjeTekst = new PitanjeTekstualno();
            pitanjeTekst.Show();
            this.Close();
        }

    }
}
