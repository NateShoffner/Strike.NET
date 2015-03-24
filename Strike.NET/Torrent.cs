#region

using System;
using Newtonsoft.Json;

#endregion

namespace StrikeNET
{
    public class Torrent
    {
        [JsonProperty("torrent_hash")]
        public string TorrentHash { get; protected set; }

        [JsonProperty("torrent_title")]
        public string TorrentTitle { get; protected set; }

        [JsonProperty("torrent_category")]
        public string TorrentCategory { get; protected set; }

        [JsonProperty("sub_category")]
        public string SubCategory { get; protected set; }

        [JsonProperty("seeds")]
        public int Seeds { get; protected set; }

        [JsonProperty("leeches")]
        public int Leeches { get; protected set; }

        [JsonProperty("file_count")]
        public int FileCount { get; protected set; }

        [JsonProperty("size")]
        public string Size { get; protected set; }

        [JsonProperty("upload_date")]
        public DateTime UploadDate { get; protected set; }

        [JsonProperty("uploader_username")]
        public string UploaderUsername { get; protected set; }
    }
}