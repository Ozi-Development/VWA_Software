using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Threading.Tasks;
using System.Windows;

namespace VWA_Software
{
    /// <summary>
    /// Interaktionslogik für "App.xaml"
    /// </summary>
    public partial class App : Application
    {
        public List<string> WpfListe { get; set; }
        public int ID { get; set; }

        public App()
        {
            WpfListe = new List<string>();
        }
    }
}
