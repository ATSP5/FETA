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
                _enDeAction = value;
                OnPropertyChanged(nameof(EnDeAction));
            }
        }    
    }
}
