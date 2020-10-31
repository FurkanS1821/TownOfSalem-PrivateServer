using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyInviteMessage : BaseMessage
    {
        public string Username;

        public PartyInviteMessage(byte[] data) : base(data)
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