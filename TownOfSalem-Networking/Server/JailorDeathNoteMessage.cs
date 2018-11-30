using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class JailorDeathNoteMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly int Choice;

        public JailorDeathNoteMessage(int position, bool hasLastWill, int choice) : base(MessageType.JailorDeathNote)
        {
            Position = position;
            HasLastWill = hasLastWill;
            Choice = choice;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(HasLastWill ? 2 : 0));
            writer.Write((byte)(Choice + 1));
        }
    }
}
