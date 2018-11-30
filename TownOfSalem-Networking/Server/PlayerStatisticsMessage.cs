using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class PlayerStatisticsMessage : BaseMessage
    {
        public readonly List<int> Stats;

        public PlayerStatisticsMessage(List<int> stats) : base(MessageType.PlayerStatistics)
        {
            Stats = stats;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < Stats.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(Stats[i].ToString()));

                if (i < Stats.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
