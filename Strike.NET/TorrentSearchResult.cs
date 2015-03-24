#region

using System;
using Newtonsoft.Json;

#endregion

namespace StrikeNET
{
    public class TorrentSearchResult : Torrent
    {
        [JsonProperty("page")]
        public Uri Page { get; private set; }

        [JsonProperty("download_link")]
        public Uri DownloadLink { get; private set; }

        [JsonProperty("rss_feed")]
        public Uri RssFeed { get; private set; }
    }
}