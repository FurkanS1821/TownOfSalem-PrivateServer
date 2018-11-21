using System;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json.Linq;

namespace TownOfSalem_Networking.Client
{
    public abstract class BaseMessage
    {
        protected bool _isEncrypted;
        public readonly MessageType MessageId;

        public BaseMessage(MessageType messageId)
        {
            MessageId = messageId;
        }

        protected virtual void SerializeData(BinaryWriter writer)
        {
        }

        public byte[] Serialize()
        {
            var memoryStream1 = new MemoryStream();
            using (var writer1 = new BinaryWriter(memoryStream1))
            {
                writer1.Write((byte)MessageId);
                if (_isEncrypted)
                {
                    var encryptedMessage = new EncryptedMessage();
                    var memoryStream2 = new MemoryStream();
                    using (var writer2 = new BinaryWriter(memoryStream2))
                    {
                        SerializeData(writer2);
                    }

                    Debug.Write($"Payload: {Encoding.UTF8.GetString(memoryStream2.ToArray())}");

                    using (var aesManaged = new AesManaged {KeySize = 256})
                    {
                        aesManaged.GenerateKey();
                        aesManaged.GenerateIV();
                        encryptedMessage.Key = Crypto.PublicKeyEncrypt(aesManaged.Key);
                        encryptedMessage.IV = Convert.ToBase64String(aesManaged.IV);
                        encryptedMessage.Payload = Convert.ToBase64String(
                            Crypto.AESEncrypt(memoryStream2.ToArray(), aesManaged.Key, aesManaged.IV)
                        );
                    }

                    Debug.Write($"Envelope: {encryptedMessage.ToJson()}");
                    writer1.Write(encryptedMessage.ToJson().ToCharArray());
                }
                else
                {
                    SerializeData(writer1);
                }

                writer1.Write((byte)0);
            }

            return memoryStream1.ToArray();
        }

        public override string ToString()
        {
            return BitConverter.ToString(Serialize()).Replace("-", string.Empty);
        }

        private class EncryptedMessage
        {
            public string Key;
            public string IV;
            public string Payload;

            public string ToJson()
            {
                var json = new JObject
                {
                    {"key", Key},
                    {"iv", IV},
                    {"payload", Payload}
                };

                return json.ToString();
            }
        }
    }
}
