using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendForgedWillMessage : BaseMessage
    {
        public string Will;

        public SendForgedWillMessage(byte[] data) : base(data)
        {
            try
            {
                Will = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
