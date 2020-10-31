using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TownOfSalem_Networking.Enums;

namespace TownOfSalem_Networking.Structs
{
    public class FriendReferral
    {
        public string Code;
        public FriendReferralStatus Status;
        public string FriendUsername;
        public const int MAX_TRIAL_GAMES_ALLOWED = 5;
        public const int REFERRAL_CODE_GAMES_PLAYED_UNLOCK_AMT_1 = 10;
        public const int REFERRAL_CODE_GAMES_PLAYED_UNLOCK_AMT_2 = 25;
        public const int REFERRAL_CODE_GAMES_PLAYED_UNLOCK_AMT_3 = 50;
        public const int REFERRAL_CODE_GAMES_PLAYED_UNLOCK_AMT_4 = 100;
        public const int REFERRAL_CODE_GAMES_PLAYED_UNLOCK_AMT_5 = 250;
        public const int REFERRAL_CODE_CODES_ALLOWED_1 = 0;
        public const int REFERRAL_CODE_CODES_ALLOWED_2 = 5;
        public const int REFERRAL_CODE_CODES_ALLOWED_3 = 10;
        public const int REFERRAL_CODE_CODES_ALLOWED_4 = 15;
        public const int REFERRAL_CODE_CODES_ALLOWED_5 = 20;

        public FriendReferral(string code, FriendReferralStatus status, string friendUsername)
        {
            Code = code;
            Status = status;
            FriendUsername = friendUsername;
        }
    }
}
