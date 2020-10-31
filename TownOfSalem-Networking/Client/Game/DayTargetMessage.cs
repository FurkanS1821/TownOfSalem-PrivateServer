using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class DayTargetMessage : BaseMessage
    {
        public int TargetPosition;

        public DayTargetMessage(byte[] data) : base(data)
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