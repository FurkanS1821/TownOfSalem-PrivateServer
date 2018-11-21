using System;

namespace TownOfSalem_Networking.Server
{
    public class ChatBoxMessage : BaseMessage
    {
        public readonly int Source = -1;
        public readonly int Position;
        public readonly string Text;
        public readonly bool UseAccountName;

        public ChatBoxMessage(byte[] data) : base(data)
        {
            try
            {
                switch (data[1])
                {
                    case 30:
                    case 45:
                    case 60:
                    case 75:
                        Source = data[1];
                        Text = BytesToString(data, 2);
                        break;
                    case byte.MaxValue:
                        UseAccountName = true;
                        Position = data[2] - 1;
                        Text = BytesToString(data, 3);
                        break;
                    default:
                        Position = data[1] - 1;
                        Source = Position;
                        Text = BytesToString(data, 2);
                        break;
                }
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
