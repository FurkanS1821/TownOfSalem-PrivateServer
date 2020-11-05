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
            writer.Write(Encoding.UTF8.GetBytes(string.Join(",", TutorialStatus)));
        }
    }
}