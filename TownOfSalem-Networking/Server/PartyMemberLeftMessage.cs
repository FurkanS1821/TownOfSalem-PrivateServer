using System;

namespace TownOfSalem_Networking.Server
{
    public class PartyMemberLeftMessage : BaseMessage
    {
        public readonly string Username;

        public PartyMemberLeftMessage(byte[] data) : base(data)
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
