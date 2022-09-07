using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using VWA_Software.MVVM.View;

namespace VWA_Software.Core
{
    internal class CheckAndDisable
    {
        private int _stundenzahl;

        public int Stundenzahl
        {
            get { return _stundenzahl; }
            set
            {
                _stundenzahl = value;
                DisableCkeckbox();
            }
        }



        private void DisableCkeckbox()
        {
            switch (_stundenzahl)
            {
                // Stundenzahl = 0 oder 2
                case 0:
                    MessageBox.Show(Convert.ToString(_stundenzahl));
                    ZeroTwo();
                    break;

                case 2:
                    MessageBox.Show(Convert.ToString(_stundenzahl));
                    ZeroTwo();
                    break;


                // Stundenzahl = 4
                case 4:
                    MessageBox.Show(Convert.ToString(_stundenzahl));
                    Four();
                    break;


                // Stundenzahl = 6
                case 6:
                    MessageBox.Show(Convert.ToString(_stundenzahl));
                    Six();
                    break;


                // Stundenzahl = 8 (Default)
                default:
                    MessageBox.Show(Convert.ToString(_stundenzahl));
                    DisableAll();
                    break;
            }
        }



        // Erlaubt alle Auswahlen
        private void ZeroTwo()
        {
            SelectionView selectionView = new SelectionView();

            var CheckedCheckbox = from cb in selectionView.AllGroups.Children.OfType<CheckBox>()
                                  where cb.IsChecked == false
                                  where cb.IsEnabled == false
                                  select cb;

            foreach (CheckBox checkBox in CheckedCheckbox)
            {
                checkBox.IsEnabled = true;
            }
        }


        // Erlaubt einjährige Gruppe B Wahlpflichtfächer inklusieve jene aus der 6. Klasse und Berufsorientierung
        private void Four()
        {
            throw new NotImplementedException();
        }



        // Erlaubt nur einjährige Gruppe B Wahlpflichtfächer (Außer jene in der 6. Klasse) und Berufsorientierung
        private void Six()
        {

            if (MessageBox.Show("Du hast zu viele Wahlpflichtfächer ausgewählt!\nBist du sicher, dass du fortfahren möchtest?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                MessageBox.Show("Deine Wahlpflichtfächer wurden erfolgreich eingereicht!", "Erfolgreich eingereicht", MessageBoxButton.OK);
            }
            else
            {
                MessageBox.Show("Canceling __ WIP");
            }




            //var CheckedCheckbox = from cb in selectionView.AllGroups.Children.OfType<CheckBox>()
            //                      where cb.Name == selectionView.chkSpanisch.Name ||
            //                            cb.Name == selectionView.chkItalienisch.Name ||
            //                            cb.Name == selectionView.chkFranzösisch.Name ||
            //                            cb.Name == selectionView.chkInformatik.Name ||
            //                            cb.Name == selectionView.chkFIT.Name ||
            //                            cb.Name == selectionView.chkSPOK.Name ||
            //                            cb.Name == selectionView.chkMusik.Name ||
            //                            cb.Name == selectionView.chkBE.Name ||
            //                            cb.Name == selectionView.chkDG.Name ||
            //                            cb.Name == selectionView.chkBerufsorientierung.Name
            //                      where cb.IsChecked == false
            //                      select cb;


            // Die checkboxes werden nicht deaktiviert und ich kann sie auch nicht in eine liste tun und dann deren namen mit foreach ausgeben!

            //foreach (CheckBox checkBox in CheckedCheckbox)
            //{
            //    checkBox.IsEnabled = false;
            //}


        }


        // Erlaubt keine weitere Auswahl mehr
        public void DisableAll()
        {
            SelectionView selectionView = new SelectionView();

            //List<int> list = new List<int>();
            //list.Add(0);
            //list.Add(1);


            //var Test = from lst in list
            //           where lst == 0
            //           where lst == 1
            //           select lst;



            foreach (TreeViewItem box in selectionView.GruppeA.Children.OfType<TreeViewItem>())
            {
                MessageBox.Show(Convert.ToString("1"));
            }








            var CheckedCheckbox = from cb in selectionView.AllGroups.Children.OfType<CheckBox>()
                                  //where cb.IsChecked == false
                                  select cb;

            foreach (CheckBox checkBox in CheckedCheckbox)
            {
                checkBox.IsEnabled = false;
            }
        }
    }
}
