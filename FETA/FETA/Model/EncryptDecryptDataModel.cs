using FETA.Controllers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Model
{
    public class EncryptDecryptDataModel : INotifyPropertyChangedImplementation
    {
        public EncryptDecryptDataModel()
        {
            Modes = new ObservableCollection<string>();
            Modes.Add("Encrypt");
            Modes.Add("Dercypt");
            Mode = Modes[0];
            Input = "";
            Output = "";
        }
        private string _input;
        public string Input
        {
            get 
            { 
                return _input; 
            }
            set 
            { 
                _input = value;
                OnPropertyChanged(nameof(Input));
            }
        }
        private string _output;
        public string Output
        {
            get 
            { 
                return _output; 
            } 
            set 
            { 
                _output = value;
                OnPropertyChanged(nameof(Output)); 
            } 
        }

        private string _mode;
        public string Mode 
        { 
            get 
            { 
                return _mode; 
            } set 
            { 
                _mode = value;
                OnPropertyChanged(nameof(Mode)); 
            }
        }

        private ObservableCollection<string> _modes;
        public ObservableCollection<string> Modes
        {
            get
            { 
                return _modes;
            }
            set
            {
                _modes = value;
                OnPropertyChanged(nameof(Modes));
            }
        }

    }
}
