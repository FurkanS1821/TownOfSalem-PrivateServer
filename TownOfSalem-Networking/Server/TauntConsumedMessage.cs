using System;

namespace TownOfSalem_Networking.Server
{
    public class TauntConsumedMessage : BaseMessage
    {
        public readonly int TauntId;

        public TauntConsumedMessage(byte[] data) : base(data)
        {
            try
            {
                TauntId = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
