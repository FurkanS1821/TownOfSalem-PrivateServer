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

                if (message == null)
                {
                    throw new JsonReaderException();
                }

                var key = Crypto.PrivateKeyDecrypt(message.Key);
                var iv = Convert.FromBase64String(message.IV);
                var decryptedArray = Crypto.AesDecrypt(
                    Encoding.UTF8.GetBytes(message.Payload),
                    Convert.FromBase64String(key),
                    iv
                );

                var list = new List<byte> {RawData[0]};
                list.AddRange(decryptedArray);
                RawData = list.ToArray();
            }
            catch (Exception)
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
