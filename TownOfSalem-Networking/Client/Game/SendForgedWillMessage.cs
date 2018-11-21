using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Game
{
    public class SendForgedWillMessage : BaseMessage
    {
        public string Will;

        public SendForgedWillMessage(string will) : base(MessageType.SendForgedWill)
        {
            Will = will;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Will));
        }
    }
}
