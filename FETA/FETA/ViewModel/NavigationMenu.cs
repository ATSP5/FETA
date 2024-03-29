﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FETA.ViewModel
{
    public class NavigationMenu
    {
        public AboutViewModel AboutViewModel_O { get; set; }
        public EncryptDecryptViewModel EncryptDecryptViewModel_O { get; set; }  
        public HashViewModel HashViewModel_O { get; set; }

        public EncryptDecryptDataViewModel EncryptDecryptDataViewModel_O { get; set; }

        public NavigationMenu()
        {
            AboutViewModel_O = new AboutViewModel();
            EncryptDecryptViewModel_O = new EncryptDecryptViewModel();
            HashViewModel_O = new HashViewModel();
            EncryptDecryptDataViewModel_O = new EncryptDecryptDataViewModel();
        }
    }
}
