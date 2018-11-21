using System;

namespace TownOfSalem_Networking.Server
{
    public class StartRankedQueueMessage : BaseMessage
    {
        public readonly int IsRequeue;
        public readonly int SecondsUntilQueue;

        public StartRankedQueueMessage(byte[] data) : base(data)
        {
            if (data.Length < 3)
            {
                return;
            }

            IsRequeue = Convert.ToInt32(data[1]) - 1;
            int.TryParse(BytesToString(data, 2), out SecondsUntilQueue);
        }
    }
}
