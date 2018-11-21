using System;

namespace TownOfSalem_Networking.Server
{
    public class ChangedJudgementVoteMessage : BaseMessage
    {
        public readonly int Position;

        public ChangedJudgementVoteMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
