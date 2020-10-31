using System.Collections.Generic;
using System.IO;
using System.Text;
using TownOfSalem_Networking.Structs;

namespace TownOfSalem_Networking.Server
{
    public class ReferralCodesMessage : BaseMessage
    {
        public readonly List<FriendReferral> ReferralCodesList;

        public ReferralCodesMessage(List<FriendReferral> referralCodesList) : base(MessageType.ReferralCodes)
        {
            ReferralCodesList = referralCodesList;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            var list = new List<string>();

            foreach (var referral in ReferralCodesList)
            {
                var content = $"{referral.Code},{(byte)referral.Status}";
                if (!string.IsNullOrEmpty(referral.FriendUsername))
                {
                    content += $",{referral.FriendUsername}";
                }

                list.Add(content);
            }

            writer.Write(Encoding.UTF8.GetBytes(string.Join("*", list)));
        }
    }
}