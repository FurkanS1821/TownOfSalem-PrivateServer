using System;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public abstract class BaseMessage
    {
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
            var data = new MemoryStream();
            using (var writer = new BinaryWriter(data))
            {
                writer.Write((byte)MessageId);
                SerializeData(writer);
                writer.Write((byte)0);
            }

            return data.ToArray();
        }

        public override string ToString()
        {
            return BitConverter.ToString(Serialize()).Replace("-", string.Empty);
        }
    }

    /*public abstract class BaseMessage
    {
        public byte[] RawData;
        public readonly int MessageType;

        public BaseMessage(byte[] data)
        {
            RawData = data;
            MessageType = data[0];
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

        public override string ToString()
        {
            return BitConverter.ToString(RawData).Replace("-", string.Empty);
        }

        protected string BytesToString(byte[] data, int offset = 0)
        {
            return Encoding.UTF8.GetString(data, offset, data.Length - offset);
        }

        protected void ThrowNetworkMessageFormatException(Exception e)
        {
            throw new Exception($"Message {MessageType}: Unable to parse message \"{RawData}\"({ToString()})", e);
        }
    }*/
}
