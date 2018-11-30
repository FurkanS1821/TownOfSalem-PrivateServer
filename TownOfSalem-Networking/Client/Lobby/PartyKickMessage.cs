using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyKickMessage : BaseMessage
    {
        public string Username;

        public PartyKickMessage(byte[] data) : base(data)
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
