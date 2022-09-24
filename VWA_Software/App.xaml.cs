using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
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
