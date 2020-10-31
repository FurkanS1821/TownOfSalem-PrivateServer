namespace TownOfSalem_Networking.Client.Home
{
    public class SteamHomeLinkAccountMessage : BaseMessage
    {
        public string SteamAuthTicket;
        public SteamHomeLinkAccountMessage(byte[] data) : base(data)
        {
            SteamAuthTicket = BytesToString(data, 1);
        }
    }
}
