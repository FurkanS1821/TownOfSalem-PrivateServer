using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class NightTargetSecondMessage : BaseMessage
    {
        public int TargetPosition;

        public NightTargetSecondMessage(byte[] data) : base(data)
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