using System;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public abstract class BaseMessage
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
    }
}
