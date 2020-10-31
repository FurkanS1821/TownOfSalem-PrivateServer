using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class RankedInfoUpdateMessage : BaseMessage
    {
        public RankedInformation RankedInfo = new RankedInformation();

        public RankedInfoUpdateMessage(RankedInformation rankedInfo) : base(MessageType.RankedInfo)
        {
            RankedInfo = rankedInfo;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var data = $"{RankedInfo.GameMode},{RankedInfo.PracticeGamesPlayed},{RankedInfo.CareerWins},";
            data += $"{RankedInfo.CareerLosses},{RankedInfo.CareerDraws},{RankedInfo.CareerLeaves},";
            data += $"{RankedInfo.CareerHighRating},{RankedInfo.SeasonNumber},{(RankedInfo.IsOffSeason ? 1 : 0)},";
            data += $"{RankedInfo.PlacementGamesRequired},{RankedInfo.SeasonWins},{RankedInfo.SeasonLosses},";
            data += $"{RankedInfo.SeasonDraws},{RankedInfo.SeasonLeaves},{RankedInfo.SeasonHighRating},";
            data += RankedInfo.SeasonRating.ToString();

            writer.Write(Encoding.UTF8.GetBytes(data));
        }
    }
}