using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PotionMasterPotionsMessage : BaseMessage
    {
        public readonly int NightsUntilHealAvailable;
        public readonly int NightsUntilAttackAvailable;
        public readonly int NightsUntilInvestigateAvailable;

        public PotionMasterPotionsMessage(int nightsUntilHealAvailable, int nightsUntilAttackAvailable,
            int nightsUntilInvestigateAvailable) : base(MessageType.PotionMasterPotions)
        {
            NightsUntilHealAvailable = nightsUntilHealAvailable;
            NightsUntilAttackAvailable = nightsUntilAttackAvailable;
            NightsUntilInvestigateAvailable = nightsUntilInvestigateAvailable;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(NightsUntilHealAvailable + 1));
            writer.Write((byte)(NightsUntilAttackAvailable + 1));
            writer.Write((byte)(NightsUntilInvestigateAvailable + 1));
        }
    }
}
