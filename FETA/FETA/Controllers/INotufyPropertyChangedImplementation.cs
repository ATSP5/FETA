using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Controllers
{
    public class INotifyPropertyChangedImplementation : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged(string nameValue)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameValue));
        }
    }
}
