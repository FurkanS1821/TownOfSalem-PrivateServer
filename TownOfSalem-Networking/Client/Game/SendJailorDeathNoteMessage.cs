using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendJailorDeathNoteMessage : BaseMessage
    {
        public int DeathNote;

        public SendJailorDeathNoteMessage(byte[] data) : base(data)
        {
            try
            {
                DeathNote = data[1] - 1;
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}