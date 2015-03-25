#region

using System;
using Newtonsoft.Json;

#endregion

namespace StrikeNET.V2
{
    /// <summary>
    ///     Represents a torrent entry.
    /// </summary>
    public interface ITorrent
    {
        /// <summary>
        ///     The torrent hash.
        /// </summary>
        [JsonProperty("torrent_hash")]
        string TorrentHash { get; }

        /// <summary>
        ///     The torrent title.
        /// </summary>
        [JsonProperty("torrent_title")]
        string TorrentTitle { get; }

        /// <summary>
        ///     The torrent category.
        /// </summary>
        [JsonProperty("torrent_category")]
        string TorrentCategory { get; }

        /// <summary>
        ///     The torrent sub-category.
        /// </summary>
        [JsonProperty("sub_category")]
        string SubCategory { get; }

        /// <summary>
        ///     The number of torrent seeds.
        /// </summary>
        [JsonProperty("seeds")]
        int Seeds { get; }

        /// <summary>
        ///     The number of torrent leeches.
        /// </summary>
        [JsonProperty("leeches")]
        int Leeches { get; }

        /// <summary>
        ///     The number of files contained in the torrent.
        /// </summary>
        [JsonProperty("file_count")]
        int FileCount { get; }

        /// <summary>
        ///     The cumulative size of the torrent.
        /// </summary>
        [JsonProperty("size")]
        long Size { get; }

        /// <summary>
        ///     The date in which the torrent was uploaded.
        /// </summary>
        [JsonProperty("upload_date")]
        DateTime UploadDate { get; }

        /// <summary>
        ///     The name of the user who uploaded the torrent.
        /// </summary>
        [JsonProperty("uploader_username")]
        string UploaderUsername { get; }
    }
}