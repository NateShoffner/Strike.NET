#region

using System;
using Newtonsoft.Json;

#endregion

namespace StrikeNET.V2.Responses
{
    internal class DownloadResponse
    {
        [JsonProperty("message")]
        public Uri Url { get; set; }
    }
}