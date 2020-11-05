using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class ReferralFeedbackMessage : BaseMessage
    {
        public readonly FriendReferralFeedback Feedback;

        public ReferralFeedbackMessage(FriendReferralFeedback feedback) : base(MessageType.ReferralFeedback)
        {
            Feedback = feedback;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            writer.Write(Encoding.UTF8.GetBytes(((byte)Feedback.Status).ToString()));
            if (Feedback.Status == FriendReferralFeedback.FriendReferralFeedbackStatus.REFERRAL_MISMATCH)
            {
                writer.Write(
                    Encoding.UTF8.GetBytes(
                        $"{Feedback.ReferrerMismatchUsername1},{Feedback.ReferrerMismatchUsername2}"));
            }
            else if (Feedback.Status == FriendReferralFeedback.FriendReferralFeedbackStatus.REFERRAL_SUCCESS)
            {
                writer.Write(Encoding.UTF8.GetBytes(Feedback.ReferrerUsername));
            }
        }
    }
}