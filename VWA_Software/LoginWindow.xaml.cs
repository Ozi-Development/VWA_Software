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
            using (VWA_DatenbankEntities datenbankEntities = new VWA_DatenbankEntities())
            {
                string vorname = tbVorname.Text;
                string nachname = tbNachname.Text;
                string passwort = pwdPasswort.Password;

                var query = from Schüler in datenbankEntities.Schüler_Tabelle
                            where Schüler.Vorname == vorname && Schüler.Nachname == nachname /*&& Schüler.Passwort == passwort*/
                            select Schüler;

                if (query.Any())
                {
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    this.Close();
                }
                else if (String.IsNullOrEmpty(vorname) || String.IsNullOrEmpty(nachname)/* || String.IsNullOrEmpty(passwort)*/)
                {
                    MessageBox.Show("Bitte gib einen gülltigen Namen oder ein gülltiges Passwort ein!");
                }              
                else
                {
                    MessageBox.Show("Falsches Passwort oder falscher Name!");
                }
            }
        }

        private void Close(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
