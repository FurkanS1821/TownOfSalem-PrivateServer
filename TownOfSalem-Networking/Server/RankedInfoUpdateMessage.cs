using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class RankedInfoUpdateMessage : BaseMessage
    {
        public RankedInformation RankedInfo;

        public RankedInfoUpdateMessage(RankedInformation rankedInfo) : base(MessageType.RankedInfo)
        {
            RankedInfo = rankedInfo;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.GameMode.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.PracticeGamesPlayed.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.CareerWin.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.CareerLoss.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.CareerDraw.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.CareerLeaves.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.CareerHighRating.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonNumber.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes((RankedInfo.IsOffseason ? 1 : 0).ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.PlacementGamesRequired.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonWins.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonLosses.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonDraws.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonLeaves.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonHighRating.ToString()));
            writer.Write(',');
            writer.Write(Encoding.UTF8.GetBytes(RankedInfo.SeasonRating.ToString()));
        }
    }
}
