using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class FacebookShareWinMessage : BaseMessage
    {
        public readonly int WinningGroupId;

        public FacebookShareWinMessage(int winningGroupId) : base(MessageType.FacebookShareWin)
        {
            WinningGroupId = winningGroupId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)WinningGroupId);
        }
    }
}