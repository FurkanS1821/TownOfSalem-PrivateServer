using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TownOfSalem_Networking.Structs
{
    public class FriendReferralFeedback
    {
        public string ReferrerUsername;
        public string ReferrerMismatchUsername1;
        public string ReferrerMismatchUsername2;
        public FriendReferralFeedbackStatus Status;

        public FriendReferralFeedback(FriendReferralFeedbackStatus status)
        {
            Status = status;
        }

        public FriendReferralFeedback(FriendReferralFeedbackStatus status, string referrerUsername)
        {
            Status = status;
            ReferrerUsername = referrerUsername;
        }

        public FriendReferralFeedback(FriendReferralFeedbackStatus status, string referrerMismatchUsername1,
            string referrerMismatchUsername2)
        {
            Status = status;
            ReferrerMismatchUsername1 = referrerMismatchUsername1;
            ReferrerMismatchUsername2 = referrerMismatchUsername2;
        }

        public enum FriendReferralFeedbackStatus
        {
            INVALID_CODE = 1,
            CODE_USED = 2,
            REFERRAL_MISMATCH = 3,
            REFERRAL_SUCCESS = 4,
            UNLOCKED_MORE_CODES = 5,
        }
    }
}
