using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using VWA_Software.Core;
using VWA_Software.Datenbank;

namespace VWA_Software
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnEinreichen_Click(object sender, RoutedEventArgs e)
        {
            StundenanzahlWarnung stundenanzahlWarnung = new StundenanzahlWarnung();

            int stundenanzahl = (App.Current as App).Stundenanzahl;
            int id = (App.Current as App).ID;

            List<Wahlpflichtfach> list = new List<Wahlpflichtfach>();
            list = (App.Current as App).WpfList;
            int listCount = list.Count;


            if (stundenanzahl < 8)
            {
                MessageBox.Show(string.Format("Du hast zu wenige Stunden gewählt!\nDir fehlen noch {0} Stunden!",
                                Convert.ToString(8 - stundenanzahl)), "Warnung", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else
            {
                using (VWA_DatenbankEntities context = new VWA_DatenbankEntities())
                {
                    Mouse.OverrideCursor = Cursors.Wait;

                    var idQuery = context.Wahlpflichtfächer.Where(x => x.Schüler == id);

                    foreach (var addWpf in idQuery)
                    {
                        addWpf.Wahlpflichtfach_1 = null;
                        addWpf.Wahlpflichtfach_2 = null;
                        addWpf.Wahlpflichtfach_3 = null;
                        addWpf.Wahlpflichtfach_4 = null;
                        addWpf.Wahlpflichtfach_5 = null;

                        switch (listCount)
                        {
                            case 1:
                                addWpf.Wahlpflichtfach_1 = list[0].ToString();
                                break;

                            case 2:
                                addWpf.Wahlpflichtfach_1 = list[0].ToString();
                                addWpf.Wahlpflichtfach_2 = list[1].ToString();
                                break;

                            case 3:
                                addWpf.Wahlpflichtfach_1 = list[0].ToString();
                                addWpf.Wahlpflichtfach_2 = list[1].ToString();
                                addWpf.Wahlpflichtfach_3 = list[2].ToString();
                                break;

                            case 4:
                                addWpf.Wahlpflichtfach_1 = list[0].ToString();
                                addWpf.Wahlpflichtfach_2 = list[1].ToString();
                                addWpf.Wahlpflichtfach_3 = list[2].ToString();
                                addWpf.Wahlpflichtfach_4 = list[3].ToString();
                                break;

                            case 5:
                                addWpf.Wahlpflichtfach_1 = list[0].ToString();
                                addWpf.Wahlpflichtfach_2 = list[1].ToString();
                                addWpf.Wahlpflichtfach_3 = list[2].ToString();
                                addWpf.Wahlpflichtfach_4 = list[3].ToString();
                                addWpf.Wahlpflichtfach_5 = list[4].ToString();
                                break;

                            default:
                                MessageBox.Show("Du hast zu viele Wahlpflichtfächer gewählt!\nDie Datenbank unterstützt maximal 5 verschiedene!",
                                                "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                Mouse.OverrideCursor = Cursors.Arrow;
                                return;
                        }
                    }
                    context.SaveChanges();
                    MessageBox.Show("Deine Wahlpflichtfächer wurden erfolgreich eingereicht!",
                                    "Erfolgreich eingereicht", MessageBoxButton.OK, MessageBoxImage.Information);
                    Mouse.OverrideCursor = Cursors.Arrow;
                }
            }
        }


        private void Drag(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void Minimize(object sender, RoutedEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
