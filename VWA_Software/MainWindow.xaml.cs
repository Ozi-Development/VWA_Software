using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
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
            StundenzahlWarnung stundenzahlWarnung = new StundenzahlWarnung();

            int stundenzahl = (App.Current as App).Stundenzahl;
            int id = (App.Current as App).ID;

            List<Wahlpflichtfächer> list = new List<Wahlpflichtfächer>();
            list = (App.Current as App).WpfList;
            int listCount = list.Count;



            if (stundenzahl < 8)
            {
                MessageBox.Show(String.Format("Zu wenige Stunden. Dir fehlen noch {0} Stunden!", Convert.ToString(8 - stundenzahl))); // Text bearbeiten
            }
            else
            {
                using (VWA_DatenbankEntities context = new VWA_DatenbankEntities())
                {

                    var query = context.Wahlpflichtfächer_Tabelle.Where(x => x.Schüler == id);

                    foreach (var addWpf in query)
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
                                MessageBox.Show("Zu viele WPF, die Datenbank unterstützt maximal 5 verschiedene WPFs!",
                                                "Warnung", MessageBoxButton.OK, MessageBoxImage.Hand); // Text bearbeiten
                                return;
                        }
                    }
                    context.SaveChanges();
                    MessageBox.Show("WPf erfolgreich eingereicht!");
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

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            using (VWA_DatenbankEntities context = new VWA_DatenbankEntities())
            {
                int id = (App.Current as App).ID;

                var query = context.Wahlpflichtfächer_Tabelle.Where(x => x.Schüler == id);

                foreach (var remove in query)
                {
                    remove.Wahlpflichtfach_1 = null;
                    remove.Wahlpflichtfach_2 = null;
                    remove.Wahlpflichtfach_3 = null;
                    remove.Wahlpflichtfach_4 = null;
                    remove.Wahlpflichtfach_5 = null;
                }
                context.SaveChanges();
            }
            
            MessageBox.Show("Alle WPf erfolgreich resetet");
        }
    }
}
