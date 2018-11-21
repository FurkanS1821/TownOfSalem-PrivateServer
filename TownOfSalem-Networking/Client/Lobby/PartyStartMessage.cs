using System.IO;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PartyStartMessage : BaseMessage
    {
        public int GameMode;

        public PartyStartMessage(int gameMode) : base(MessageType.PartyStart)
        {
            GameMode = gameMode;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)GameMode);
        }
    }
}
