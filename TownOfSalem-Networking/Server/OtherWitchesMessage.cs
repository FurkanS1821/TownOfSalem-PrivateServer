using System;

namespace TownOfSalem_Networking.Server
{
    public class OtherWitchesMessage : BaseMessage
    {
        public readonly int[] Positions;
        public readonly int[] Roles;

        public OtherWitchesMessage(byte[] data) : base(data)
        {
            try
            {
                var length = (data.Length - 1) / 2;
                Positions = new int[length];
                Roles = new int[length];
                for (var i = 0; i < length; ++i)
                {
                    Positions[i] = Convert.ToInt32(data[1 + i * 2]) - 1;
                    Roles[i] = Convert.ToInt32(data[2 + i * 2]) - 1;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
