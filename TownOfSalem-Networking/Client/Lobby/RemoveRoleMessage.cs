using System.IO;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class RemoveRoleMessage : BaseMessage
    {
        public int RoleIndex;

        public RemoveRoleMessage(int roleIndex) : base(MessageType.RemoveRole)
        {
            RoleIndex = roleIndex;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleIndex + 1));
        }
    }
}
