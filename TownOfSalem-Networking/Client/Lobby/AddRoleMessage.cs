using System.IO;

namespace TownOfSalem_Networking.Client.Lobby
{
    public class AddRoleMessage : BaseMessage
    {
        public int RoleIndex;

        public AddRoleMessage(int roleIndex) : base(MessageType.AddRole)
        {
            RoleIndex = roleIndex;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleIndex + 1));
        }
    }
}
