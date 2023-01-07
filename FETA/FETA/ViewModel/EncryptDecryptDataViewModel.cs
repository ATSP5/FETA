using FETA.Controllers;
using FETA.Model;
using FETA.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FETA.ViewModel
{
    public class EncryptDecryptDataViewModel
    {
        private IAESService _aesService;
        public EncryptDecryptDataModel EncryptDecryptDataModel_O { get; set; }
        public EncryptDecryptDataViewModel()
        {
            EncryptDecryptDataModel_O = new EncryptDecryptDataModel();
            _aesService = new AESService();
        }

        private ICommand _process;
        public ICommand Process
        {
            get 
            {
                if( _process == null )
                {
                    _process = new RelayCommand
                        (
                        (object o) =>
                        {
                            if (o is PasswordBox)
                            {
                                var psswBox = (o as PasswordBox);
                                _aesService.SetKey(psswBox.Password);
                                if(EncryptDecryptDataModel_O.Mode=="Encrypt")
                                {
                                    EncryptDecryptDataModel_O.Output = Encoding.Unicode.GetString(_aesService.Encrypt(EncryptDecryptDataModel_O.Input));
                                }
                                else
                                {
                                    EncryptDecryptDataModel_O.Output = _aesService.Decrypt(Encoding.Unicode.GetBytes(EncryptDecryptDataModel_O.Input));
                                }
                            }
                        },
                        (object o) =>
                        {
                            return true;
                        }
                        );
                }
                return _process;
            }
        }

        private ICommand _copy;
        public ICommand Copy
        {
            get
            {
                if (_copy == null)
                {
                    _copy= new RelayCommand
                        (
                        (object o) =>
                        {
                         Clipboard.SetText(EncryptDecryptDataModel_O.Output);
                        },
                        (object o) =>
                        {
                            return true;
                        }
                        );
                }
                return _copy;
            }
        }
    }
}
