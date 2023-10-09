using FETA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Model
{
    public enum EDAction { Encrypt, Decrypt, ShaFile, MDFile }
    public class EncryptDecryptModel : INotifyPropertyChangedImplementation
    {
        public EncryptDecryptModel()
        {
           EnDeAction = EDAction.Encrypt;
           Reset(true);
        }
        public void Reset(bool resetHashValue)
        {
            IsSourceFileLoaded = false;
            OutputStringFormat = false;
            IsDestinationFileChoosed = false;
            SourceFilePath = new StringBuilder();
            DestinationFilePath = new StringBuilder();
            HashValue = resetHashValue? "" : HashValue;
        }
        public StringBuilder SourceFilePath { get; set; }
        public StringBuilder DestinationFilePath { get; set; }

        private bool _isEDMode;
        public bool IsEDMode
        {
            get { return _isEDMode; }
            set { _isEDMode = value; OnPropertyChanged(nameof(IsEDMode)); }
        }

        private bool _isSMMode;
        public bool IsSMMode
        {
            get { return _isSMMode; }
            set { _isSMMode = value; OnPropertyChanged(nameof(IsSMMode)); }           
        }

        private string _hashValue;
        public string HashValue
        {
            get { return _hashValue; }
            set { _hashValue = value; OnPropertyChanged(nameof(HashValue)); }
        }

        private EDAction _enDeAction;
        public EDAction EnDeAction 
        { 
            get
            {
                return _enDeAction;
            }
            set
            {
                Reset(true);
                _enDeAction = value;
                IsEDMode = (value == EDAction.Encrypt || value == EDAction.Decrypt) ? true : false;
                IsSMMode = (value == EDAction.Encrypt || value == EDAction.Decrypt) ? false : true;
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
