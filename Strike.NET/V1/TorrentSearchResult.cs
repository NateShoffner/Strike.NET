#region

using System;

#endregion

namespace StrikeNET.V1
{
    public class TorrentSearchResult : ITorrentSearchInfo, ITorrent
    {
        #region Implementation of ITorrentSearchInfo

        public Uri Page { get; private set; }
        public Uri DownloadLink { get; private set; }
        public Uri RssFeed { get; private set; }
        public int DownloadCount { get; private set; }

        #endregion

        #region Implementation of ITorrent

        public string TorrentHash { get; private set; }
        public string TorrentTitle { get; private set; }
        public string TorrentCategory { get; private set; }
        public string SubCategory { get; private set; }
        public int Seeds { get; private set; }
        public int Leeches { get; private set; }
        public int FileCount { get; private set; }
        public long Size { get; private set; }
        public DateTime UploadDate { get; private set; }
        public string UploaderUsername { get; private set; }

        #endregion
    }
}