using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace TownOfSalem_Networking.Server
{
    public class ServerFlagsMessage : BaseMessage
    {
        public List<bool> Flags = new List<bool>();

        public ServerFlagsMessage(byte[] data) : base(data)
        {
            try
            {
                for (var i = 1; i < data.Length; ++i)
                {
                    var num = (int)data[i];
                    Debug.Write($"Server Flag {i} : {num}");
                    Flags.Add(num > 1);
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
