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
        (bool isSuccesful, string msg, byte[] secretText) Encrypt(string plainText, string Key);
        (bool isSuccesful, string msg, string plainText) Decrypt(byte[] secretText, string Key);
    }
    public class AESService : IAESService
    {
        public (bool isSuccesful, string msg, byte[] secretText) Encrypt(string plainText, string Key)
        {
            (bool isSuccesful, string msg, byte[] secretText) Result = new() { isSuccesful = false, msg = "", secretText = null };
            try
            {
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    aes.BlockSize = 256;
                    aes.KeySize = 16;
                    Result.secretText = EncryptRoutine(plainText,Adjust(Key, aes.KeySize), aes.IV);
                    Result.isSuccesful = true;
                    Result.msg = "OK";
                }
            }
            catch (Exception exp)
            {
                Result.isSuccesful =false;
                Result.msg = exp.Message;
            }
            return Result;
        }

        public (bool isSuccesful, string msg, string plainText) Decrypt(byte[] secretText, string Key)
        {
            (bool isSuccesful, string msg, string plainText) Result = new() { isSuccesful = false, msg = "", plainText = "" };
            try
            {
                using (AesManaged aes = new AesManaged())
                {
                    // Encrypt string    
                    aes.BlockSize = 256;
                    aes.KeySize = 16;
                    Result.plainText= DecryptRoutine(secretText,Adjust(Key, aes.KeySize), aes.IV);
                    Result.isSuccesful = true;
                    Result.msg = "OK";
                }
            }
            catch (Exception exp)
            {
                Result.isSuccesful = false;
                Result.msg = exp.Message;
            }
            return Result;
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

       private byte [] Adjust(string value, int length)
        {
            byte[] buffer = new byte[length];
            for(int i = 0; i < length; i++)
            {
                if(value[i] != 0)
                {
                    buffer[i] = (byte)value[i];
                }
                else
                {
                    buffer[i] = (byte)value[i%value.Length];
                }
            }
            return buffer;
        }
    }
}
