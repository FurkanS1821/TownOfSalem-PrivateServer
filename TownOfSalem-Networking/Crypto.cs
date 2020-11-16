using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using BCrypt.Net;
using PemUtils;

namespace TownOfSalem_Networking
{
    public class Crypto
    {
        private static RSACryptoServiceProvider _rsaService;

        static Crypto()
        {
            if (!File.Exists("Private Key.pem"))
            {
                Console.WriteLine("No \"Private Key.pem\" file not found. Press any key to exit.");
                Console.ReadKey(true);
                Environment.Exit(-1);
            }

            using (var fs = new FileStream("Private Key.pem", FileMode.Open))
            {
                using (var reader = new PemReader(fs))
                {
                    _rsaService = new RSACryptoServiceProvider();
                    _rsaService.ImportParameters(reader.ReadRsaKey());
                }
            }
        }

        public static string PrivateKeyDecrypt(string data)
        {
            return PrivateKeyDecrypt(Encoding.UTF8.GetBytes(data));
        }

        public static string PrivateKeyDecrypt(byte[] data)
        {
            return Convert.ToBase64String(_rsaService.Decrypt(data, false));
        }

        public static string AesDecrypt(byte[] cipherText, byte[] key, byte[] iv)
        {
            if (cipherText == null || cipherText.Length == 0)
            {
                throw new ArgumentNullException(nameof(cipherText));
            }

            if (key == null || key.Length == 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv == null || iv.Length == 0)
            {
                throw new ArgumentNullException(nameof(iv));
            }

            string result;
            using (var aesManaged = new AesManaged())
            {
                aesManaged.Key = key;
                aesManaged.IV = iv;
                aesManaged.Mode = CipherMode.CBC;
                var decryptor = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV);
                using (var memoryStream = new MemoryStream(cipherText))
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                    {
                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            result = streamReader.ReadToEnd();
                        }
                    }
                }
            }

            return result;
        }

        /// <param name="passwordStored">bcrypt(pw)</param>
		/// <param name="passwordSent">base64(rsa(pw))</param>
		public static bool VerifyPassword(string passwordStored, string passwordSent)
        {
            try
            {
                return BCrypt.Net.BCrypt.EnhancedVerify(passwordSent, passwordStored, HashType.SHA512);
            }
            catch (CryptographicException)
            {
                Console.WriteLine("The client seems to have wrong RSA key.");
                return false;
            }
        }
    }
}
