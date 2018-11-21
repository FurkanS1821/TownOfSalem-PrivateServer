using System;

namespace TownOfSalem_Networking.Server
{
    public class FacebookShareAchievementMessage : BaseMessage
    {
        public readonly int AchievementId;

        public FacebookShareAchievementMessage(byte[] data) : base(data)
        {
            try
            {
                AchievementId = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
