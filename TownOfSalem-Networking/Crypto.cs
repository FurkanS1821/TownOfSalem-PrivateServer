using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TownOfSalem_Networking
{
    public class Crypto
    {
        private static string _publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAziIxzMIz7ZX4KG5317SmVeCt9SYIe/+qL3hqP5NUX0i1iTmD7x9hFR8YoOHdAqdCJ3dxi3npkIsO6Eoz0l3eH7R99DX16vbnBCyvA3Hkb1B/0nBwOe6mCq73vBdRgfHU8TOF9KtUOx5CVqR50U7MtKqqc6M19OZXZuZSDlGLfiboY99YV2uH3dXysFhzexCZWpmA443eV5ismvj3NyxvRk/4ushZV50vrDjYiInNEj4ICbTNXQULFs6Aahmt6qmibEC6bRl0S4TZRtzuk2a3TpinLJooDTt9s5BvRRh8DLFZWrkWojgrzS0sSNcNzPAXYFyTOYEovWWKW7TgUYfAdwIDAQAB";

        public static string PublicKeyEncrypt(string data)
        {
            return PublicKeyEncrypt(_publicKey, data);
        }

        public static string PublicKeyEncrypt(byte[] data)
        {
            return PublicKeyEncrypt(_publicKey, data);
        }

        public static string PublicKeyEncrypt(string publicKey, string data)
        {
            return PublicKeyEncrypt(publicKey, Encoding.UTF8.GetBytes(data));
        }

        public static string PublicKeyEncrypt(string publicKey, byte[] data)
        {
            return Convert.ToBase64String(DecodeX509PublicKey(Convert.FromBase64String(publicKey)).Encrypt(data, false));
        }

        public static bool PublicKeyVerify(string publicKey, byte[] data, string sig)
        {
            var cryptoServiceProvider = DecodeX509PublicKey(Convert.FromBase64String(publicKey));
            var signature = Convert.FromBase64String(sig);
            var shA1 = SHA1.Create();
            return cryptoServiceProvider.VerifyData(data, shA1, signature);
        }

        public static bool PublicKeyVerify(string publicKey, string data, string sig)
        {
            return PublicKeyVerify(publicKey, Encoding.UTF8.GetBytes(data), sig);
        }

        protected static RSACryptoServiceProvider DecodeX509PublicKey(byte[] x509Key)
        {
            byte[] b = { 0x30, 0xD, 0x6, 0x9, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0xD, 0x1, 0x1, 0x1, 0x5, 0x0 };
            var binaryReader = new BinaryReader(new MemoryStream(x509Key));
            try
            {
                switch (binaryReader.ReadUInt16())
                {
                    case 0x8130:
                        binaryReader.ReadByte();
                        break;
                    case 0x8230:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                if (!CompareByteArrays(binaryReader.ReadBytes(15), b))
                {
                    return null;
                }

                switch (binaryReader.ReadUInt16())
                {
                    case 0x8103:
                        binaryReader.ReadByte();
                        break;
                    case 0x8203:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                if (binaryReader.ReadByte() != 0)
                {
                    return null;
                }

                switch (binaryReader.ReadUInt16())
                {
                    case 0x8130:
                        binaryReader.ReadByte();
                        break;
                    case 0x8230:
                        binaryReader.ReadInt16();
                        break;
                    default:
                        return null;
                }

                var num7 = binaryReader.ReadUInt16();
                byte num8 = 0;
                byte num9;
                switch (num7)
                {
                    case 0x8102:
                        num9 = binaryReader.ReadByte();
                        break;
                    case 0x8202:
                        num8 = binaryReader.ReadByte();
                        num9 = binaryReader.ReadByte();
                        break;
                    default:
                        return null;
                }

                var int32 = BitConverter.ToInt32(new byte[] { num9, num8, 0x0, 0x0 }, 0);
                var num10 = binaryReader.ReadByte();
                binaryReader.BaseStream.Seek(-1L, SeekOrigin.Current);
                if (num10 == 0)
                {
                    binaryReader.ReadByte();
                    --int32;
                }

                var numArray2 = binaryReader.ReadBytes(int32);
                if (binaryReader.ReadByte() != 2)
                {
                    return null;
                }
                int count = binaryReader.ReadByte();
                var numArray3 = binaryReader.ReadBytes(count);
                var cryptoServiceProvider = new RSACryptoServiceProvider();
                cryptoServiceProvider.ImportParameters(new RSAParameters
                {
                    Modulus = numArray2,
                    Exponent = numArray3
                });
                return cryptoServiceProvider;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binaryReader.Close();
            }
        }

        public static byte[] AESEncrypt(byte[] plainText, byte[] key, byte[] iv)
        {
            if (plainText == null || plainText.Length <= 0)
            {
                throw new ArgumentNullException(nameof(plainText));
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

                var encryptor = aesManaged.CreateEncryptor(aesManaged.Key, aesManaged.IV);
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                    {
                        using (var binaryWriter = new BinaryWriter(cryptoStream))
                        {
                            binaryWriter.Write(plainText);
                        }

                        return memoryStream.ToArray();
                    }
                }
            }
        }

        private static bool CompareByteArrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }

            var index = 0;
            foreach (int num in a)
            {
                if (num != b[index])
                {
                    return false;
                }

                ++index;
            }

            return true;
        }
    }
}
