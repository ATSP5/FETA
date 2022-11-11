using FETA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Model
{
    public enum EDAction { Encrypt, Decrypt }
    public class EncryptDecryptModel : INotifyPropertyChangedImplementation
    {
        public EncryptDecryptModel()
        {
            EnDeAction = EDAction.Encrypt;
            IsSourceFileLoaded = false;
            OutputStringFormat = false;
            IsDestinationFileChoosed = false;
            SourceFilePath = new StringBuilder();
            DestinationFilePath = new StringBuilder();
        }
        public StringBuilder SourceFilePath { get; set; }
        public StringBuilder DestinationFilePath { get; set; } 

        private EDAction _enDeAction;
        public EDAction EnDeAction 
        { 
            get
            {
                return _enDeAction;
            }
            set
            {
                _enDeAction = value;
                OnPropertyChanged(nameof(EnDeAction));
            }
        }

        private bool _isSourceFileLoaded;
        public bool IsSourceFileLoaded
        {
            get
            {
                return _isSourceFileLoaded;
            }
            set
            {
                _isSourceFileLoaded = value;
                OnPropertyChanged(nameof(IsSourceFileLoaded));
            }
        }
        private bool _outputStringFormat;
        public bool OutputStringFormat
        {
            get
            {
                return _outputStringFormat;
            }
            set
            {
                _outputStringFormat = value;
                OnPropertyChanged(nameof(OutputStringFormat));
            }
        }
        private bool _isDestinationFileChoosed;
        public bool IsDestinationFileChoosed
        {
            get
            {
                return _isDestinationFileChoosed;
            }
            set
            {
                _isDestinationFileChoosed = value;
                OnPropertyChanged(nameof(IsDestinationFileChoosed));
            }
        }

    }
}
