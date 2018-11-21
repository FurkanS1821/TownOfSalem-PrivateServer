using System;

namespace TownOfSalem_Networking.Server
{
    public class NewPartyHostNotificationMessage : BaseMessage
    {
        public readonly string Username;

        public NewPartyHostNotificationMessage(byte[] data) : base(data)
        {
            try
            {
                Username = BytesToString(data, 1);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
