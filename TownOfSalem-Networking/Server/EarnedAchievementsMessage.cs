using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class EarnedAchievementsMessage : BaseMessage
    {
        public List<int> Achievements;

        public EarnedAchievementsMessage(List<int> achievements)
            : base(MessageType.EarnedAchievements)
        {
            Achievements = achievements;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", Achievements)));
        }
    }
}