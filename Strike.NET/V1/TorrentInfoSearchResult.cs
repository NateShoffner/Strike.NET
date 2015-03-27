#region

using System;
using System.Collections.Generic;

#endregion

namespace StrikeNET.V1
{
    /// <summary>
    ///     Represents a combined torrent info search result.
    /// </summary>
    public class TorrentInfoSearchResult : ITorrentInfo, ITorrentSearchInfo, ITorrent
    {
        #region Implementation of ITorrentInfo

        public List<TorrentFileInfo> Files { get; set; }
        public Uri MagnetUri { get; set; }

        #endregion

        #region Implementation of ITorrentSearchInfo

        public Uri Page { get; set; }
        public Uri DownloadLink { get; set; }
        public Uri RssFeed { get; set; }
        public int DownloadCount { get; set; }

        #endregion

        #region Implementation of ITorrent

        public string TorrentHash { get; set; }
        public string TorrentTitle { get; set; }
        public string TorrentCategory { get; set; }
        public string SubCategory { get; set; }
        public int Seeds { get; set; }
        public int Leeches { get; set; }
        public int FileCount { get; set; }
        public long Size { get; set; }
        public DateTime UploadDate { get; set; }
        public string UploaderUsername { get; set; }

        #endregion
    }
}