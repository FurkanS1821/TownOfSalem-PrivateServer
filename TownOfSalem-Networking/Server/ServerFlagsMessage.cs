using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class ServerFlagsMessage : BaseMessage
    {
        public List<bool> Flags;

        public ServerFlagsMessage(List<bool> flags) : base(MessageType.ServerFlags)
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