using System;

namespace TownOfSalem_Networking.Client.Global
{
    [Obsolete("This log-in is not possible to implement (for a LAN server at least). So I don't bother implementing it.")]
    public class RegisterFacebookAccountMessage : RegisterAccountMessage
    {
        public RegisterFacebookAccountMessage(byte[] data) : base(data)
        {
        }
    }
}
