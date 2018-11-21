using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendReportMessage : BaseMessage
    {
        public int Position;
        public int Reason;
        public string Description;

        public SendReportMessage(int position, int reason, string description) : base(MessageType.SendReport)
        {
            Position = position;
            Reason = reason;
            Description = description;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(Reason + 2));
            writer.Write(Encoding.UTF8.GetBytes(Description));
        }
    }
}
