using System;
using System.Collections.Generic;
using System.IO;
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
            try
            {
                _aESService.SetKey(passwordBox.Password);
                if (encrypt == true)
                {
                    var encryptionResult = _aESService.Encrypt(Resource.source);
                    File.WriteAllText(Resource.destination, Encoding.Unicode.GetString(encryptionResult));
                   
                }
                else
                {
                    var decryptionResult = _aESService.Decrypt(Encoding.Unicode.GetBytes(File.ReadAllText(Resource.source)));
                    File.WriteAllText(Resource.destination, decryptionResult);
                }
                Result.isSuccesful=true;
                Result.msg = "OK";
            }
            catch (Exception ex)
            {
                Result.isSuccesful = false;
                Result.msg += ex.Message;

            }
          
            

            return Result;
        }
    }
}
