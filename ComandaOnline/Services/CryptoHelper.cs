using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public class CryptoHelper
{
    private static readonly string key = "aaaaaaaaaaaaakkk";// Deve ter 16, 24 ou 32 caracteres para AES

    public static string Encrypt(string plainText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[16];// Vetor de inicialização (IV) com 16 bytes

            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    using (StreamWriter streamWriter = new StreamWriter(cryptoStream)) { streamWriter.Write(plainText); }
                }

                return Convert.ToBase64String(memoryStream.ToArray());
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        using (Aes aes = Aes.Create())
        {
            aes.Key = Encoding.UTF8.GetBytes(key);
            aes.IV = new byte[16];// Vetor de inicialização (IV) com 16 bytes

            using (MemoryStream memoryStream = new MemoryStream(Convert.FromBase64String(cipherText)))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    using (StreamReader streamReader = new StreamReader(cryptoStream)) { return streamReader.ReadToEnd(); }
                }
            }
        }
    }
}
