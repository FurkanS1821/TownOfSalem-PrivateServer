using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class LastBonusWinTimeMessage : BaseMessage
    {
        public readonly int LastBonusWinTime;

        public LastBonusWinTimeMessage(int lastBonusWinTime) : base(MessageType.LastBonusWinTime)
        {
            LastBonusWinTime = lastBonusWinTime;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(LastBonusWinTime.ToString()));
        }
    }
}