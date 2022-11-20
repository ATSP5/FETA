using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FETA.Services
{
    public interface IFileTransactionService
    {
        (bool isSuccesful, string msg) SaveProcessedFile((string source, string destination)Resource, bool encrypt, PasswordBox passwordBox);
    }
    public class FileTransactionService : IFileTransactionService
    {
        private IAESService _aESService;
        public FileTransactionService()
        {
            _aESService = new AESService();
        }

        public (bool isSuccesful, string msg) SaveProcessedFile((string source, string destination)Resource, bool encrypt, PasswordBox passwordBox)
        {
            (bool isSuccesful, string msg) Result = new() { isSuccesful = false, msg = "" };



            return Result;
        }
    }
}
