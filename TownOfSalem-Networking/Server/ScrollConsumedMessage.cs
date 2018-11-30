using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ScrollConsumedMessage : BaseMessage
    {
        public readonly int ScrollId;

        public ScrollConsumedMessage(int scrollId) : base(MessageType.ScrollConsumed)
        {
            ScrollId = scrollId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(ScrollId.ToString()));
        }
    }
}
