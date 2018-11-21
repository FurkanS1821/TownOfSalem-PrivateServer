using System;
using System.Collections.Generic;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class RoleListMessage : BaseMessage
    {
        public readonly List<int> Roles = new List<int>();

        public RoleListMessage(byte[] data) : base(data)
        {
            try
            {
                foreach (int num in Encoding.ASCII.GetBytes(BytesToString(data, 1)))
                {
                    Roles.Add(num - 1);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
