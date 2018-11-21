using System;

namespace TownOfSalem_Networking.Server
{
    public class TellJanitorTargetsWillMessage : BaseMessage
    {
        public readonly int Position;
        public readonly string Will;

        public TellJanitorTargetsWillMessage(byte[] data) : base(data)
        {
            try
            {
                Position = Convert.ToInt32(data[1]) - 1;
                Will = BytesToString(data, 2);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
