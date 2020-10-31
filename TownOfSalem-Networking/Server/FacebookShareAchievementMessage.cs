using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class FacebookShareAchievementMessage : BaseMessage
    {
        public readonly int AchievementId;

        public FacebookShareAchievementMessage(int achievementId) : base(MessageType.FacebookShareAchievement)
        {
            AchievementId = achievementId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(AchievementId + 1));
        }
    }
}