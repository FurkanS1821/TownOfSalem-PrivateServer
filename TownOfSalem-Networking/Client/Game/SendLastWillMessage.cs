using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendLastWillMessage : BaseMessage
    {
        public string LastWill;

        public SendLastWillMessage(byte[] data) : base(data)
        {
            try
            {
                LastWill = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
