#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using StrikeNET.Converters;

#endregion

namespace StrikeNET
{
    public class TorrentInfo : Torrent
    {
        [JsonProperty("file_info")]
        [JsonConverter(typeof(FileInfoConverter))]
        public List<TorrentFileInfo> Files { get; private set; }

        [JsonProperty("magnet_uri")]
        public Uri MagnetUri { get; private set; }
    }
}