using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class VoteTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public VoteTargetMessage(byte[] data) : base(data)
        {
            try
            {
                TargetPosition = data[1] - 1;
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }
    }
}