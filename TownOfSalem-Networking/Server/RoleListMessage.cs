using System.Collections.Generic;
using System.IO;

namespace TownOfSalem_Networking.Server
{
    public class RoleListMessage : BaseMessage
    {
        public readonly List<int> Roles;

        public RoleListMessage(List<int> roles) : base(MessageType.RoleList)
        {
            Roles = roles;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            foreach (var role in Roles)
            {
                writer.Write((byte)(role + 1));
            }
        }
    }
}