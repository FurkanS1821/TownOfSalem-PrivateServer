using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client
{
    public abstract class BaseMessage
    {
        public byte[] RawData;
        public readonly int MessageType;

        public BaseMessage(byte[] data)
        {
            RawData = data;
            MessageType = data[0];

            try
            {
                var jsonString = BytesToString(RawData, 1);
                var message = JsonConvert.DeserializeObject<EncryptedMessage>(jsonString);

                var key = Crypto.PrivateKeyDecrypt(message.Key);
                var iv = Convert.FromBase64String(message.IV);
                var decryptedArray = Crypto.AesDecrypt(
                    Encoding.UTF8.GetBytes(message.Payload),
                    Encoding.UTF8.GetBytes(key),
                    iv
                );

                var list = new List<byte> {RawData[0]};
                list.AddRange(decryptedArray);
                RawData = list.ToArray();
            }
            catch
            {
                // packet wasn't encrypted
            }
        }

        protected bool GetBoolValue(byte b)
        {
            return b == 2;
        }

        protected bool GetBoolValue(char c)
        {
            return GetBoolValue(Convert.ToByte(c));
        }

        protected bool GetBoolValue(string c)
        {
            return GetBoolValue(Convert.ToByte(c));
        }

        protected string BytesToString(byte[] data, int offset = 0, int length = -1)
        {
            return Encoding.UTF8.GetString(data, offset, length == -1 ? data.Length - offset : length);
        }

        protected void ThrowNetworkMessageFormatException(Exception e)
        {
            throw new Exception($"Message {MessageType}: Unable to parse message \"{RawData}\"({ToString()})", e);
        }

        [JsonObject]
        private class EncryptedMessage
        {
            [JsonProperty("key")]
            public string Key;
            [JsonProperty("iv")]
            public string IV;
            [JsonProperty("payload")]
            public string Payload;
        }
    }

    /*public abstract class BaseMessage
    {
        protected bool IsEncrypted;
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
                if (IsEncrypted)
                {
                    var encryptedMessage = new EncryptedMessage();
                    var memoryStream2 = new MemoryStream();
                    using (var writer2 = new BinaryWriter(memoryStream2))
                    {
                        SerializeData(writer2);
                    }

                    Debug.Write($"Payload : {Encoding.UTF8.GetString(memoryStream2.ToArray())}");
                    using (var aesManaged = new AesManaged())
                    {
                        aesManaged.KeySize = 256;
                        aesManaged.GenerateKey();
                        aesManaged.GenerateIV();
                        encryptedMessage.Key = Crypto.PublicKeyEncrypt(aesManaged.Key);
                        encryptedMessage.IV = Convert.ToBase64String(aesManaged.IV);
                        encryptedMessage.Payload = Convert.ToBase64String(Crypto.AESEncrypt(
                                memoryStream2.ToArray(),
                                aesManaged.Key,
                                aesManaged.IV
                        ));
                    }

                    Debug.Write($"Envelope : {encryptedMessage.ToJson()}");
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
        }
    }*/
}
