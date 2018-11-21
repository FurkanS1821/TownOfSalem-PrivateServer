using System;

namespace TownOfSalem_Networking.Server
{
    public class PotionMasterPotionsMessage : BaseMessage
    {
        public readonly int NightsUntilHealAvailable;
        public readonly int NightsUntilAttackAvailable;
        public readonly int NightsUntilInvestigateAvailable;

        public PotionMasterPotionsMessage(byte[] data) : base(data)
        {
            try
            {
                NightsUntilHealAvailable = data[1] - 1;
                NightsUntilAttackAvailable = data[2] - 1;
                NightsUntilInvestigateAvailable = data[3] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
