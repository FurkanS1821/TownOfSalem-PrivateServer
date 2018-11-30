using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Server
{
    public class TutorialStatusMessage : BaseMessage
    {
        public List<int> TutorialStatus;

        public TutorialStatusMessage(List<int> tutorialStatus) : base(MessageType.TutorialStatus)
        {
            TutorialStatus = tutorialStatus;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var i = 0; i < TutorialStatus.Count; i++)
            {
                writer.Write(Encoding.UTF8.GetBytes(TutorialStatus[i].ToString()));

                if (i < TutorialStatus.Count - 1)
                {
                    writer.Write(',');
                }
            }
        }
    }
}
