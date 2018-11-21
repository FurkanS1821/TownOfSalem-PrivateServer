using System;

namespace TownOfSalem_Networking.Server
{
    public class MafiaWasJailedMessage : BaseMessage
    {
        public readonly int Position;

        public MafiaWasJailedMessage(byte[] data) : base(data)
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
