using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class PotionMasterPotionsMessage : BaseMessage
    {
        public readonly int NightsUntilHealAvailable;
        public readonly int NightsUntilAttackAvailable;
        public readonly int NightsUntilInvestigateAvailable;

        public PotionMasterPotionsMessage(int nightsTillHeal, int nightsTillAttack, int nightsTillInvestigate)
            : base(MessageType.PotionMasterPotions)
        {
            NightsUntilHealAvailable = nightsTillHeal;
            NightsUntilAttackAvailable = nightsTillAttack;
            NightsUntilInvestigateAvailable = nightsTillInvestigate;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(NightsUntilHealAvailable + 1));
            writer.Write((byte)(NightsUntilAttackAvailable + 1));
            writer.Write((byte)(NightsUntilInvestigateAvailable + 1));
        }
    }
}