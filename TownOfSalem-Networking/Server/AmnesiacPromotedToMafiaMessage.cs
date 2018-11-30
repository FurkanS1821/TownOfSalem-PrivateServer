using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacPromotedToMafiaMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int Role;

        public AmnesiacPromotedToMafiaMessage(int position, int role) : base((MessageType)0) // :thinking: this one is
        {                                                                                    // not in the enum
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
