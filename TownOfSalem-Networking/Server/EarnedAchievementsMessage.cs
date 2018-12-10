using System.IO;
using System.Linq;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class EarnedAchievementsMessage : BaseMessage
    {
        public int[] Achievements;

        public EarnedAchievementsMessage(int[] achievements) : base(MessageType.EarnedAchievements)
        {
            Achievements = achievements.ToArray();
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Achievements.Length; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Achievements[i].ToString()));

                if (i < Achievements.Length - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
