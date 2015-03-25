#region

using Newtonsoft.Json;

#endregion

namespace StrikeNET.V1.Responses
{
    internal class DownloadResponse
    {
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}