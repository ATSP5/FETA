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
        (bool isSuccesful, string msg) SaveProcessedFile((string source, string destination) Resource, (bool encrypt, bool useStringFormat) MetaData, PasswordBox passwordBox);
    }
    public class FileTransactionService : IFileTransactionService
    {
        private IAESService _aESService;
        public FileTransactionService()
        {
            _aESService = new AESService();
        }

        public (bool isSuccesful, string msg) SaveProcessedFile((string source, string destination)Resource, (bool encrypt, bool useStringFormat)MetaData, PasswordBox passwordBox)
        {
            var encoding = Encoding.Unicode;
            (bool isSuccesful, string msg) Result = new() { isSuccesful = false, msg = "" };
            try
            {
                _aESService.SetKey(passwordBox.Password);
                if(MetaData.useStringFormat==true)
                {
                    if (MetaData.encrypt == true)
                    {
                        var textToEncrypt = File.ReadAllText(Resource.source);
                        var encryptionResult = _aESService.Encrypt(textToEncrypt);
                        File.WriteAllText(Resource.destination, encoding.GetString(encryptionResult));

                    }
                    else
                    {
                        var textToDecrypt = File.ReadAllText(Resource.source);
                        var decryptionResult = _aESService.Decrypt(encoding.GetBytes(textToDecrypt));
                        File.WriteAllText(Resource.destination, decryptionResult);
                    }
                }
                else
                {
                    if (MetaData.encrypt == true)
                    {
                        var textToEncrypt = File.ReadAllText(Resource.source);
                        var encryptionResult = _aESService.Encrypt(textToEncrypt);
                        File.WriteAllBytes(Resource.destination, encryptionResult);

                    }
                    else
                    {
                        var textToDecrypt = File.ReadAllBytes(Resource.source);
                        var decryptionResult = _aESService.Decrypt(textToDecrypt);
                        File.WriteAllText(Resource.destination, decryptionResult);
                    }
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
