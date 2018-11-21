using System;

namespace TownOfSalem_Networking.Server
{
    public class PartyMemberKickedMessage : BaseMessage
    {
        public readonly string Username;

        public PartyMemberKickedMessage(byte[] data) : base(data)
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
