using System.IO;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Server
{
    public class LinkingFailureMessage : BaseMessage
    {
        public readonly LinkingFailure Reason;

        public LinkingFailureMessage(LinkingFailure reason) : base(MessageType.LinkingFailure)
        {
            Reason = reason;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Reason);
        }
    }
}