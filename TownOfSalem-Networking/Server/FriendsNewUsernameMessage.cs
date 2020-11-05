using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class FriendsNewUsernameMessage : BaseMessage
    {
        public readonly string OldUsername;
        public readonly string NewUsername;

        public FriendsNewUsernameMessage(string oldUsername, string newUsername) : base(MessageType.FriendsNewUsername)
        {
            OldUsername = oldUsername;
            NewUsername = newUsername;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes($"{OldUsername}*{NewUsername}"));
        }
    }
}