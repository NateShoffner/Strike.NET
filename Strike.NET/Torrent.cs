#region

using System;

#endregion

namespace StrikeNET
{
    public class Torrent
    {
        public string TorrentHash { get; protected set; }
        public string TorrentTitle { get; protected set; }
        public string TorrentCategory { get; protected set; }
        public string SubCategory { get; protected set; }
        public int Seeds { get; protected set; }
        public int Leeches { get; protected set; }
        public int FileCount { get; protected set; }
        public string Size { get; protected set; }
        public DateTime UploadDate { get; protected set; }
        public string UploaderUsername { get; protected set; }
    }
}