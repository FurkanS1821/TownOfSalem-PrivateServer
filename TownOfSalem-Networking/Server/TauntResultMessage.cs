using System;

namespace TownOfSalem_Networking.Server
{
    public class TauntResultMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int SubTarget;
        public readonly int TauntId;
        public readonly int Result;

        public TauntResultMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                SubTarget = Convert.ToInt32(data[2]) - 1;
                TauntId = Convert.ToInt32(data[3]) - 1;
                Result = Convert.ToInt32(data[4]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
