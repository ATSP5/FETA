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
        void SetKey(string key);
        void SetZeroKey();
        byte[] Encrypt(string plainText);
        string Decrypt(byte[] cipherText);
        void EncryptFile(string sourcePath, string destPath);

        void DecryptFile(string sourcePath, string destPath);
    }
    public class AESService : IAESService
    {
        private PaddingMode _paddingMode;
        public AESService()
        {
            AESKEY = APaes.Key;
            AESIV = APaes.IV;
            IsKeySet = false;
            _paddingMode = PaddingMode.Zeros;
        }
        private byte[] AESKEY;
        private byte[] AESIV;
        AesManaged APaes = new AesManaged();
        bool IsKeySet;
        public bool _isKeySet
        {
            get { return IsKeySet; }
            private set { IsKeySet = value; }
        }

        public void SetZeroKey()
        {
            for (int i = 0; i < 32; i++)
            {
                AESKEY[i] = 0;
            }
            for (int i = 0; i < 16; i++)
            {
                AESIV[i] = 0;
            }
            IsKeySet = false;
        }
        public void SetKey(string key)
        {
            byte[] fullkey = Encoding.UTF8.GetBytes(key);
            if (fullkey.Length < 32)
            {
                for (int i = 0; i < 32; i++)
                {
                    AESKEY[i] = fullkey[i % fullkey.Length];
                }
                for (int i = 0; i < 16; i++)
                {
                    AESIV[i] = AESKEY[i];
                }
            }
            if (fullkey.Length > 32)
            {
                for (int i = 0; i < 32; i++)
                {
                    AESKEY[i] = fullkey[i];
                }
                for (int i = 0; i < 16; i++)
                {
                    AESIV[i] = AESKEY[i];
                }
            }
            if (fullkey.Length == 32)
            {
                AESKEY = fullkey;
                for (int i = 0; i < 16; i++)
                {
                    AESIV[i] = AESKEY[i];
                }
            }
            IsKeySet = true;
        }

        public byte[] Encrypt(string plainText)
        {
            byte[] encrypted;
            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                aes.Padding = _paddingMode;
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(AESKEY, AESIV);
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

        public string Decrypt(byte[] cipherText)
        {
            string plaintext = null;
            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                aes.Padding = _paddingMode;
                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(AESKEY, AESIV);
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
            return plaintext.Replace("\0", string.Empty);
        }


        public void EncryptFile(string sourcePath, string destPath)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = AESKEY;
                aes.GenerateIV(); // Generate a random IV for encryption.

                using (FileStream inputStream = File.OpenRead(sourcePath))
                using (FileStream outputStream = File.Create(destPath))
                {
                    // Write IV to the output file
                    outputStream.Write(aes.IV, 0, aes.IV.Length);

                    using (CryptoStream cryptoStream = new CryptoStream(outputStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        // Encrypt the file
                        inputStream.CopyTo(cryptoStream);
                    }
                }
            }
        }

        public void DecryptFile(string sourcePath, string destPath)
        {
            using (Aes aes = Aes.Create())
            {
                aes.Key = AESKEY;

                using (FileStream inputStream = File.OpenRead(sourcePath))
                using (FileStream outputStream = File.Create(destPath))
                {
                    // Read IV from the input file
                    byte[] iv = new byte[16];
                    inputStream.Read(iv, 0, iv.Length);
                    aes.IV = iv;

                    using (CryptoStream cryptoStream = new CryptoStream(inputStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        // Decrypt the file
                        cryptoStream.CopyTo(outputStream);
                    }
                }
            }
        }

    }
}
