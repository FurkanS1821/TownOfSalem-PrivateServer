using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacChangedRoleMessage : BaseMessage
    {
        public readonly int RoleId;

        public AmnesiacChangedRoleMessage(int roleId) : base(MessageType.AmnesiacChangedRole)
        {
            RoleId = roleId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleId + 1));
        }
    }
}
