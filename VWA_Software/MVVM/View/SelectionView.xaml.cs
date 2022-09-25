using System.Linq;
using System.Windows;
using System.Windows.Controls;
using VWA_Software.Core;
using VWA_Software.Datenbank;

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
            Ausnahmen();
        }


        // Methods
        #region Methods

        // Ausnahmen
        private void Ausnahmen()
        {
            using (VWA_DatenbankEntities context = new VWA_DatenbankEntities())
            {
                int id = (App.Current as App).ID;

                // Französisch
                var französisch = from Ausnahme in context.Ausnahmen_Tabelle
                                  where Ausnahme.Schüler == id &&
                                        Ausnahme.Französisch_Pflichtfach == true
                                  select Ausnahme;

                if (französisch.Any())
                {
                    chkFranzösisch_A.IsEnabled = false;
                }
                else
                {
                    chkFranzösisch_6.IsEnabled = false;
                    chkFranzösisch_7.IsEnabled = false;
                    chkFranzösisch_8.IsEnabled = false;
                }


                // Italienisch
                var italienisch = from Ausnahme in context.Ausnahmen_Tabelle
                                  where Ausnahme.Schüler == id &&
                                        Ausnahme.Italienisch_Pflichtfach == true
                                  select Ausnahme;

                if (italienisch.Any())
                {
                    chkItalienisch_A.IsEnabled = false;
                }
                else
                {
                    chkItalienisch_6.IsEnabled = false;
                    chkItalienisch_7.IsEnabled = false;
                    chkItalienisch_8.IsEnabled = false;
                }


                // Latein
                var latein = from Ausnahme in context.Ausnahmen_Tabelle
                             where Ausnahme.Schüler == id &&
                                   Ausnahme.Latein_Pflichtfach == false
                             select Ausnahme;

                if (latein.Any())
                {
                    chkLatein_6.IsEnabled = false;
                    chkLatein_7.IsEnabled = false;
                    chkLatein_8.IsEnabled = false;
                }


                // Bildnerische Erziehung + Musik (May be deleted)
                var be = from Ausnahme in context.Ausnahmen_Tabelle
                         where Ausnahme.Schüler == id &&
                               Ausnahme.BE_Pflichtfach == true
                         select Ausnahme.Schüler;

                if (be.Any())
                {
                    chkBE.IsEnabled = false;
                    chkMusik_6.IsEnabled = false;
                    chkMusik_7.IsEnabled = false;
                    chkMusik_8.IsEnabled = false;
                }
                else
                {
                    chkBildnerischeErziehung_6.IsEnabled = false;
                    chkBildnerischeErziehung_7.IsEnabled = false;
                    chkBildnerischeErziehung_8.IsEnabled = false;
                    chkMusik.IsEnabled = false;
                }


                // Religion
                var religion = from Ausnahme in context.Ausnahmen_Tabelle
                               where Ausnahme.Schüler == id &&
                                     Ausnahme.Religion_Pflichtfach == false
                               select Ausnahme.Schüler;

                if (religion.Any())
                {
                    chkReligion_6.IsEnabled = false;
                    chkReligion_7.IsEnabled = false;
                    chkReligion_8.IsEnabled = false;
                }


                // Gymnasium
                var gymnasium = from Ausnahme in context.Ausnahmen_Tabelle
                                where Ausnahme.Schüler == id &&
                                      Ausnahme.DG_Pflichtfach == false
                                select Ausnahme.Schüler;

                if (gymnasium.Any())
                {
                    chkDG.IsEnabled = false;
                }
                else
                {
                    warnung.Stundenzahl = 2;
                }
            }
        }


        // Uncheck if Yes is selected for too many hours
        private void UncheckIfTooManyHours(bool tooManyHours, object thisSender)
        {
            if (tooManyHours == true)
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


        // Enable 7.Klasse
        private void Enable_7_Klasse(object thisSender)
        {
            CheckBox checkBox6 = thisSender as CheckBox;

            string name6 = checkBox6.Name;
            string name7 = name6.Replace('6', '7');

            CheckBox box = FindName(name7) as CheckBox;
            box.IsChecked = true;
        }

        // Disable 7.Klasse
        private void Disable_7_Klasse(object thisSender)
        {
            CheckBox checkBox6 = thisSender as CheckBox;

            string name6 = checkBox6.Name;
            string name7 = name6.Replace('7', '6');

            CheckBox box = FindName(name7) as CheckBox;
            box.IsChecked = false;
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

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_Spanisch);

        }
        private void chkSpanisch_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_Spanisch);
        }


        // Italienisch
        private void chkItalienisch_A_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_Italienisch);
        }
        private void chkItalienisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_Italienisch);
        }


        // Französisch
        private void chkFranzösisch_A_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_Französisch);
        }
        private void chkFranzösisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_Französisch);
        }


        // Informatik
        private void chkInformatik_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_Informatik);
        }
        private void chkInformatik_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_Informatik);
        }


        // FIT 
        private void chkFIT_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_FIT);
        }
        private void chkFIT_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_FIT);
        }


        // SPOK
        private void chkSPOK_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 6;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_SPOK);
        }
        private void chkSPOK_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 6;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_SPOK);
        }


        // DG
        private void chkDG_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 4;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_DG);
        }
        private void chkDG_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 4;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_DG);
        }


        // Musik
        private void chkMusik_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 4;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_Musik);
        }
        private void chkMusik_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 4;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_Musik);
        }


        // BE
        private void chkBE_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 4;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_BE);
        }
        private void chkBE_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 4;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_BE);
        }


        // BO
        private void chkBerufsorientierung_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.A_Berufsorientierung);
        }
        private void chkBerufsorientierung_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.A_Berufsorientierung);
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

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Religion);
        }

        private void chkReligion_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Religion);
        }

        // 7. Klasse
        private void chkReligion_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Religion);
        }

        private void chkReligion_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Religion);
        }

        // 8. Klasse
        private void chkReligion_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Religion);
        }

        private void chkReligion_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Religion);
        }
        #endregion Religion


        // Deutsch
        #region Deutsch

        // 6.Klasse 
        private void chkDeutsch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Deutsch);
        }

        private void chkDeutsch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Deutsch);
        }

        // 7. Klasse
        private void chkDeutsch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Deutsch);
        }

        private void chkDeutsch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Deutsch);
        }

        // 8. Klasse
        private void chkDeutsch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Deutsch);
        }

        private void chkDeutsch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Deutsch);
        }
        #endregion Deutsch


        // Englisch
        #region Englisch

        // 6.Klasse
        private void chkEnglisch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Englisch);
        }

        private void chkEnglisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Englisch);
        }

        // 7. Klasse
        private void chkEnglisch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Englisch);
        }

        private void chkEnglisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Englisch);
        }

        // 8.Klasse
        private void chkEnglisch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Englisch);
        }

        private void chkEnglisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Englisch);
        }
        #endregion Englisch


        // Französisch
        #region Französisch

        //6. Klasse
        private void chkFranzösisch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Französisch);
        }

        private void chkFranzösisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Französisch);
        }

        // 7. Klasse
        private void chkFranzösisch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Französisch);
        }

        private void chkFranzösisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Französisch);
        }

        // 8. Klasse
        private void chkFranzösisch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Französisch);
        }

        private void chkFranzösisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Französisch);
        }
        #endregion Französisch


        // Itanlienisch
        #region Itanlienisch

        // 6. Klasse
        private void chkItalienisch_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Italienisch);
        }

        private void chkItalienisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Italienisch);
        }

        // 7. Klasse
        private void chkItalienisch_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Italienisch);
        }

        private void chkItalienisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Italienisch);
        }

        // 8. Klasse
        private void chkItalienisch_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Italienisch);
        }

        private void chkItalienisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Italienisch);
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

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Latein);
        }

        private void chkLatein_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Latein);
        }

        // 7. Klasse
        private void chkLatein_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Latein);
        }

        private void chkLatein_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Latein);
        }

        // 8. Klasse
        private void chkLatein_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Latein);
        }

        private void chkLatein_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Latein);
        }
        #endregion Latein


        // Geschichte
        #region Geschichte

        // 6. Klasse
        private void chkGeschichte_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Geschichte);
        }

        private void chkGeschichte_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Geschichte);
        }

        // 7. Klasse
        private void chkGeschichte_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Geschichte);
        }

        private void chkGeschichte_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Geschichte);
        }

        // 8. Klasse
        private void chkGeschichte_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Geschichte);
        }

        private void chkGeschichte_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Geschichte);
        }
        #endregion Geschichte


        // Geographie
        #region Geographie

        // 6. Klasse
        private void chkGeographie_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Geographie);
        }

        private void chkGeographie_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Geographie);
        }

        // 7. Klasse
        private void chkGeographie_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Geographie);
        }

        private void chkGeographie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Geographie);
        }

        // 8. Klasse
        private void chkGeographie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Geographie);
        }

        private void chkGeographie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Geographie);
        }
        #endregion Geographie


        // Mathematik
        #region Mathematik

        //6. Klasse
        private void chkMathematik_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Mathematik);
        }

        private void chkMathematik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Mathematik);
        }

        // 7. Klasse
        private void chkMathematik_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Mathematik);
        }

        private void chkMathematik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Mathematik);
        }

        // 8. Klasse
        private void chkMathematik_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Mathematik);
        }

        private void chkMathematik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Mathematik);
        }
        #endregion Mathematik


        // Biologie
        #region Biologie

        //6. Klasse
        private void chkBiologie_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Biogogie);
        }

        private void chkBiologie_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Biogogie);
        }

        // 7. Klasse
        private void chkBiologie_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Biogogie);
        }

        private void chkBiologie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Biogogie);
        }

        // 8. Klasse
        private void chkBiologie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Biogogie);
        }

        private void chkBiologie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Biogogie);
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

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Chemie);
        }

        private void chkChemie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Chemie);
        }

        // 8. Klasse
        private void chkChemie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Chemie);
        }

        private void chkChemie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Chemie);
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

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Physik);
        }

        private void chkPhysik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Physik);
        }

        // 7. Klasse
        private void chkPhysik_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Physik);
        }

        private void chkPhysik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Physik);
        }

        // 8. Klasse
        private void chkPhysik_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Physik);
        }

        private void chkPhysik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Physik);
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

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_PUP);
        }

        private void chkPhilosophiePsychologie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_PUP);
        }

        // 8. Klasse
        private void chkPhilosophiePsychologie_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_PUP);
        }

        private void chkPhilosophiePsychologie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_PUP);
        }
        #endregion Philosphie und Psychologie


        // Musik
        #region Musik

        // 6. Klasse
        private void chkMusik_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_Musik);
        }

        private void chkMusik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_Musik);
        }

        // 7. Klasse
        private void chkMusik_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_Musik);
        }

        private void chkMusik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_Musik);
        }

        // 8. Klasse
        private void chkMusik_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_Musik);
        }

        private void chkMusik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_Musik);
        }
        #endregion Musik


        // Bildnerische Erziehung
        #region Bildnerische Erziehung

        // 6. Klasse
        private void chkBildnerischeErziehung_6_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            Enable_7_Klasse(sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_6_BE);
        }

        private void chkBildnerischeErziehung_6_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_6_BE);
        }

        // 7. Klasse
        private void chkBildnerischeErziehung_7_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_7_BE);
        }

        private void chkBildnerischeErziehung_7_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            Disable_7_Klasse(sender);
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_7_BE);
        }

        // 8. Klasse
        private void chkBildnerischeErziehung_8_Checked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl += 2;
            warnung.CheckStundenzahl();
            UncheckIfTooManyHours(warnung.StundenzahlBool, sender);

            (App.Current as App).WpfList.Add(Wahlpflichtfächer.B_8_BE);
        }

        private void chkBildnerischeErziehung_8_Unchecked(object sender, RoutedEventArgs e)
        {
            warnung.Stundenzahl -= 2;
            (App.Current as App).WpfList.Remove(Wahlpflichtfächer.B_8_BE);
        }
        #endregion Bildnerische Erziehung

        #endregion Gruppe B
    }
}