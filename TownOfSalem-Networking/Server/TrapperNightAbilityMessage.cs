using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TrapperNightAbilityMessage : BaseMessage
    {
        public readonly int RoleId;

        public TrapperNightAbilityMessage(int roleId) : base(MessageType.TrapperNightAbility)
        {
            RoleId = roleId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(RoleId + 1));
        }
    }
}