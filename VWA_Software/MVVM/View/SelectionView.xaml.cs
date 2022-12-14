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
        StundenanzahlWarnung warnung = new StundenanzahlWarnung();

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
                var französisch = from Ausnahme in context.Ausnahmen
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
                var italienisch = from Ausnahme in context.Ausnahmen
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
                var latein = from Ausnahme in context.Ausnahmen
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
                var be = from Ausnahme in context.Ausnahmen
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
                var religion = from Ausnahme in context.Ausnahmen
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
                var gymnasium = from Ausnahme in context.Ausnahmen
                                where Ausnahme.Schüler == id &&
                                      Ausnahme.Gymnasium == false
                                select Ausnahme.Schüler;

                if (gymnasium.Any())
                {
                    chkDG.IsEnabled = false;
                }
                else
                {
                    warnung.Stundenanzahl = 2;
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
                warnung.StundenanzahlBool = false;
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
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_Spanisch);
            warnung.Stundenanzahl += 6;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkSpanisch_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_Spanisch);
            warnung.Stundenanzahl -= 6;
        }


        // Italienisch
        private void chkItalienisch_A_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_Italienisch);
            warnung.Stundenanzahl += 6;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkItalienisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_Italienisch);
            warnung.Stundenanzahl -= 6;
        }


        // Französisch
        private void chkFranzösisch_A_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_Französisch);
            warnung.Stundenanzahl += 6;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkFranzösisch_A_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_Französisch);
            warnung.Stundenanzahl -= 6;
        }


        // Informatik
        private void chkInformatik_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_Informatik);
            warnung.Stundenanzahl += 6;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkInformatik_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_Informatik);
            warnung.Stundenanzahl -= 6;
        }


        // FIT 
        private void chkFIT_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_FIT);
            warnung.Stundenanzahl += 6;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkFIT_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_FIT);
            warnung.Stundenanzahl -= 6;
        }


        // SPOK
        private void chkSPOK_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_SPOK);
            warnung.Stundenanzahl += 6;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkSPOK_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_SPOK);
            warnung.Stundenanzahl -= 6;
        }


        // DG
        private void chkDG_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_DG);
            warnung.Stundenanzahl += 4;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkDG_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_DG);
            warnung.Stundenanzahl -= 4;
        }


        // Musik
        private void chkMusik_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_Musik);
            warnung.Stundenanzahl += 4;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkMusik_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_Musik);
            warnung.Stundenanzahl -= 4;
        }


        // BE
        private void chkBE_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_BE);
            warnung.Stundenanzahl += 4;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkBE_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_BE);
            warnung.Stundenanzahl -= 4;
        }


        // BO
        private void chkBerufsorientierung_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.A_Berufsorientierung);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }
        private void chkBerufsorientierung_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.A_Berufsorientierung);
            warnung.Stundenanzahl -= 2;
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
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Religion);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkReligion_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Religion);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkReligion_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Religion);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkReligion_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Religion);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkReligion_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Religion);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkReligion_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Religion);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Religion


        // Deutsch
        #region Deutsch

        // 6.Klasse 
        private void chkDeutsch_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Deutsch);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkDeutsch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Deutsch);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkDeutsch_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Deutsch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkDeutsch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Deutsch);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkDeutsch_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Deutsch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkDeutsch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Deutsch);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Deutsch


        // Englisch
        #region Englisch

        // 6.Klasse
        private void chkEnglisch_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Englisch);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkEnglisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Englisch);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkEnglisch_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Englisch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkEnglisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Englisch);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8.Klasse
        private void chkEnglisch_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Englisch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkEnglisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Englisch);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Englisch


        // Französisch
        #region Französisch

        //6. Klasse
        private void chkFranzösisch_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Französisch);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkFranzösisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Französisch);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkFranzösisch_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Französisch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkFranzösisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Französisch);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkFranzösisch_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Französisch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkFranzösisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Französisch);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Französisch


        // Itanlienisch
        #region Itanlienisch

        // 6. Klasse
        private void chkItalienisch_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Italienisch);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkItalienisch_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Italienisch);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkItalienisch_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Italienisch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkItalienisch_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Italienisch);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkItalienisch_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Italienisch);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkItalienisch_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Italienisch);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Itanlienisch


        // Row 2


        // Latein
        #region Latein

        // 6. Klasse
        private void chkLatein_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Latein);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkLatein_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Latein);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkLatein_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Latein);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkLatein_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Latein);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkLatein_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Latein);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkLatein_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Latein);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Latein


        // Geschichte
        #region Geschichte

        // 6. Klasse
        private void chkGeschichte_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Geschichte);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkGeschichte_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Geschichte);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkGeschichte_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Geschichte);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkGeschichte_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Geschichte);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkGeschichte_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Geschichte);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkGeschichte_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Geschichte);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Geschichte


        // Geographie
        #region Geographie

        // 6. Klasse
        private void chkGeographie_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Geographie);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkGeographie_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Geographie);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkGeographie_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Geographie);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkGeographie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Geographie);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkGeographie_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Geographie);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkGeographie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Geographie);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Geographie


        // Mathematik
        #region Mathematik

        //6. Klasse
        private void chkMathematik_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Mathematik);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkMathematik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Mathematik);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkMathematik_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Mathematik);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkMathematik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Mathematik);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkMathematik_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Mathematik);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkMathematik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Mathematik);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Mathematik


        // Biologie
        #region Biologie

        //6. Klasse
        private void chkBiologie_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Biogogie);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkBiologie_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Biogogie);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkBiologie_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Biogogie);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkBiologie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Biogogie);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkBiologie_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Biogogie);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkBiologie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Biogogie);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Biologie


        // Chemie
        #region Chemie

        // 7. Klasse
        private void chkChemie_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Chemie);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkChemie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Chemie);
            warnung.Stundenanzahl -= 2;
        }

        // 8. Klasse
        private void chkChemie_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Chemie);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkChemie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Chemie);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Chemie


        // Row 3


        // Physik
        #region Physik

        // 6. Klasse
        private void chkPhysik_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Physik);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkPhysik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Physik);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkPhysik_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Physik);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkPhysik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Physik);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkPhysik_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Physik);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkPhysik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Physik);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Physik


        // Philosophie und Psychologie
        #region Philosophie und Psychologie

        // 7. Klasse
        private void chkPhilosophiePsychologie_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_PUP);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkPhilosophiePsychologie_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_PUP);
            warnung.Stundenanzahl -= 2;
        }

        // 8. Klasse
        private void chkPhilosophiePsychologie_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_PUP);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkPhilosophiePsychologie_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_PUP);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Philosphie und Psychologie


        // Musik
        #region Musik

        // 6. Klasse
        private void chkMusik_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_Musik);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkMusik_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_Musik);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkMusik_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_Musik);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkMusik_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_Musik);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkMusik_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_Musik);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkMusik_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_Musik);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Musik


        // Bildnerische Erziehung
        #region Bildnerische Erziehung

        // 6. Klasse
        private void chkBildnerischeErziehung_6_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_6_BE);
            warnung.Stundenanzahl += 2;
            Enable_7_Klasse(sender);
        }

        private void chkBildnerischeErziehung_6_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_6_BE);
            warnung.Stundenanzahl -= 2;
        }

        // 7. Klasse
        private void chkBildnerischeErziehung_7_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_7_BE);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkBildnerischeErziehung_7_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_7_BE);
            warnung.Stundenanzahl -= 2;
            Disable_7_Klasse(sender);
        }

        // 8. Klasse
        private void chkBildnerischeErziehung_8_Checked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Add(Wahlpflichtfach.B_8_BE);
            warnung.Stundenanzahl += 2;
            warnung.CheckStundenanzahl();
            UncheckIfTooManyHours(warnung.StundenanzahlBool, sender);
        }

        private void chkBildnerischeErziehung_8_Unchecked(object sender, RoutedEventArgs e)
        {
            (App.Current as App).WpfList.Remove(Wahlpflichtfach.B_8_BE);
            warnung.Stundenanzahl -= 2;
        }
        #endregion Bildnerische Erziehung

        #endregion Gruppe B
    }
}