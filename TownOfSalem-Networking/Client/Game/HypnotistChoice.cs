using System;

namespace TownOfSalem_Networking.Client.Game
{
    public class HypnotistChoiceMessage : BaseMessage
    {
        public int Choice;

        public HypnotistChoiceMessage(byte[] data) : base(data)
        {
            try
            {
                Choice = int.Parse(BytesToString(data, 1));
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
