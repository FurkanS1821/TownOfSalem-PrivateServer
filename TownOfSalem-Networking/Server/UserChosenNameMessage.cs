using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class UserChosenNameMessage : BaseMessage
    {
        public readonly int StringTableId;
        public readonly int Position;
        public readonly string PlayerName;

        public UserChosenNameMessage(int stringTableId, int position, string playerName)
            : base(MessageType.UserChosenName)
        {
            StringTableId = stringTableId;
            Position = position;
            PlayerName = playerName;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(StringTableId + 1));
            writer.Write((byte)(Position + 1));
            writer.Write(Encoding.UTF8.GetBytes(PlayerName));
        }
    }
}