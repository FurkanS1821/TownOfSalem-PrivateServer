using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class CheckUsernameMessage : BaseMessage
    {
        public string Username;

        public CheckUsernameMessage(string username) : base(MessageType.CheckUsername)
        {
            Username = username.Trim();
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
        }
    }
}
