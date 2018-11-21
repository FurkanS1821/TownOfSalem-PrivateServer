using System;

namespace TownOfSalem_Networking.Server
{
    public class RoleAndPositionMessage : BaseMessage
    {
        public readonly int RoleId;
        public readonly int Position;
        public readonly int? TargetPosition;

        public RoleAndPositionMessage(byte[] data) : base(data)
        {
            try
            {
                RoleId = Convert.ToByte(data[1]) - 1;
                Position = Convert.ToByte(data[2]) - 1;
                if (data.Length != 4)
                {
                    return;
                }

                TargetPosition = Convert.ToByte(data[3]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
