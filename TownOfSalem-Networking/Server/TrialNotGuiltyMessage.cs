using System;

namespace TownOfSalem_Networking.Server
{
    public class TrialNotGuiltyMessage : BaseMessage
    {
        public readonly int GuiltyVoteCount;
        public readonly int InnocentVoteCount;

        public TrialNotGuiltyMessage(byte[] data) : base(data)
        {
            try
            {
                GuiltyVoteCount = Convert.ToInt32(data[1]) - 1;
                InnocentVoteCount = Convert.ToInt32(data[2]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
