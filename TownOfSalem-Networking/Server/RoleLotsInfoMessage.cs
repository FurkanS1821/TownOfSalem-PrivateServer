using System.Collections.Generic;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class RoleLotsInfoMessage : BaseMessage
    {
        public readonly List<RoleLotInfo> RoleLots = new List<RoleLotInfo>();

        public RoleLotsInfoMessage(List<RoleLotInfo> roleLots) : base(MessageType.RoleLotsInfo)
        {
            RoleLots = roleLots;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < RoleLots.Count; i++)
            {
                var roleLot = RoleLots[i];
                writer.Write(Encoding.UTF8.GetBytes(roleLot.RoleId.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(roleLot.TotalLots.ToString()));
                writer.Write(',');
                writer.Write(Encoding.UTF8.GetBytes(roleLot.Lots.ToString()));

                if (i < RoleLots.Count - 1)
                {
                    writer.Write('*');
                }
            }
        }
    }
}
