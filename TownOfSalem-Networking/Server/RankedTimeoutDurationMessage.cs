using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class RankedTimeoutDurationMessage : BaseMessage
    {
        public readonly int Duration;

        public RankedTimeoutDurationMessage(int duration) : base(MessageType.RankedTimeoutDuration)
        {
            Duration = duration;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Duration.ToString()));
        }
    }
}