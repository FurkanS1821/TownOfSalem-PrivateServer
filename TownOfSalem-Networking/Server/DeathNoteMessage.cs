using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class DeathNoteMessage : BaseMessage
    {
        public readonly int Position;
        public readonly bool HasLastWill;
        public readonly string DeathNote;

        public DeathNoteMessage(int position, bool hasLastWill, string deathNote) : base(MessageType.DeathNote)
        {
            Position = position;
            HasLastWill = hasLastWill;
            DeathNote = deathNote;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(HasLastWill ? 2 : 0));
            writer.Write(Encoding.UTF8.GetBytes(DeathNote));
        }
    }
}
