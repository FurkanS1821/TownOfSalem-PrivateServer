using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class HostClickedAddMessage : BaseMessage
    {
        public readonly int RoleId;

        public HostClickedAddMessage(int roleId) : base(MessageType.HostClickedAdd)
        {
            RoleId = roleId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleId + 1));
        }
    }
}
