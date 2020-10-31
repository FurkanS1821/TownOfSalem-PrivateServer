using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class NightTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public NightTargetMessage(byte[] data) : base(data)
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