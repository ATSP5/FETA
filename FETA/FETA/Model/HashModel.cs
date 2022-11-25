using FETA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Model
{
    public enum HashCompareAction { Hash, Compare }
    public class HashModel : INotifyPropertyChangedImplementation
    {
        public HashModel()
        {
            HCAction = HashCompareAction.Hash;
            Input = "";
            Output = "";
            Seed = "";
            IOLabel = "Output";
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
        private string _seed;
        public string Seed 
        { 
            get
            {
                return _seed;
            }
            set
            {
                _seed = value;
                OnPropertyChanged(nameof(Seed));
            }
        }
        private HashCompareAction _hcAction;
        public HashCompareAction HCAction
        {
            get 
            { 
                return _hcAction; 
            }
            set 
            { 
                _hcAction = value; 
                if(value == HashCompareAction.Hash)
                {
                    IOLabel = "Output";
                }
                else
                {
                    IOLabel = "Hashed Input";
                }
                OnPropertyChanged(nameof(HCAction)); 
            }
        }

        private string _ioLabel;
        public string IOLabel
        {
            get
            { 
                return _ioLabel;
            }
            set
            {
                _ioLabel = value;
                OnPropertyChanged(nameof(IOLabel));
            }
        }
    }
}
