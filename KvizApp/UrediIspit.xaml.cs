using Kviz.Core;
using KvizApp;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kviz.Wpf
{
    public partial class UrediIspit : Window
    {
        private int ispitId;
        private string profesorUsername;
        private List<Pitanje> pitanja;

        public UrediIspit(int ispitId, string profesorUsername)
        {
            InitializeComponent();
            this.ispitId = ispitId;
            this.profesorUsername = profesorUsername;
            pitanja = new List<Pitanje>();

            UcitajIspit();
        }

        private void UcitajIspit()
        {
            try
            {
                using (var db = new KvizDbContext())
                {
                    var ispit = db.Ispiti
                        .Include(i => i.SkupPitanja)
                        .FirstOrDefault(i => i.Sifra == ispitId);

                    if (ispit == null)
                    {
                        MessageBox.Show("Ispit nije pronadjen!", "Greska");
                        this.Close();
                        return;
                    }

                    txtNazivIspita.Text = ispit.Naziv;
                    pitanja = ispit.SkupPitanja.ToList();
                }

                PrikaziPitanja();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri ucitavanju ispita: {ex.Message}", "Greska");
            }
        }

        private void PrikaziPitanja()
        {
            panelPitanja.Children.Clear();

            for (int i = 0; i < pitanja.Count; i++)
            {
                var pitanje = pitanja[i];
                var border = new Border
                {
                    Background = System.Windows.Media.Brushes.LightYellow,
                    BorderBrush = System.Windows.Media.Brushes.Gray,
                    BorderThickness = new Thickness(1),
                    CornerRadius = new CornerRadius(5),
                    Margin = new Thickness(0, 0, 0, 10),
                    Padding = new Thickness(15)
                };

                var stack = new StackPanel();

                // Naslov pitanja
                var header = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 0, 0, 5) };
                var chk = new CheckBox
                {
                    VerticalAlignment = VerticalAlignment.Center,
                    Margin = new Thickness(0, 0, 8, 0),
                    Tag = pitanje
                };
                var lbl = new TextBlock
                {
                    Text = $"Pitanje {i + 1}:",
                    FontSize = 16,
                    FontWeight = FontWeights.ExtraBold,
                    Foreground = System.Windows.Media.Brushes.Orange
                };
                string tipTekst = pitanje is SingleChoicePitanje ? " (visestruki odabir)" : " (tekstualno)";
                var lblTip = new TextBlock
                {
                    Text = tipTekst,
                    FontSize = 12,
                    Foreground = System.Windows.Media.Brushes.Gray,
                    VerticalAlignment = VerticalAlignment.Bottom,
                    Margin = new Thickness(5, 0, 0, 1)
                };
                header.Children.Add(chk);
                header.Children.Add(lbl);
                header.Children.Add(lblTip);
                stack.Children.Add(header);

                // Tekst pitanja
                var lblPitanje = new TextBlock { Text = "Tekst pitanja:", FontSize = 13, Margin = new Thickness(0, 5, 0, 3) };
                stack.Children.Add(lblPitanje);

                var txtPitanje = new TextBox
                {
                    Text = pitanje.PitanjeTekst,
                    FontSize = 14,
                    Height = 30,
                    Padding = new Thickness(5),
                    Tag = "PitanjeTekst"
                };
                stack.Children.Add(txtPitanje);

                if (pitanje is InputPitanje inputPitanje)
                {
                    var lblOdg = new TextBlock { Text = "Tocan odgovor:", FontSize = 13, Margin = new Thickness(0, 8, 0, 3) };
                    stack.Children.Add(lblOdg);

                    var txtOdg = new TextBox
                    {
                        Text = string.Join(", ", inputPitanje.OdgovorTocan),
                        FontSize = 14,
                        Height = 30,
                        Padding = new Thickness(5),
                        Tag = "OdgovorTocan"
                    };
                    stack.Children.Add(txtOdg);
                }
                else if (pitanje is SingleChoicePitanje scPitanje)
                {
                    var lblOdg = new TextBlock { Text = "Ponudjeni odgovori (oznacite tocan):", FontSize = 13, Margin = new Thickness(0, 8, 0, 3) };
                    stack.Children.Add(lblOdg);

                    string groupName = $"Pitanje_{pitanje.PitanjeId}_{i}";
                    var panelOdgovori = new StackPanel { Tag = "PanelOdgovori" };

                    char oznaka = 'a';
                    foreach (var odg in scPitanje.PonudeniOdg)
                    {
                        var row = new StackPanel { Orientation = Orientation.Horizontal, Margin = new Thickness(0, 3, 0, 0) };

                        var rb = new RadioButton
                        {
                            GroupName = groupName,
                            IsChecked = (oznaka == scPitanje.OdgovorTocan),
                            VerticalAlignment = VerticalAlignment.Center,
                            Margin = new Thickness(0, 0, 8, 0)
                        };

                        var txt = new TextBox
                        {
                            Text = odg,
                            Width = 450,
                            Height = 25,
                            Padding = new Thickness(5),
                            FontSize = 13
                        };

                        row.Children.Add(rb);
                        row.Children.Add(txt);
                        panelOdgovori.Children.Add(row);
                        oznaka++;
                    }

                    stack.Children.Add(panelOdgovori);
                }

                border.Child = stack;
                panelPitanja.Children.Add(border);
            }

            if (pitanja.Count == 0)
            {
                var txt = new TextBlock
                {
                    Text = "Ovaj ispit nema pitanja.",
                    FontSize = 16,
                    Foreground = System.Windows.Media.Brushes.Gray,
                    HorizontalAlignment = HorizontalAlignment.Center,
                    Margin = new Thickness(0, 30, 0, 0)
                };
                panelPitanja.Children.Add(txt);
            }
        }

        private void btnSpremi_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNazivIspita.Text))
            {
                MessageBox.Show("Naziv ispita ne smije biti prazan!", "Upozorenje");
                return;
            }

            try
            {
                int pitanjeIndex = 0;
                foreach (var child in panelPitanja.Children)
                {
                    if (child is Border border && border.Child is StackPanel stack)
                    {
                        if (pitanjeIndex >= pitanja.Count) break;
                        var pitanje = pitanja[pitanjeIndex];

                        foreach (var el in stack.Children)
                        {
                            if (el is TextBox tb && tb.Tag as string == "PitanjeTekst")
                            {
                                pitanje.PitanjeTekst = tb.Text.Trim();
                            }

                            if (pitanje is InputPitanje inputP && el is TextBox tbOdg && tbOdg.Tag as string == "OdgovorTocan")
                            {
                                inputP.OdgovorTocan = new[] { tbOdg.Text.Trim() };
                            }

                            if (pitanje is SingleChoicePitanje scP && el is StackPanel panelOdg && panelOdg.Tag as string == "PanelOdgovori")
                            {
                                var noviOdgovori = new List<string>();
                                char tocanOdgovor = ' ';
                                char oznaka = 'a';

                                foreach (var row in panelOdg.Children)
                                {
                                    if (row is StackPanel rowSp)
                                    {
                                        var rb = rowSp.Children.OfType<RadioButton>().FirstOrDefault();
                                        var txt = rowSp.Children.OfType<TextBox>().FirstOrDefault();

                                        if (txt != null && !string.IsNullOrWhiteSpace(txt.Text))
                                        {
                                            noviOdgovori.Add(txt.Text.Trim());
                                            if (rb != null && rb.IsChecked == true)
                                            {
                                                tocanOdgovor = oznaka;
                                            }
                                            oznaka++;
                                        }
                                    }
                                }

                                if (tocanOdgovor == ' ')
                                {
                                    MessageBox.Show($"Pitanje {pitanjeIndex + 1}: morate oznaciti tocan odgovor!", "Upozorenje");
                                    return;
                                }

                                scP.PonudeniOdg = noviOdgovori.ToArray();
                                scP.OdgovorTocan = tocanOdgovor;
                            }
                        }

                        pitanjeIndex++;
                    }
                }

                using (var db = new KvizDbContext())
                {
                    var ispit = db.Ispiti
                        .Include(i => i.SkupPitanja)
                        .FirstOrDefault(i => i.Sifra == ispitId);

                    if (ispit == null)
                    {
                        MessageBox.Show("Ispit nije pronadjen u bazi!", "Greska");
                        return;
                    }

                    ispit.Naziv = txtNazivIspita.Text.Trim();

                    foreach (var pitanje in pitanja)
                    {
                        var dbPitanje = ispit.SkupPitanja.FirstOrDefault(p => p.PitanjeId == pitanje.PitanjeId);
                        if (dbPitanje != null)
                        {
                            dbPitanje.PitanjeTekst = pitanje.PitanjeTekst;

                            if (dbPitanje is InputPitanje dbInput && pitanje is InputPitanje editInput)
                            {
                                dbInput.OdgovorTocan = editInput.OdgovorTocan;
                            }
                            else if (dbPitanje is SingleChoicePitanje dbSc && pitanje is SingleChoicePitanje editSc)
                            {
                                dbSc.PonudeniOdg = editSc.PonudeniOdg;
                                dbSc.OdgovorTocan = editSc.OdgovorTocan;
                            }
                        }
                    }

                    db.SaveChanges();
                }

                MessageBox.Show("Promjene su uspjesno spremljene!", "Uspjeh");
            }
            catch (Exception ex)
            {
                var poruka = ex.InnerException != null ? ex.InnerException.Message : ex.Message;
                MessageBox.Show($"Greska pri spremanju: {poruka}", "Greska");
            }
        }

        private void btnObrisiPitanje_Click(object sender, RoutedEventArgs e)
        {
            var zaObrisati = new List<Pitanje>();

            foreach (var child in panelPitanja.Children)
            {
                if (child is Border border && border.Child is StackPanel stack)
                {
                    foreach (var el in stack.Children)
                    {
                        if (el is StackPanel headerPanel)
                        {
                            var chk = headerPanel.Children.OfType<CheckBox>().FirstOrDefault();
                            if (chk != null && chk.IsChecked == true && chk.Tag is Pitanje pitanje)
                            {
                                zaObrisati.Add(pitanje);
                            }
                        }
                    }
                }
            }

            if (zaObrisati.Count == 0)
            {
                MessageBox.Show("Oznacite pitanja koja zelite obrisati!", "Upozorenje");
                return;
            }

            if (pitanja.Count - zaObrisati.Count < 5)
            {
                MessageBox.Show($"Ispit mora imati minimalno 5 pitanja! Nakon brisanja bi ostalo {pitanja.Count - zaObrisati.Count}.", "Upozorenje");
                return;
            }

            var rezultat = MessageBox.Show(
                $"Jeste li sigurni da zelite obrisati {zaObrisati.Count} pitanje/pitanja?",
                "Potvrda brisanja",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (rezultat != MessageBoxResult.Yes) return;

            try
            {
                using (var db = new KvizDbContext())
                {
                    foreach (var pitanje in zaObrisati)
                    {
                        var dbPitanje = db.Pitanja.FirstOrDefault(p => p.PitanjeId == pitanje.PitanjeId);
                        if (dbPitanje != null)
                        {
                            db.Pitanja.Remove(dbPitanje);
                        }
                    }
                    db.SaveChanges();
                }

                foreach (var pitanje in zaObrisati)
                {
                    pitanja.Remove(pitanje);
                }

                PrikaziPitanja();
                MessageBox.Show("Pitanja su obrisana!", "Uspjeh");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Greska pri brisanju: {ex.Message}", "Greska");
            }
        }

        private void btnNatrag_Click(object sender, RoutedEventArgs e)
        {
            DostupniIspitiProfesor dostupni = new DostupniIspitiProfesor(profesorUsername);
            dostupni.Show();
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
