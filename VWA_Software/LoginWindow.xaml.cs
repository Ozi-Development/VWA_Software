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
using VWA_Software.Datenbank;
using VWA_Software.Core;

namespace VWA_Software
{
    /// <summary>
    /// Interaktionslogik für Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Drag(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }


        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string vorname = tbVorname.Text;
            string nachname = tbNachname.Text;
            string passwort = pwbPasswordBox.Password;

            try
            {
                using (VWA_DatenbankEntities datenbankEntities = new VWA_DatenbankEntities())
                {
                    var query = from Schüler in datenbankEntities.Schüler_Tabelle
                                where Schüler.Vorname == vorname && 
                                      Schüler.Nachname == nachname && 
                                      Schüler.Passwort == passwort
                                select Schüler.Schüler_ID;

                    if (query.Any())
                    {
                        int id = query.First();

                        (App.Current as App).ID = id;

                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        this.Close();
                    }

                    else if (String.IsNullOrEmpty(vorname) || String.IsNullOrEmpty(nachname) || String.IsNullOrEmpty(passwort))
                    {
                        MessageBox.Show("Bitte gib einen gültigen Namen oder ein gültiges Passwort ein!");
                    }

                    else
                    {
                        MessageBox.Show("Falsches Passwort oder falscher Name!");
                    }

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Du bist nicht mit dem Server verbunden!\nBitte melde diesen Fehler dem Administrator!\nFehler Code: " + ex.Message, "Server Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }


        private void Grid_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                btnLogin_Click(sender, e);
            }
        }
    }
}
