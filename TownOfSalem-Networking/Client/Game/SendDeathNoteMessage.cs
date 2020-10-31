using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendDeathNoteMessage : BaseMessage
    {
        public string DeathNote;

        public SendDeathNoteMessage(byte[] data) : base(data)
        {
            try
            {
                DeathNote = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}