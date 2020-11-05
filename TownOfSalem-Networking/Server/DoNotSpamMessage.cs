using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class DoNotSpamMessage : BaseMessage
    {
        public int SpamType;

        public DoNotSpamMessage(int spamType) : base(MessageType.DoNotSpam)
        {
            SpamType = spamType;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)SpamType);
        }
    }
}