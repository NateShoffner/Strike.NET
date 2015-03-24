#region

using System;
using Newtonsoft.Json;

#endregion

namespace StrikeNET
{
    /// <summary>
    /// Reprents a torrent search result.
    /// </summary>
    public class TorrentSearchResult : Torrent
    {
        /// <summary>
        /// The dedicated Strike page for the torrent.
        /// </summary>
        [JsonProperty("page")]
        public Uri Page { get; private set; }

        /// <summary>
        /// The dedicated download link for the torrent.
        /// </summary>
        [JsonProperty("download_link")]
        public Uri DownloadLink { get; private set; }

        /// <summary>
        /// The dedicated RSS feed for the torrent.
        /// </summary>
        [JsonProperty("rss_feed")]
        public Uri RssFeed { get; private set; }

        /// <summary>
        /// The total number of torrent downloads.
        /// </summary>
        [JsonProperty("download_count")]
        public int DownloadCount { get; protected set; }
    }
}