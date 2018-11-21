using System;

namespace TownOfSalem_Networking.Server
{
    public class ReferAFriendUpdateMessage : BaseMessage
    {
        public readonly int AwardType;
        public readonly int TownPointsAwarded;

        public ReferAFriendUpdateMessage(byte[] data) : base(data)
        {
            try
            {
                AwardType = data[1];
                if (AwardType >= 5)
                {
                    return;
                }

                var s = BytesToString(data, 2);
                if (string.IsNullOrEmpty(s))
                {
                    return;
                }

                int.TryParse(s, out TownPointsAwarded);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
