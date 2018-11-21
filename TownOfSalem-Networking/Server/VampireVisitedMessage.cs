using System;

namespace TownOfSalem_Networking.Server
{
    public class VampireVisitedMessage : BaseMessage
    {
        public readonly int Position;

        public VampireVisitedMessage(byte[] data) : base(data)
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
