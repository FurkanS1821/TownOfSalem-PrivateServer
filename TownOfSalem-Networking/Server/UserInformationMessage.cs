using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class UserInformationMessage : BaseMessage
    {
        public readonly string Username;
        public readonly int TownPoints;
        public readonly int MeritPoints;
        public readonly int AccountId;

        public UserInformationMessage(string username, int townPoints, int meritPoints, int accountId)
            : base(MessageType.UserInformation)
        {
            Username = username;
            TownPoints = townPoints;
            MeritPoints = meritPoints;
            AccountId = accountId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var data = $"{Username}*{TownPoints}*{MeritPoints}*{AccountId}";
            writer.Write(Encoding.UTF8.GetBytes(data));
        }
    }
}