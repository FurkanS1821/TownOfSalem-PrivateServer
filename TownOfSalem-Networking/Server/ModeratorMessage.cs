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
            writer.Write((byte)MessageInfo.AccountId);

            if (MessageInfo.MessageId == 6 || MessageInfo.MessageId == 7)
            {
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Username));
            }

            if (MessageInfo.MessageId == 5 || MessageInfo.MessageId == 8 || MessageInfo.MessageId == 9
                || MessageInfo.MessageId == 36)
            {
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Message));
            }

            if (MessageInfo.MessageId == 10)
            {
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Username));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.AccountId.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.TownPoints.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Elo.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.Suspensions.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.UserLevel.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(MessageInfo.SteamId.ToString()));
            }

            if (MessageInfo.MessageId == 13)
            {
                writer.Write((byte)(MessageInfo.IsDeveloperModeOnly ? 2 : 1));
            }

            if (MessageInfo.MessageId == 24)
            {
                writer.Write((byte)(MessageInfo.IsSuccess ? 2 : 1));
            }

            if (MessageInfo.MessageId != 28 && MessageInfo.MessageId != 29 && MessageInfo.MessageId != 30)
            {
                return;
            }

            writer.Write((byte)(MessageInfo.IsOn ? 2 : 1));
        }
    }
}
