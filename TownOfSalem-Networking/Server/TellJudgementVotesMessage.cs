using System;

namespace TownOfSalem_Networking.Server
{
    public class TellJudgementVotesMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int Vote;

        public TellJudgementVotesMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                Vote = Convert.ToInt32(data[2]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
