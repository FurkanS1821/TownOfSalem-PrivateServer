using System;

namespace TownOfSalem_Networking.Server
{
    public class AcceptedPartyInviteMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;

        public AcceptedPartyInviteMessage(byte[] data) : base(data)
        {
            try
            {
                Status = (PartyMemberInviteStatus) Convert.ToByte(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
