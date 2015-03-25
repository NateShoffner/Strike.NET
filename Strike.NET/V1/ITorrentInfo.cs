#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StrikeNET.Converters;

#endregion

namespace StrikeNET.V1
{
    /// <summary>
    ///     Represents additional torrent information.
    /// </summary>
    public interface ITorrentInfo
    {
        /// <summary>
        ///     The file(s) contained within the torrent.
        /// </summary>
        [JsonProperty("file_info")]
        [JsonConverter(typeof (FileInfoConverter))]
        List<TorrentFileInfo> Files { get; }

        /// <summary>
        ///     The torrent magnet Uri.
        /// </summary>
        [JsonProperty("magnet_uri")]
        Uri MagnetUri { get; }
    }
}