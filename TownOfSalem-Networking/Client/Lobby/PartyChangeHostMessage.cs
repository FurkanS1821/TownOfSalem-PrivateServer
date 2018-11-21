using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyChangeHostMessage : BaseMessage
    {
        public string Username;

        public PartyChangeHostMessage(string username) : base(MessageType.PartyChangeHost)
        {
            Username = username;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
