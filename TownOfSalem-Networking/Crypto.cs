using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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

        public static byte[] AesDecrypt(byte[] toDecrypt, byte[] key, byte[] iv)
        {
            if (toDecrypt == null || toDecrypt.Length <= 0)
            {
                throw new ArgumentNullException(nameof(toDecrypt));
            }

            if (key == null || key.Length <= 0)
            {
                throw new ArgumentNullException(nameof(key));
            }

            if (iv == null || iv.Length <= 0)
            {
                throw new ArgumentNullException(nameof(iv));
            }

            using (var aesManaged = new AesManaged())
            {
                aesManaged.Key = key;
                aesManaged.IV = iv;
                aesManaged.Mode = CipherMode.CBC;
                var decryptor = aesManaged.CreateDecryptor(aesManaged.Key, aesManaged.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Write))
                    {
                        using (var binaryWriter = new BinaryWriter(cryptoStream))
                        {
                            binaryWriter.Write(toDecrypt);
                        }

                        return memoryStream.ToArray();
                    }
                }
            }
        }

        public static string CreateMd5(string input)
        {
            using (var md5 = MD5.Create())
            {
                var inputBytes = Encoding.ASCII.GetBytes(input);
                var hashBytes = md5.ComputeHash(inputBytes);

                var str = hashBytes.Aggregate("", (current, t) => current + t.ToString("X2"));
                return str;
            }
        }

        /// <param name="passwordStored">md5(pw)</param>
        /// <param name="passwordSent">base64(rsa(pw))</param>
        public static bool VerifyPassword(string passwordStored, string passwordSent)
        {
            try
            {
                var passwordSentDecrypted = PrivateKeyDecrypt(Convert.FromBase64String(passwordSent)); // base64(pw)
                var passwordSentString = Encoding.UTF8.GetString(Convert.FromBase64String(passwordSentDecrypted)); // raw(pw)
                var passwordSentMd5 = CreateMd5(passwordSentString); // md5(pw)

                return passwordStored.Equals(passwordSentMd5, StringComparison.InvariantCultureIgnoreCase);
            }
            catch (CryptographicException)
            {
                Console.WriteLine("The client seems to have wrong RSA key.");
                // return false;
                return true; // for testing
            }
        }
    }
}
