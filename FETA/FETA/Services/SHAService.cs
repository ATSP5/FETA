using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace FETA.Services
{
    public interface ISHAService
    {
        string ComputeSha256Hash(string rawData);
        string ComputeFileHashSHA256(string filePath);
        string ComputeMD5Hash(string filePath);
    }
    public class SHAService : ISHAService
    {
        public string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }

        public string ComputeFileHashSHA256(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return "";
            using (SHA256 sha256Hash = SHA256.Create())
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    // Compute the hash for the file stream
                    byte[] hashBytes = sha256Hash.ComputeHash(stream);

                    // Convert the byte array to a hexadecimal string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        builder.Append(hashBytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
        }
        public string ComputeMD5Hash(string filePath)
        {
            if (string.IsNullOrEmpty(filePath))
                return "";
            using (MD5 md5Hash = MD5.Create())
            {
                using (FileStream stream = File.OpenRead(filePath))
                {
                    // Compute the hash for the file stream
                    byte[] hashBytes = md5Hash.ComputeHash(stream);

                    // Convert the byte array to a hexadecimal string
                    StringBuilder builder = new StringBuilder();
                    for (int i = 0; i < hashBytes.Length; i++)
                    {
                        builder.Append(hashBytes[i].ToString("x2"));
                    }

                    return builder.ToString();
                }
            }
        }

    }
}
