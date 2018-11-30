using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class UserInformationMessage : BaseMessage
    {
        public readonly string Username;
        public readonly int TownPoints;
        public readonly int MeritPoints;

        public UserInformationMessage(string username, int townPoints, int meritPoints)
            : base(MessageType.UserInformation)
        {
            Username = username;
            TownPoints = townPoints;
            MeritPoints = meritPoints;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(Username));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(TownPoints.ToString()));
            writer.Write('*');
            writer.Write(Encoding.UTF8.GetBytes(MeritPoints.ToString()));
        }
    }
}
