using System;
using System.Collections.Generic;

namespace TownOfSalem_Networking.Server
{
    public class RoleLotsInfoMessage : BaseMessage
    {
        public readonly List<RoleLotInfo> RoleLots = new List<RoleLotInfo>();

        public RoleLotsInfoMessage(byte[] data) : base(data)
        {
            try
            {
                var str1 = BytesToString(data, 1);
                foreach (var str2 in str1.Split('*'))
                {
                    var strArray = str2.Split(',');
                    RoleLots.Add(new RoleLotInfo(
                        int.Parse(strArray[0]),
                        Convert.ToInt32(strArray[1]),
                        Convert.ToInt32(strArray[2])
                    ));
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
