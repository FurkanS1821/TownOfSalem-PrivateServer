using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyChangeHostMessage : BaseMessage
    {
        public string Username;

        public PartyChangeHostMessage(byte[] data) : base(data)
        {
            try
            {
                Username = BytesToString(data, 1);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}