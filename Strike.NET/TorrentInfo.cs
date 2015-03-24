#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StrikeNET.Converters;

#endregion

namespace StrikeNET
{
    /// <summary>
    /// Represents additional torrent information.
    /// </summary>
    public class TorrentInfo : Torrent
    {
        /// <summary>
        /// The file(s) contained within the torrent.
        /// </summary>
        [JsonProperty("file_info")]
        [JsonConverter(typeof(FileInfoConverter))]
        public List<TorrentFileInfo> Files { get; private set; }

        /// <summary>
        /// The torrent magnet Uri.
        /// </summary>
        [JsonProperty("magnet_uri")]
        public Uri MagnetUri { get; private set; }
    }
}