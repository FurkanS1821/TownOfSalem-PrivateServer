using System;

namespace TownOfSalem_Networking.Server
{
    public class HowManyAbilitiesLeftMessage : BaseMessage
    {
        public readonly int AbilityCount;

        public HowManyAbilitiesLeftMessage(byte[] data) : base(data)
        {
            try
            {
                AbilityCount = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
