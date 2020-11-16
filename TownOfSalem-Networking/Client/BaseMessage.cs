using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client
{
    public abstract class BaseMessage
    {
        public byte[] RawData;
        public readonly int MessageType;
        protected bool IsEncrypted;

        public BaseMessage(byte[] data, bool isEncrypted = false)
        {
            RawData = data;
            MessageType = data[0];
            IsEncrypted = isEncrypted;

            if (!IsEncrypted)
            {
                return;
            }

            try
            {
                var jsonString = BytesToString(RawData, 1);
                var message = JsonConvert.DeserializeObject<EncryptedMessage>(jsonString);

                if (message == null)
                {
                    return;
                }

                var cipherText = Convert.FromBase64String(message.Payload);
                var key = Convert.FromBase64String(Crypto.PrivateKeyDecrypt(Convert.FromBase64String(message.Key)));
                var iv = Convert.FromBase64String(message.IV);
                var decryptedArray = Crypto.AesDecrypt(
                    cipherText,
                    key,
                    iv
                );

                var list = new List<byte> {RawData[0]};
                list.AddRange(Encoding.UTF8.GetBytes(decryptedArray));
                RawData = list.ToArray();
            }
            catch (CryptographicException e)
            {
                Console.WriteLine($"CryptographicException while decrypting {GetType().Name} packet: {e.Message}");
                // client public key probably does not match with our private key
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

        protected string BytesToString(byte[] data, int offset = 0)
        {
            return Encoding.UTF8.GetString(data, offset, data.Length - offset);
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
}