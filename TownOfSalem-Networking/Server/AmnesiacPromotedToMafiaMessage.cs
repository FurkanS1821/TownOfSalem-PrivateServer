using System;

namespace TownOfSalem_Networking.Server
{
    public class AmnesiacPromotedToMafiaMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int Role;

        public AmnesiacPromotedToMafiaMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                Role = Convert.ToInt32(data[1]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
