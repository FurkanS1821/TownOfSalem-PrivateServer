namespace TownOfSalem_Networking.Client.Global
{
    public class PingMessage : BaseMessage
    {
        public PingMessage(byte[] data) : base(data)
        {
        }
    }
}
