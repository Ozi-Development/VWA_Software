using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VWA_Software.Core;

namespace VWA_Software.MVVM.ViewModel
{
    internal class MainViewModel : ObservableObject
    {

        public SelectionViewModel SelectionVM { get; set; }

        private object _currentView;
        public object CurrentView
        {
            get { return _currentView; }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public MainViewModel()
        {
            SelectionVM = new SelectionViewModel();
        }
    }
}
