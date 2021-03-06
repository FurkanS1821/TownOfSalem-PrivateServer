﻿using System;
using Newtonsoft.Json;

namespace TownOfSalem_Networking.Client.Login
{
    public class LoginSteamWithUsernameMessage : BaseMessage
    {
        public InternalJson Data;

        public LoginSteamWithUsernameMessage(byte[] data) : base(data, true)
        {
            IsEncrypted = true;
            try
            {
                var jsonString = BytesToString(RawData, 1);
                Data = JsonConvert.DeserializeObject<InternalJson>(jsonString);
            }
            catch (Exception e)
            {
                ThrowNetworkMessageFormatException(e);
            }
        }

        [JsonObject]
        public class InternalJson
        {
            [JsonProperty("steam_id")]
            public string SteamId;
            [JsonProperty("username")]
            public string Username;
            [JsonProperty("password")]
            public string Password;
            [JsonProperty("type")]
            public int Type;
            [JsonProperty("platform")]
            public int Platform;
            [JsonProperty("build_id")]
            public int BuildId;
        }
    }
}