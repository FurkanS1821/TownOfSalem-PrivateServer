using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HowManyAbilitiesLeftMessage : BaseMessage
    {
        public readonly int AbilityCount;

        public HowManyAbilitiesLeftMessage(int abilityCount) : base(MessageType.HowManyAbilitiesLeft)
        {
            AbilityCount = abilityCount;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(AbilityCount + 1));
        }
    }
}
