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



        // Methods
        #region Methods
        // Uncheck if Yes is checked for too many hours
        private void UncheckIfTooManyHours(bool tooManyHours, object thisSender)
        {
            if(tooManyHours == true)
            {
                CheckBox box = thisSender as CheckBox;
                box.IsChecked = false;
                warnung.StundenzahlBool = false;


                CheckBox checkBox6 = thisSender as CheckBox;

                string name6 = checkBox6.Name;
                string name7 = name6.Replace('7', '6');

                CheckBox box2 = FindName(name7) as CheckBox;
                box2.IsChecked = false;
            }
        }

        // Enable/Disable 7.Klasse
        private void Enable_7_Klasse(object thisSender)
        {
            CheckBox checkBox6 = thisSender as CheckBox;

            string name6 = checkBox6.Name;
            string name7 = name6.Replace('6', '7');

            CheckBox box = FindName(name7) as CheckBox;
            box.IsChecked = true;
        }
        #endregion Methods



        ////// Gruppe A //////
        #region GruppeA

        //Spanisch
        private void chkSpanisch_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkSpanisch_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Italienisch
        private void chkItalienisch_A_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkItalienisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Französisch
        private void chkFranzösisch_A_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkFranzösisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Informatik
        private void chkInformatik_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkInformatik_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // FIT 
        private void chkFIT_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkFIT_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // SPOK
        private void chkSPOK_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkSPOK_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // DG
        private void chkDG_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkDG_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // Musik
        private void chkMusik_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkMusik_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // BE
        private void chkBE_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkBE_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
        }


        // BO
        private void chkBerufsorientierung_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }
        private void chkBerufsorientierung_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        #endregion GruppeA


        ////// Gruppe B //////
        #region Gruppe B

        // Row 1


        // Religion
        #region Religion

        // 6.Klasse
        private void chkReligion_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkReligion_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkReligion_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkReligion_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkReligion_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkReligion_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Religion


        // Deutsch
        #region Deutsch

        // 6.Klasse 
        private void chkDeutsch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkDeutsch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkDeutsch_7_Checked(object sender, RoutedEventArgs e)
        {            
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkDeutsch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkDeutsch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkDeutsch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Deutsch


        // Englisch
        #region Englisch

        // 6.Klasse
        private void chkEnglisch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkEnglisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkEnglisch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkEnglisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8.Klasse
        private void chkEnglisch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkEnglisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Englisch


        // Französisch
        #region Französisch

        //6. Klasse
        private void chkFranzösisch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkFranzösisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkFranzösisch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkFranzösisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkFranzösisch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkFranzösisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Französisch


        // Itanlienisch
        #region Itanlienisch

        // 6. Klasse
        private void chkItalienisch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkItalienisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkItalienisch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkItalienisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkItalienisch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkItalienisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Itanlienisch


        // Row 2


        // Latein
        #region Latein

        // 6. Klasse
        private void chkLatein_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkLatein_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkLatein_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkLatein_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkLatein_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkLatein_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Latein


        // Geschichte
        #region Geschichte

        // 6. Klasse
        private void chkGeschichte_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkGeschichte_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkGeschichte_7_Checked(object sender, RoutedEventArgs e)
        {
        }

        private void chkGeschichte_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkGeschichte_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkGeschichte_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Geschichte


        // Geographie
        #region Geographie

        // 6. Klasse
        private void chkGeographie_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkGeographie_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkGeographie_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkGeographie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkGeographie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkGeographie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Geographie


        // Mathematik
        #region Mathematik

        //6. Klasse
        private void chkMathematik_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkMathematik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkMathematik_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkMathematik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkMathematik_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkMathematik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Mathematik


        // Biologie
        #region Biologie

        //6. Klasse
        private void chkBiologie_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkBiologie_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkBiologie_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkBiologie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkBiologie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkBiologie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Biologie


        // Chemie
        #region Chemie

        // 7. Klasse
        private void chkChemie_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkChemie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkChemie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkChemie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Chemie


        // Row 3


        // Physik
        #region Physik

        // 6. Klasse
        private void chkPhysik_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkPhysik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkPhysik_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkPhysik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkPhysik_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkPhysik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Physik


        // Philosophie und Psychologie
        #region Philosophie und Psychologie

        // 7. Klasse
        private void chkPhilosophiePsychologie_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkPhilosophiePsychologie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkPhilosophiePsychologie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkPhilosophiePsychologie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Philosphie und Psychologie


        // Musik
        #region Musik

        // 6. Klasse
        private void chkMusik_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkMusik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkMusik_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkMusik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkMusik_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkMusik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Musik


        // Bildnerische Erziehung
        #region Bildnerische Erziehung

        // 6. Klasse
        private void chkBildnerischeErziehung_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkBildnerischeErziehung_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 7. Klasse
        private void chkBildnerischeErziehung_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkBildnerischeErziehung_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }

        // 8. Klasse
        private void chkBildnerischeErziehung_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);
        }

        private void chkBildnerischeErziehung_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
        }
        #endregion Bildnerische Erziehung

        #endregion Gruppe B
    }
}