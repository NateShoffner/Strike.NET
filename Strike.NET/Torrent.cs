#region

using System;
using Newtonsoft.Json;
using StrikeNET.Converters;

#endregion

namespace StrikeNET
{
    /// <summary>
    /// Represents a torrent entry.
    /// </summary>
    public class Torrent
    {
        /// <summary>
        /// The torrent hash.
        /// </summary>
        [JsonProperty("torrent_hash")]
        public string TorrentHash { get; protected set; }

        /// <summary>
        /// The torrent title.
        /// </summary>
        [JsonProperty("torrent_title")]
        public string TorrentTitle { get; protected set; }

        /// <summary>
        /// The torrent category.
        /// </summary>
        [JsonProperty("torrent_category")]
        public string TorrentCategory { get; protected set; }

        /// <summary>
        /// The torrent sub-category.
        /// </summary>
        [JsonProperty("sub_category")]
        public string SubCategory { get; protected set; }

        /// <summary>
        /// The number of torrent seeds.
        /// </summary>
        [JsonProperty("seeds")]
        public int Seeds { get; protected set; }

        /// <summary>
        /// The number of torrent leeches.
        /// </summary>
        [JsonProperty("leeches")]
        public int Leeches { get; protected set; }

        /// <summary>
        /// The number of files contained in the torrent.
        /// </summary>
        [JsonProperty("file_count")]
        public int FileCount { get; protected set; }

        /// <summary>
        /// The cumulative size of the torrent.
        /// </summary>
        [JsonProperty("size")]
        [JsonConverter(typeof(FileSizeStringConverter))]
        public long Size { get; protected set; }

        /// <summary>
        /// The date in which the torrent was uploaded.
        /// </summary>
        [JsonProperty("upload_date")]
        public DateTime UploadDate { get; protected set; }

        /// <summary>
        /// The name of the user who uploaded the torrent.
        /// </summary>
        [JsonProperty("uploader_username")]
        public string UploaderUsername { get; protected set; }
    }
}