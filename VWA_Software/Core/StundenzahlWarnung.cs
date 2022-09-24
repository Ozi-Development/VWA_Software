using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using VWA_Software.MVVM.View;

namespace VWA_Software.Core
{
    internal class StundenzahlWarnung
    {
        private int _stundenzahl;
        private bool _stundenzahlBool;

        public bool StundenzahlBool
        {
            get { return _stundenzahlBool; }
            set { _stundenzahlBool = value; }
        }

        public int Stundenzahl
        {
            get { return _stundenzahl; }
            set 
            { 
                _stundenzahl = value;
                (App.Current as App).Stundenzahl = _stundenzahl;
            }
        }

        public void CheckStundenzahl()
        {
            if (_stundenzahl > 8)
            {
                // Anpassung am Text ??
                if (MessageBox.Show("Du hast zu viele Wahlpflichtfächer ausgewählt!\nDu hast aktuell " + Convert.ToString(_stundenzahl - 8) + " Stunden zu viel ausgewählt\nBist du sicher, dass du fortfahren möchtest?",
                                    "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.No)              // Text bearbeiten
                {
                    _stundenzahlBool = true;
                }
                else
                {
                    _stundenzahlBool = false;
                }
            }
        }
    }
}
