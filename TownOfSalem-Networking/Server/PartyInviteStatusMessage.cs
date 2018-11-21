using System;

namespace TownOfSalem_Networking.Server
{
    public class PartyInviteStatusMessage : BaseMessage
    {
        public readonly PartyMemberInviteStatus Status;
        public readonly string Username;

        public PartyInviteStatusMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split('*');
                Username = strArray[0];
                if (strArray.Length <= 0)
                {
                    return;
                }

                var nullable = TryParseNullable(strArray[1]);
                if (!nullable.HasValue)
                {
                    return;
                }

                Status = (PartyMemberInviteStatus) nullable.Value;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }

        public static int? TryParseNullable(string val)
        {
            int result;
            if (int.TryParse(val, out result))
            {
                return result;
            }

            return null;
        }
    }
}
