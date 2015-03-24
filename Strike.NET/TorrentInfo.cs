#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json;

#endregion

namespace StrikeNET
{
    public class TorrentInfo : Torrent
    {
        [JsonProperty("file_info")]
        public List<FileInfo> FileInfo { get; private set; }

        [JsonProperty("magnet_uri")]
        public Uri MagnetUri { get; private set; }
    }
}