using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Home
{
    public class PartyResponseMessage : BaseMessage
    {
        public PartyResponse Response;
        public int PartyId;

        public PartyResponseMessage(PartyResponse response, int partyId) : base(MessageType.PartyResponse)
        {
            Response = response;
            PartyId = partyId;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)Response);
            writer.Write(Encoding.UTF8.GetBytes(PartyId.ToString()));
        }
    }
}
