using System;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacConvertedToMafiaOrWitch : BaseMessage
    {
        public readonly int Position;
        public readonly int RoleId;

        public AmnesiacConvertedToMafiaOrWitch(byte[] data) : base(data)
        {
            try
            {
                Position = data[1] - 1;
                RoleId = data[1] - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
