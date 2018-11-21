using System;

namespace TownOfSalem_Networking.Server
{
    public class EarnedAchievementMessage : BaseMessage
    {
        public readonly int Achievement;

        public EarnedAchievementMessage(byte[] data) : base(data)
        {
            try
            {
                Achievement = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
