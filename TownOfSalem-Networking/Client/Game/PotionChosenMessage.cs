using System.IO;
using TownOfSalem_Logic;

namespace TownOfSalem_Networking.Client.Game
{
    public class PotionChosenMessage : BaseMessage
    {
        public PotionMasterPotionType Potion;

        public PotionChosenMessage(PotionMasterPotionType potionType) : base(MessageType.PotionChosen)
        {
            Potion = potionType;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Potion);
        }
    }
}
