using System;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyGiveInvitePrivilegesMessage : BaseMessage
    {
        public string Username;

        public PartyGiveInvitePrivilegesMessage(byte[] data) : base(data)
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