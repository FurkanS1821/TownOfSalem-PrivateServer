using System;

namespace TownOfSalem_Networking.Server
{
    public class MafiaPromotedTellMafiaMessage : BaseMessage
    {
        public readonly int Position;

        public MafiaPromotedTellMafiaMessage(byte[] data) : base(data)
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
