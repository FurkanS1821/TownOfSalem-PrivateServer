using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendJailorDeathNoteMessage : BaseMessage
    {
        public string DeathNote;

        public SendJailorDeathNoteMessage(byte[] data) : base(data)
        {
            try
            {
                DeathNote = Convert.ToString(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
