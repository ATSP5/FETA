using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Services
{
    public interface IAESService
    {
        (bool isSuccesful, string msg, byte[] result) Encrypt(string plainText, string Key);
        (bool IsSuccesful, string msg, byte[]) Decrypt(byte[] plainText, string Key);
    }
    public class AESService : IAESService
    {
        public (bool isSuccesful, string msg, byte[] result) Encrypt(string plainText, string Key)
        {
            (bool isSuccesful, string msg, byte[] result) Result = new() { isSuccesful = false, msg = "", result = null };
            try
            {
                // Create Aes that generates a new key and initialization vector (IV).    
                // Same key must be used in encryption and decryption    
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    byte[] encrypted = EncryptRoutine(plainText, aes.Key, aes.IV);
                    // Print encrypted string    
                    //Console.WriteLine($ "Encrypted data: {System.Text.Encoding.UTF8.GetString(encrypted)}");
                }
            }
            catch (Exception exp)
            {
                //Console.WriteLine(exp.Message);
            }
            return Result;
        }

        public (bool IsSuccesful, string msg, byte[]) Decrypt(byte[] plainText, string Key)
        {
            throw new NotImplementedException();
        }
        private byte[] EncryptRoutine(string plainText, byte[] Key, byte[] IV)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(Key, IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(plainText);
                        encrypted = ms.ToArray();
                    }
                }
            }
            // Return encrypted data    
            return encrypted;
        }
        private string DecryptRoutine(byte[] cipherText, byte[] Key, byte[] IV)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(Key, IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }

       
    }
}
