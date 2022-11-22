using FETA.Controllers;
using FETA.Model;
using FETA.Services;
using Microsoft.Win32;
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
    public class EncryptDecryptViewModel
    {
        public EncryptDecryptModel EncryptDecryptModel_O { get; set; }
        private IFileTransactionService _fileTransactionService;
        public EncryptDecryptViewModel()
        {
            EncryptDecryptModel_O = new EncryptDecryptModel();
            _fileTransactionService = new FileTransactionService();
        }
        ICommand loadSourceFile = null;
        public ICommand LoadSourceFile
        {
            get
            {
                if(loadSourceFile == null)
                {
                    loadSourceFile = new RelayCommand
                        (
                            (object o ) =>
                            {
                                var ofd = new OpenFileDialog();
                                ofd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                                if (ofd.ShowDialog() == true)
                                {
                                    EncryptDecryptModel_O.IsSourceFileLoaded = true;
                                    EncryptDecryptModel_O.SourceFilePath.Clear();
                                    EncryptDecryptModel_O.SourceFilePath.Append(ofd.FileName);
                                }
                            },
                            (object o) =>
                            {
                                return true;
                            }
                        );
                }
                return loadSourceFile;
            }
        }

        ICommand chooseDestinationFile = null;
        public ICommand ChooseDestinationFile
        {
            get
            {
                if(chooseDestinationFile == null)
                {
                    chooseDestinationFile = new RelayCommand
                        (
                            (object o) =>
                            {
                                var sfd = new SaveFileDialog();
                                sfd.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                                if (sfd.ShowDialog() == true)
                                {
                                    EncryptDecryptModel_O.IsDestinationFileChoosed = true;
                                    EncryptDecryptModel_O.DestinationFilePath.Clear();
                                    EncryptDecryptModel_O.DestinationFilePath.Append(sfd.FileName);
                                }
                            },
                            (object o) =>
                            {
                                return true;
                            }
                        );
                }
                return chooseDestinationFile;
            }
        }

        ICommand process = null;
        public ICommand Process
        {
            get
            {
                if(process == null)
                {
                    process = new RelayCommand
                        (
                            (object o) =>
                            {
                                if(o is PasswordBox)
                                {
                                    var psswBox = (o as PasswordBox);
                                    bool encrypt = false;
                                    if(EncryptDecryptModel_O.EnDeAction==EDAction.Encrypt)
                                    {
                                        encrypt = true;
                                    }
                                    var fileTransactionResult=_fileTransactionService.SaveProcessedFile((EncryptDecryptModel_O.SourceFilePath.ToString(), EncryptDecryptModel_O.DestinationFilePath.ToString()), encrypt, psswBox);
                                    if (fileTransactionResult.isSuccesful == false)
                                    {
                                        MessageBox.Show(fileTransactionResult.msg,"ERROR!",MessageBoxButton.OK,MessageBoxImage.Error);
                                    }
                                }
                            },
                            (object o) =>
                            {
                                return true;
                            }
                        );
                }
                return process;
            }
        }

    }
}
