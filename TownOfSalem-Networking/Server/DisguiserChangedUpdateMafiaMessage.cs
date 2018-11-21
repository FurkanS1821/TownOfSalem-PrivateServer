using System;

namespace TownOfSalem_Networking.Server
{
    public class DisguiserChangedUpdateMafiaMessage : BaseMessage
    {
        public readonly int Position;
        public readonly int PreviousPosition;

        public DisguiserChangedUpdateMafiaMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                PreviousPosition = Convert.ToInt32(data[2]) - 1;
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
