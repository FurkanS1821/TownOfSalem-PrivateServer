using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace TownOfSalem_Networking
{
    public class Crypto
    {
        private static string _publicKey = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAziIxzMIz7ZX4KG5317SmVeCt9SYIe/+qL3hqP5NUX0i1iTmD7x9hFR8YoOHdAqdCJ3dxi3npkIsO6Eoz0l3eH7R99DX16vbnBCyvA3Hkb1B/0nBwOe6mCq73vBdRgfHU8TOF9KtUOx5CVqR50U7MtKqqc6M19OZXZuZSDlGLfiboY99YV2uH3dXysFhzexCZWpmA443eV5ismvj3NyxvRk/4ushZV50vrDjYiInNEj4ICbTNXQULFs6Aahmt6qmibEC6bRl0S4TZRtzuk2a3TpinLJooDTt9s5BvRRh8DLFZWrkWojgrzS0sSNcNzPAXYFyTOYEovWWKW7TgUYfAdwIDAQAB";
        private static string _privateKey = "";

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

        public static string PrivateKeyDecrypt(string data)
        {
            return PrivateKeyDecrypt(_privateKey, data);
        }

        public static string PrivateKeyDecrypt(byte[] data)
        {
            return PrivateKeyDecrypt(_privateKey, data);
        }

        public static string PrivateKeyDecrypt(string privateKey, string data)
        {
            return PrivateKeyDecrypt(privateKey, Encoding.UTF8.GetBytes(data));
        }

        public static string PrivateKeyDecrypt(string privateKey, byte[] data)
        {
            return Convert.ToBase64String(DecodeRSAPrivateKey(Convert.FromBase64String(privateKey))
                .Decrypt(data, false));
        }

        public static bool PublicKeyVerify(string publicKey, byte[] data, string sig)
        {
            var cryptoServiceProvider = DecodeX509PublicKey(Convert.FromBase64String(publicKey));
            var signature = Convert.FromBase64String(sig);
            var sha1 = SHA1.Create();
            return cryptoServiceProvider.VerifyData(data, sha1, signature);
        }

        public static bool PublicKeyVerify(string publicKey, string data, string sig)
        {
            return PublicKeyVerify(publicKey, Encoding.UTF8.GetBytes(data), sig);
        }

        protected static RSACryptoServiceProvider DecodeX509PublicKey(byte[] x509key)
        {
            // encoded OID sequence for PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            var seq = new byte[15];
            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            var mem = new MemoryStream(x509key);
            var binr = new BinaryReader(mem);    //wrap Memory Stream with BinaryReader for easy reading
            byte bt;
            ushort twobytes;

            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                {
                    binr.ReadByte(); //advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16(); //advance 2 bytes
                }
                else
                {
                    return null;
                }

                seq = binr.ReadBytes(15); //read the Sequence OID
                if (!seq.SequenceEqual(SeqOID)) //make sure Sequence for OID is correct
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                {
                    binr.ReadByte(); //advance 1 byte
                }
                else if (twobytes == 0x8203)
                {
                    binr.ReadInt16(); //advance 2 bytes
                }
                else
                {
                    return null;
                }

                bt = binr.ReadByte();
                if (bt != 0x00) //expect null byte next
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                {
                    binr.ReadByte(); //advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16(); //advance 2 bytes
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                byte lowbyte;
                byte highbyte = 0x00;

                if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                {
                    lowbyte = binr.ReadByte(); // read next bytes which is bytes in modulus
                }
                else if (twobytes == 0x8202)
                {
                    highbyte = binr.ReadByte(); //advance 2 bytes
                    lowbyte = binr.ReadByte();
                }
                else
                {
                    return null;
                }

                byte[] modint = {lowbyte, highbyte, 0x00, 0x00}; //reverse byte order since asn.1 key uses big endian order
                var modsize = BitConverter.ToInt32(modint, 0);

                var firstbyte = binr.ReadByte();
                binr.BaseStream.Seek(-1, SeekOrigin.Current);

                if (firstbyte == 0x00)
                {
                    //if first byte (highest order) of modulus is zero, don't include it
                    binr.ReadByte(); //skip this null byte
                    modsize -= 1; //reduce modulus buffer size by 1
                }

                var modulus = binr.ReadBytes(modsize); //read the modulus bytes

                if (binr.ReadByte() != 0x02) //expect an Integer for the exponent data
                {
                    return null;
                }

                var expbytes = (int)binr.ReadByte(); // should only need one byte for actual exponent data (for all useful values)
                var exponent = binr.ReadBytes(expbytes);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                var RSA = new RSACryptoServiceProvider();
                var RSAKeyInfo = new RSAParameters
                {
                    Modulus = modulus,
                    Exponent = exponent
                };

                RSA.ImportParameters(RSAKeyInfo);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        //------- Parses binary ans.1 RSA private key; returns RSACryptoServiceProvider  ---
        protected static RSACryptoServiceProvider DecodeRSAPrivateKey(byte[] privkey)
        {
            byte[] MODULUS, E, D, P, Q, DP, DQ, IQ;

            // ---------  Set up stream to decode the asn.1 encoded RSA private key  ------
            var mem = new MemoryStream(privkey);
            var binr = new BinaryReader(mem); //wrap Memory Stream with BinaryReader for easy reading
            byte bt;
            ushort twobytes;
            int elems;
            try
            {
                twobytes = binr.ReadUInt16();
                if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                {
                    binr.ReadByte(); //advance 1 byte
                }
                else if (twobytes == 0x8230)
                {
                    binr.ReadInt16(); //advance 2 bytes
                }
                else
                {
                    return null;
                }

                twobytes = binr.ReadUInt16();
                if (twobytes != 0x0102) //version number
                {
                    return null;
                }

                bt = binr.ReadByte();
                if (bt != 0x00)
                {
                    return null;
                }

                //------  all private key components are Integer sequences ----
                elems = GetIntegerSize(binr);
                MODULUS = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                E = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                D = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                P = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                Q = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DP = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                DQ = binr.ReadBytes(elems);

                elems = GetIntegerSize(binr);
                IQ = binr.ReadBytes(elems);

                // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                var RSA = new RSACryptoServiceProvider();
                var RSAparams = new RSAParameters
                {
                    Modulus = MODULUS,
                    Exponent = E,
                    D = D,
                    P = P,
                    Q = Q,
                    DP = DP,
                    DQ = DQ,
                    InverseQ = IQ
                };

                RSA.ImportParameters(RSAparams);
                return RSA;
            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                binr.Close();
            }
        }

        protected static int GetIntegerSize(BinaryReader binr)
        {
            byte bt;
            byte lowbyte;
            byte highbyte;
            int count;
            bt = binr.ReadByte();
            if (bt != 0x02) //expect integer
            {
                return 0;
            }

            bt = binr.ReadByte();

            if (bt == 0x81)
            {
                count = binr.ReadByte(); // data size in next byte
            }
            else if (bt == 0x82)
            {
                highbyte = binr.ReadByte(); // data size in next 2 bytes
                lowbyte = binr.ReadByte();
                byte[] modint = {lowbyte, highbyte, 0x00, 0x00};
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt; // we already have the data size
            }

            while (binr.ReadByte() == 0x00)
            {
                //remove high order zeros in data
                count -= 1;
            }

            binr.BaseStream.Seek(-1, SeekOrigin.Current); //last ReadByte wasn't a removed zero, so back up a byte
            return count;
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
    }
}
