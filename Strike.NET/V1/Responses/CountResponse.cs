#region

using Newtonsoft.Json;

#endregion

namespace StrikeNET.V1.Responses
{
    internal class CountResponse
    {
        [JsonProperty("indexed_torrents")]
        public int IndexedTorrents { get; set; }
    }
}