namespace TownOfSalem_Networking.Client.Global
{
    public class RequestPlayerStatisticsMessage : BaseMessage
    {
        public RequestPlayerStatisticsMessage(byte[] data) : base(data)
        {
        }
    }
}