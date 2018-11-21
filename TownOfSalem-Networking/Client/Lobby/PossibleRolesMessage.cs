using System.IO;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class PossibleRolesMessage : BaseMessage
    {
        public int TargetIndex;
        public int ScrollIndex;

        public PossibleRolesMessage(int targetIndex, int scrollIndex) : base(MessageType.PossibleRoles)
        {
            TargetIndex = targetIndex;
            ScrollIndex = scrollIndex;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(TargetIndex + 1));
            writer.Write((byte)(ScrollIndex + 1));
        }
    }
}
