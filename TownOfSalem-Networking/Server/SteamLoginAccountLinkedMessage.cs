using System;

namespace TownOfSalem_Networking.Server
{
    public class SteamLoginAccountLinkedMessage : BaseMessage
    {
        public readonly string Username;

        public SteamLoginAccountLinkedMessage(byte[] data) : base(data)
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
