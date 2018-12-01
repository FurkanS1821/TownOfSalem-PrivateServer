using System;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Client.Game
{
    public class PotionChosenMessage : BaseMessage
    {
        public PotionMasterPotionType Potion;

        public PotionChosenMessage(byte[] data) : base(data)
        {
            try
            {
                Potion = (PotionMasterPotionType)data[1];
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
