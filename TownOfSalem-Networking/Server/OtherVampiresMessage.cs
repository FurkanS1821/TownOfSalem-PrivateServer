using System;
using System.Collections.Generic;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class OtherVampiresMessage : BaseMessage
    {
        public readonly List<VampireInfo> Vampires = new List<VampireInfo>();

        public OtherVampiresMessage(byte[] data) : base(data)
        {
            try
            {
                var bytes = Encoding.ASCII.GetBytes(BytesToString(data, 1));
                var num = 0;
                while (num < bytes.Length)
                {
                    Vampires.Add(new VampireInfo(Convert.ToInt32(data[1]) - 1, GetBoolValue(Convert.ToByte(data[2]))));
                    num += 2;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
