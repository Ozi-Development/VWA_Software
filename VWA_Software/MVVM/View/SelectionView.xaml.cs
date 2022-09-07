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
using System.Windows.Navigation;
using System.Windows.Shapes;
using VWA_Software.Core;

namespace VWA_Software.MVVM.View
{
    /// <summary>
    /// Interaktionslogik für SelectionView.xaml
    /// </summary>
    public partial class SelectionView : UserControl
    {
        StundenzahlWarnung warnung = new StundenzahlWarnung();  

        public SelectionView()
        {
            InitializeComponent();
        }


        ////// Gruppe A //////
        #region GruppeA

        //Spanisch
        private void chkSpanisch_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkSpanisch_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Italienisch
        private void chkItalienisch_A_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkItalienisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Französisch
        private void chkFranzösisch_A_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkFranzösisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Informatik
        private void chkInformatik_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkInformatik_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // FIT 
        private void chkFIT_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkFIT_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // SPOK
        private void chkSPOK_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkSPOK_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // DG
        private void chkDG_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkDG_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Musik
        private void chkMusik_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkMusik_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // BE
        private void chkBE_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
        }
        private void chkBE_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // BO
        private void chkBerufsorientierung_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
        }
        private void chkBerufsorientierung_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        #endregion GruppeA





        ////// Gruppe B //////
        #region Gruppe B

        // Currently WIP

        #endregion Gruppe B

    }
}
