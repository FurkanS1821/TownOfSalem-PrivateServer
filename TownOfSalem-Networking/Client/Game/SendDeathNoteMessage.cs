using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendDeathNoteMessage : BaseMessage
    {
        public string DeathNode;

        public SendDeathNoteMessage(string deathNote) : base(MessageType.SendDeathNote)
        {
            DeathNode = deathNote;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(DeathNode));
        }
    }
}
