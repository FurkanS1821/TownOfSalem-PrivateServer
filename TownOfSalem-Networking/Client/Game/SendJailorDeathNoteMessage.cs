using System;
using System.IO;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendJailorDeathNoteMessage : BaseMessage
    {
        public string DeathNote;

        public SendJailorDeathNoteMessage(string deathNote) : base(MessageType.JailorDeathNote)
        {
            DeathNote = deathNote;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Convert.ToByte(DeathNote));
        }
    }
}
