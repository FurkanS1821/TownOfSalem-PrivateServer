using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendLastWillMessage : BaseMessage
    {
        public string LastWill;

        public SendLastWillMessage(string lastWill) : base(MessageType.SendLastWill)
        {
            LastWill = lastWill;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(LastWill));
        }
    }
}
