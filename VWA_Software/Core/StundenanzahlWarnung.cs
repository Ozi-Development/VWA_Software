using System;
using System.Windows;

namespace VWA_Software.Core
{
    internal class StundenanzahlWarnung
    {
        private int _stundenanzahl;
        private bool _stundenanzahlBool;

        public bool StundenanzahlBool
        {
            get { return _stundenanzahlBool; }
            set { _stundenanzahlBool = value; }
        }

        public int Stundenanzahl
        {
            get { return _stundenanzahl; }
            set
            {
                _stundenanzahl = value;
                (App.Current as App).Stundenanzahl = _stundenanzahl;
            }
        }

        public void CheckStundenanzahl()
        {
            if (_stundenanzahl > 8)
            {
                if (MessageBox.Show(string.Format("Du hast zu viele Wahlpflichtfächer ausgewählt!\nDu hast aktuell {0} Stunden zu viel ausgewählt.\nBist du sicher, dass du fortfahren möchtest?",
                    Convert.ToString(_stundenanzahl - 8)), "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Hand) == MessageBoxResult.No)
                {
                    _stundenanzahlBool = true;
                }
                else
                {
                    _stundenanzahlBool = false;
                }
            }
        }
    }
}
