using FETA.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.ViewModel
{
    public class EncryptDecryptViewModel
    {
        public EncryptDecryptModel EncryptDecryptModel_O { get; set; }
        public EncryptDecryptViewModel()
        {
            EncryptDecryptModel_O = new EncryptDecryptModel();
        }
    }
}
