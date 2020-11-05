using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacChangedRoleMessage : BaseMessage
    {
        public readonly int RoleId;
        public readonly int TargetId;

        public AmnesiacChangedRoleMessage(int roleId, int targetId) : base(MessageType.AmnesiacChangedRole)
        {
            RoleId = roleId;
            TargetId = targetId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleId + 1));
            writer.Write((byte)(TargetId + 1));
        }
    }
}