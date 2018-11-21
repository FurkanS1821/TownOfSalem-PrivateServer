using System;

namespace TownOfSalem_Networking.Server
{
    public class LastBonusWinTimeMessage : BaseMessage
    {
        public readonly int LastBonusWinTime;

        public LastBonusWinTimeMessage(byte[] data) : base(data)
        {
            try
            {
                LastBonusWinTime = int.Parse(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
