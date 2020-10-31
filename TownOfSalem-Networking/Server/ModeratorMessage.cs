using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class ModeratorMessage : BaseMessage
    {
        public readonly ModeratorMessageInfo MessageInfo;

        public ModeratorMessage(ModeratorMessageInfo messageInfo) : base(MessageType.ModeratorMessage)
        {
            MessageInfo = messageInfo;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)MessageInfo.MessageId);
            switch (MessageInfo.MessageId)
            {
                case 6:
                case 7:
                    writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Username));
                    break;
                case 5:
                case 8:
                case 9:
                case 36:
                    writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Message));
                    break;
                case 10:
                    var packetContent = $"{MessageInfo.Username},{MessageInfo.AccountId},{MessageInfo.TownPoints},";
                    packetContent += $"{MessageInfo.Elo},{MessageInfo.Suspensions},{MessageInfo.UserLevel},";
                    packetContent += MessageInfo.SteamId;
                    writer.Write(Encoding.UTF8.GetBytes(packetContent));
                    break;
                case 13:
                    writer.Write((byte)(MessageInfo.IsDeveloperModeOnly ? 2 : 1));
                    break;
                case 24:
                    writer.Write((byte)(MessageInfo.IsSuccess ? 2 : 1));
                    break;
                case 28:
                case 29:
                case 30:
                    writer.Write((byte)(MessageInfo.IsOn ? 2 : 1));
                    break;
            }
        }
    }
}