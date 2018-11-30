using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class SpyNightInfoMessage : BaseMessage
    {
        public readonly int[] SpyMessageIds;

        public SpyNightInfoMessage(int[] spyMessageIds) : base(MessageType.SpyNightInfo)
        {
            SpyMessageIds = spyMessageIds;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var messageId in SpyMessageIds)
            {
                writer.Write((byte)(messageId + 1));
            }
        }
    }
}
