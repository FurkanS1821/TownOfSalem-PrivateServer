using System;

namespace TownOfSalem_Networking.Server
{
    public class PendingPartyInviteStatusMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PendingPartyInviteStatusMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                Username = strArray[0];
                if (strArray.Length <= 0)
                {
                    return;
                }

                Status = (PartyMemberInviteStatus)strArray[1][0];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
