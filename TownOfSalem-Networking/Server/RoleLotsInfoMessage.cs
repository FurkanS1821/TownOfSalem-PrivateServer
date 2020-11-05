using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class RoleLotsInfoMessage : BaseMessage
    {
        public readonly List<RoleLotInfo> RoleLots;

        public RoleLotsInfoMessage(List<RoleLotInfo> roleLots) : base(MessageType.RoleLotsInfo)
        {
            RoleLots = roleLots;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(string.Join("*", RoleLots.Select(x => $"{x.RoleId},{x.TotalLots},{x.Lots}"))));
        }
    }
}