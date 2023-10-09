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
        private ISHAService _shaService;
        public EncryptDecryptViewModel()
        {
            EncryptDecryptModel_O = new EncryptDecryptModel();
            _fileTransactionService = new FileTransactionService();
            _shaService = new SHAService();
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
                                if (EncryptDecryptModel_O.EnDeAction== EDAction.Decrypt)
                                    ofd.Filter = "Text files (*.fta)|*.fta|All files (*.*)|*.*";
                                else
                                    ofd.Filter = "All files (*.*)|*.*";
                                ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                                if (EncryptDecryptModel_O.EnDeAction == EDAction.Encrypt)
                                    sfd.Filter = "Text files (*.fta)|*.fta|All files (*.*)|*.*";
                                else
                                    sfd.Filter = "All files (*.*)|*.*";
                                sfd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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
                                    if (psswBox == null)
                                        return;
                                    switch (EncryptDecryptModel_O.EnDeAction)
                                    {
                                        case EDAction.Encrypt:
                                            var fileTransactionResult = _fileTransactionService.SaveProcessedFile((EncryptDecryptModel_O.SourceFilePath.ToString(), EncryptDecryptModel_O.DestinationFilePath.ToString()), true, psswBox);
                                            if (fileTransactionResult.isSuccesful == false)
                                                MessageBox.Show(fileTransactionResult.msg, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);                                  
                                            break;
                                        case EDAction.Decrypt:
                                            fileTransactionResult = _fileTransactionService.SaveProcessedFile((EncryptDecryptModel_O.SourceFilePath.ToString(), EncryptDecryptModel_O.DestinationFilePath.ToString()), false, psswBox);
                                            if (fileTransactionResult.isSuccesful == false)
                                                MessageBox.Show(fileTransactionResult.msg, "ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                                            break;
                                        case EDAction.ShaFile:
                                            EncryptDecryptModel_O.HashValue = _shaService.ComputeFileHashSHA256(EncryptDecryptModel_O.SourceFilePath.ToString());
                                            break;
                                        case EDAction.MDFile:
                                            EncryptDecryptModel_O.HashValue = _shaService.ComputeMD5Hash(EncryptDecryptModel_O.SourceFilePath.ToString());
                                            break;
                                            default:
                                            MessageBox.Show("WRONG OPERATION!","ERROR!", MessageBoxButton.OK, MessageBoxImage.Error);
                                            break;
                                    }
                                    EncryptDecryptModel_O.Reset(false);
                                    psswBox.Password = "";
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
