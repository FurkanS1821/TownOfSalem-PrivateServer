using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Game
{
    public class RequestNameMessage : BaseMessage
    {
        private string _name;

        public RequestNameMessage(string name) : base(MessageType.RequestName)
        {
            _name = name;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(_name));
        }
    }
}
