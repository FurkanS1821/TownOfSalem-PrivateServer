using System;

namespace TownOfSalem_Networking.Server
{
    public class TrialGuiltyMessage : BaseMessage
    {
        public readonly int GuiltyVoteCount;
        public readonly int InnocentVoteCount;

        public TrialGuiltyMessage(byte[] data) : base(data)
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
