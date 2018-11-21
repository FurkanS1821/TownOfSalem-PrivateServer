using System;

namespace TownOfSalem_Networking.Server
{
    public class RankedInfoUpdateMessage : BaseMessage
    {
        public RankedInformation RankedInfo = new RankedInformation();

        public RankedInfoUpdateMessage(byte[] data) : base(data)
        {
            try
            {
                var strArray = BytesToString(data, 1).Split(',');
                if (strArray.Length < 15)
                {
                    throw new ArgumentException(
                        "RankedInfoUpdateMessage message expecting at least 15 parts but received less.");
                }

                RankedInfo.GameMode = int.Parse(strArray[0]);
                RankedInfo.PracticeGamesPlayed = int.Parse(strArray[1]);
                RankedInfo.CareerWin = int.Parse(strArray[2]);
                RankedInfo.CareerLoss = int.Parse(strArray[3]);
                RankedInfo.CareerDraw = int.Parse(strArray[4]);
                RankedInfo.CareerLeaves = int.Parse(strArray[5]);
                RankedInfo.CareerHighRating = int.Parse(strArray[6]);
                RankedInfo.SeasonNumber = int.Parse(strArray[7]);
                RankedInfo.IsOffseason = Convert.ToBoolean(int.Parse(strArray[8]));
                RankedInfo.PlacementGamesRequired = int.Parse(strArray[9]);
                RankedInfo.SeasonWins = int.Parse(strArray[10]);
                RankedInfo.SeasonLosses = int.Parse(strArray[11]);
                RankedInfo.SeasonDraws = int.Parse(strArray[12]);
                RankedInfo.SeasonLeaves = int.Parse(strArray[13]);
                RankedInfo.SeasonHighRating = int.Parse(strArray[14]);
                RankedInfo.SeasonRating = int.Parse(strArray[15]);
            }
            catch (Exception ex)
            {
                ThrowNetworkMessageFormatException(ex);
            }
        }
    }
}
