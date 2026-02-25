using Kviz.Core;
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
    public partial class DodajPitanjeVisestruki : Window
    {
        private int brojPitanja = 1;
        private List<Pitanje> pitanja;
        private string profesorUsername;

        public DodajPitanjeVisestruki(string profesorUsername, List<Pitanje>? postojecaPitanja = null)
        {
            InitializeComponent();
            this.profesorUsername = profesorUsername;
            pitanja = postojecaPitanja ?? new List<Pitanje>();
            brojPitanja = pitanja.Count + 1;
            txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
        }

        private void btnDodajOdgovor_Click(object sender, RoutedEventArgs e)
        {
            StackPanel noviOdgovor = new StackPanel
            {
                Orientation = Orientation.Horizontal,
                Margin = new Thickness(0, 5, 0, 0)
            };

            RadioButton rb = new RadioButton
            {
                GroupName = "TocanOdgovor",
                Margin = new Thickness(0, 0, 10, 0),
                VerticalAlignment = VerticalAlignment.Center
            };

            TextBox txt = new TextBox
            {
                Width = 500,
                Height = 30,
                Padding = new Thickness(5)
            };

            noviOdgovor.Children.Add(rb);
            noviOdgovor.Children.Add(txt);
            panelOdgovori.Children.Add(noviOdgovor);
        }

        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            if (pitanja.Count > 0)
            {
                pitanja.RemoveAt(pitanja.Count - 1);
                brojPitanja--;
                txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
            }
        }

        private void btnDodajVisestruki_Click(object sender, RoutedEventArgs e)
        {
            if (pitanja.Count >= 10)
            {
                MessageBox.Show("Ispit moze imati maksimalno 10 pitanja!", "Upozorenje");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPitanje.Text))
            {
                MessageBox.Show("Molimo unesite pitanje!", "Upozorenje");
                return;
            }

            var ponudeni = new List<string>();
            char tocanOdgovor = ' ';
            char oznaka = 'a';

            foreach (var child in panelOdgovori.Children)
            {
                if (child is StackPanel sp)
                {
                    RadioButton? rb = sp.Children.OfType<RadioButton>().FirstOrDefault();
                    TextBox? txt = sp.Children.OfType<TextBox>().FirstOrDefault();

                    if (txt != null && !string.IsNullOrWhiteSpace(txt.Text))
                    {
                        ponudeni.Add(txt.Text.Trim());
                        if (rb != null && rb.IsChecked == true)
                        {
                            tocanOdgovor = oznaka;
                        }
                        oznaka++;
                    }
                }
            }

            if (ponudeni.Count < 2)
            {
                MessageBox.Show("Morate unijeti barem 2 ponuđena odgovora!", "Upozorenje");
                return;
            }

            if (tocanOdgovor == ' ')
            {
                MessageBox.Show("Morate označiti točan odgovor!", "Upozorenje");
                return;
            }

            var novoPitanje = new SingleChoicePitanje
            {
                PitanjeTekst = txtPitanje.Text.Trim(),
                PonudeniOdg = ponudeni.ToArray(),
                OdgovorTocan = tocanOdgovor
            };

            pitanja.Add(novoPitanje);
            brojPitanja++;
            txtBrojPitanja.Text = $"Pitanje {brojPitanja}:";
            txtPitanje.Clear();

            // Resetiraj panel na 2 prazna odgovora
            panelOdgovori.Children.Clear();
            for (int i = 0; i < 2; i++)
            {
                StackPanel noviOdgovor = new StackPanel
                {
                    Orientation = Orientation.Horizontal,
                    Margin = new Thickness(0, 5, 0, 0)
                };
                noviOdgovor.Children.Add(new RadioButton
                {
                    GroupName = "TocanOdgovor",
                    Margin = new Thickness(0, 0, 10, 0),
                    VerticalAlignment = VerticalAlignment.Center
                });
                noviOdgovor.Children.Add(new TextBox
                {
                    Width = 500,
                    Height = 25,
                    Padding = new Thickness(5)
                });
                panelOdgovori.Children.Add(noviOdgovor);
            }

            MessageBox.Show("Pitanje dodano!", "Uspjeh");
        }

        private void btnDodajTekstualno_Click(object sender, RoutedEventArgs e)
        {
            if (pitanja.Count >= 10)
            {
                MessageBox.Show("Ispit moze imati maksimalno 10 pitanja!", "Upozorenje");
                return;
            }

            DodajPitanjeTekstualno tekstualno = new DodajPitanjeTekstualno(profesorUsername, pitanja);
            tekstualno.Show();
            this.Close();
        }

        private void btnZavrsi_Click(object sender, RoutedEventArgs e)
        {
            if (pitanja.Count < 5)
            {
                MessageBox.Show($"Ispit mora imati minimalno 5 pitanja! Trenutno imate {pitanja.Count}.", "Upozorenje");
                return;
            }

            Zavrsetak zavrsetak = new Zavrsetak(profesorUsername, pitanja);
            zavrsetak.Show();
            this.Close();
        }
    }
}
