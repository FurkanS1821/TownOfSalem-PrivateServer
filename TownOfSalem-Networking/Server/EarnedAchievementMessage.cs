using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class EarnedAchievementMessage : BaseMessage
    {
        public readonly int Achievement;

        public EarnedAchievementMessage(int achievement) : base(MessageType.EarnedAchievement)
        {
            Achievement = achievement;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Achievement + 1));
        }
    }
}
