using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class NamesAndPositionsMessage : BaseMessage
    {
        public readonly int Position;
        public readonly string PlayerName;

        public NamesAndPositionsMessage(int position, string playerName) : base(MessageType.NamesAndPositions)
        {
            Position = position;
            PlayerName = playerName;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write(Encoding.UTF8.GetBytes(PlayerName));
        }
    }
}
