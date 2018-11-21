namespace TownOfSalem_Networking.Client.Global
{
    public class RequestPlayerStatisticsMessage : BaseMessage
    {
        public RequestPlayerStatisticsMessage()
            : base(MessageType.RequestPlayerStatistics)
        {
        }
    }
}
