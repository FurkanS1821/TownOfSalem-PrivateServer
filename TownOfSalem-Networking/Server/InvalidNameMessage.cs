using System;

namespace TownOfSalem_Networking.Server
{
    public class InvalidNameMessage : BaseMessage
    {
        public readonly int Reason;

        public InvalidNameMessage(byte[] data) : base(data)
        {
            try
            {
                Reason = Convert.ToInt32(data[1]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
