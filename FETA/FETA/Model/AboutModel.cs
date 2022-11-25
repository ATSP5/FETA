using FETA.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Model
{
    public  class AboutModel : INotifyPropertyChangedImplementation
    {
        private string _aboutText;
        public string AboutText
        {
            get
            { 
                return _aboutText; 
            }
            set
            {
                _aboutText = value;
                OnPropertyChanged(nameof(AboutText));
            }
        }
    }
}
