using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteFailedMessage : BaseMessage
    {
        private Dictionary<string, PartyMemberInviteStatus> _lookup = new Dictionary<string, PartyMemberInviteStatus>
        {
            {"1", PartyMemberInviteStatus.Locale},
            {"3", PartyMemberInviteStatus.NoCoven}
        };

        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PartyInviteFailedMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                Username = strArray[0];
                if (strArray.Length <= 0)
                {
                    return;
                }

                Status = PartyMemberInviteStatus.Failed;
                if (!_lookup.ContainsKey(strArray[1]))
                {
                    return;
                }

                Status = _lookup[strArray[1]];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
