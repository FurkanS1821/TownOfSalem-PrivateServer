using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class ServerFlagsMessage : BaseMessage
    {
        public bool[] Flags;

        public ServerFlagsMessage(params bool[] flags) : base(MessageType.ServerFlags)
        {
            Flags = flags;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var flag in Flags)
            {
                writer.Write((byte)(flag ? 2 : 1));
            }
        }
    }
}
