using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class StartRankedQueueMessage : BaseMessage
    {
        public readonly int IsRequeue;
        public readonly int SecondsUntilQueue;

        public StartRankedQueueMessage(int isRequeue, int secondsUntilQueue) : base(MessageType.StartRankedQueue)
        {
            IsRequeue = isRequeue;
            SecondsUntilQueue = secondsUntilQueue;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(IsRequeue + 1));
            writer.Write(Encoding.UTF8.GetBytes(SecondsUntilQueue.ToString()));
        }
    }
}
