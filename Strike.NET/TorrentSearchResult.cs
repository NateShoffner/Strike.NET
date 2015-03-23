#region

using System;

#endregion

namespace StrikeNET
{
    public class TorrentSearchResult : Torrent
    {
        public Uri Page { get; private set; }
        public Uri DownloadLink { get; private set; }
        public Uri RssFeed { get; private set; }
    }
}