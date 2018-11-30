using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class WhoDiedAndHowMessage : BaseMessage
    {
        public readonly List<int> How;
        public readonly int Position;
        public readonly int Role;
        public readonly bool WasLynched;

        public WhoDiedAndHowMessage(List<int> how, int position, int role, bool wasLynched)
            : base(MessageType.WhoDiedAndHow)
        {
            How = how;
            Position = position;
            Role = role;
            WasLynched = wasLynched;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(Role + 1));
            writer.Write((byte)(WasLynched ? 2 : 0));

            foreach (var how in How)
            {
                writer.Write((byte)how);
            }
        }
    }
}
