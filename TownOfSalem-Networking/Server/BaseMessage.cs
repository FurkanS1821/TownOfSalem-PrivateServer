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
}
