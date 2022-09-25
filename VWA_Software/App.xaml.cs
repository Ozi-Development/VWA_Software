using System.Collections.Generic;
using System.Windows;
using VWA_Software.Core;

namespace VWA_Software
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public List<Wahlpflichtfächer> WpfList;
        public int ID { get; set; }
        public int Stundenzahl { get; set; }

        public App()
        {
            WpfList = new List<Wahlpflichtfächer>();
        }
    }
}
