using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class ResurrectionMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int Role;

        public ResurrectionMessage(int position, int role) : base(MessageType.Resurrection)
        {
            Position = position;
            Role = role;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(Role + 1));
        }
    }
}
