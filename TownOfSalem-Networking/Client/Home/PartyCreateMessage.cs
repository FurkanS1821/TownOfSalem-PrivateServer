using System;
using System.Diagnostics;
using System.IO;

namespace TownOfSalem_Networking.Client.Home
{
    public class PartyCreateMessage : BaseMessage
    {
        public int GameBrand;

        public PartyCreateMessage() : base(MessageType.PartyCreate)
        {
            GameBrand = Convert.ToInt32(GlobalServiceLocator.UserService.CurrentBrand);
        }

        protected override void SerializeData(BinaryWriter writer)
        {
            Debug.Write($"Sending party create request to server (CharCode equivalents): 31 & GameBrand: {GameBrand + 1}");
            writer.Write((byte)(GameBrand + 1));
        }
    }
}
