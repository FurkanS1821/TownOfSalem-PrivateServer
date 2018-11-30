using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TellJanitorTargetsRoleMessage : BaseMessage
    {
        public readonly int Role;

        public TellJanitorTargetsRoleMessage(int role) : base(MessageType.TellJanitorTargetsRole)
        {
            Role = role;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Role + 1));
        }
    }
}
