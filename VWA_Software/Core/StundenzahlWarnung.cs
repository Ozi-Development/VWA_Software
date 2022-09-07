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

        public int Stundenzahl
        {
            get { return _stundenzahl; }
            set
            {
                _stundenzahl = value;
                CheckStundenzahl();
            }
        }

        private void CheckStundenzahl()
        {
            if (_stundenzahl == 8)
            {
                MessageBox.Show("Du hast die benötigte Stundenzahl erreicht.\nAlle weiteren Wahlpflichtfächer sind FREIWILLIG!", "Fast geschafft", MessageBoxButton.OK, MessageBoxImage.Information);
            }

            if (_stundenzahl > 8)
            {
                MessageBox.Show("Du hast zu viele Wahlpflichtfächer ausgewählt!\nBist du sicher, dass du fortfahren möchtest?", "Warnung", MessageBoxButton.YesNo, MessageBoxImage.Hand);
            }
        }
    }
}
