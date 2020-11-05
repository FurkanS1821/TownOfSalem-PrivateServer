namespace TownOfSalem_Networking.Client.Lobby
{
    public class StartGameMessage : BaseMessage
    {
        public StartGameMessage(byte[] data) : base(data)
        {
        }
    }
}