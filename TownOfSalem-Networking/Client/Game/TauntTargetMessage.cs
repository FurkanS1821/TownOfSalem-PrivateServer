using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class TauntTargetMessage : BaseMessage
    {
        public int Position;
        public int SubTarget;
        public int TauntId;

        public TauntTargetMessage(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                SubTarget = data[2] - 1;
                TauntId = data[3] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
