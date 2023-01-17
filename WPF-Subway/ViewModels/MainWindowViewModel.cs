using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WPF_Subway.ViewModels
{
    class MainWindowViewModel : Notifier
    {
        public MainWindowViewModel()
        {
        }
        private string _bindintTest;
        public string bindingTest { get => _bindintTest; set { _bindintTest = value; OnPropertyChanged(nameof(bindingTest)); }}
                            
    }
}
