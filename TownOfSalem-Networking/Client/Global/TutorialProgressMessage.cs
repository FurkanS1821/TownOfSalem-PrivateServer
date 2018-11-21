using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TownOfSalem_Networking.Client.Global
{
    public class TutorialProgressMessage : BaseMessage
    {
        public List<int> Tips;

        public TutorialProgressMessage(List<int> tips) : base(MessageType.TutorialProgress)
        {
            Tips = tips;
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            for (var index = 0; index < Tips.Count; ++index)
            {
                writer.Write(Encoding.UTF8.GetBytes(Tips[index].ToString()));
                if (index != Tips.Count - 1)
                {
                    writer.Write('*');
                }
            }
        }
    }
}
