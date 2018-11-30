using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class MafiaTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public MafiaTargetMessage(byte[] data) : base(data)
        {
            try
            {
                TargetPosition = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
