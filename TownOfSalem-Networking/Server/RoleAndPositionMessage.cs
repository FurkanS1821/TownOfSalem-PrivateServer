using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class RoleAndPositionMessage : BaseMessage
    {
        public readonly int RoleId;
        public readonly int Position;
        public readonly int? TargetPosition;

        public RoleAndPositionMessage(int roleId, int position, int? targetPosition) : base(MessageType.RoleAndPosition)
        {
            RoleId = roleId;
            Position = position;
            TargetPosition = targetPosition;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleId + 1));
            writer.Write((byte)(Position + 1));
            if (TargetPosition.HasValue)
            {
                writer.Write((byte)(TargetPosition.Value + 1));
            }
        }
    }
}