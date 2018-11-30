using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacConvertedToMafiaOrWitch : BaseMessage
    {
        public readonly int Position;
        public readonly int RoleId;

        public AmnesiacConvertedToMafiaOrWitch(int position, int roleId) : base(MessageType.AmnesiacConvertedToMafiaOrWitch)
        {
            Position = position;
            RoleId = roleId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Position + 1));
            writer.Write((byte)(RoleId + 1));
        }
    }
}
