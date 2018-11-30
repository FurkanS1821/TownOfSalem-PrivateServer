using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class ReferAFriendUpdateMessage : BaseMessage
    {
        public readonly int AwardType;
        public readonly int TownPointsAwarded;

        public ReferAFriendUpdateMessage(int awardType, int townPointsAwarded) : base(MessageType.ReferAFriendUpdate)
        {
            AwardType = awardType;
            TownPointsAwarded = townPointsAwarded;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write((byte)AwardType);

            if (AwardType >= 5)
            {
                return;
            }

            writer.Write(Encoding.UTF8.GetBytes(TownPointsAwarded.ToString()));
        }
    }
}
