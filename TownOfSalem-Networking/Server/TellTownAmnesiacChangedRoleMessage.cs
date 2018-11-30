using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class TellTownAmnesiacChangedRoleMessage : BaseMessage
    {
        public readonly int Role;

        public TellTownAmnesiacChangedRoleMessage(int role) : base(MessageType.TellTownAmnesiacChangedRole)
        {
            Role = role;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)(Role + 1));
        }
    }
}
