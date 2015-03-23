#region

using System;
using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    public class TorrentInfo : Torrent
    {
        public List<FileInfo> FileInfo { get; private set; }
        public Uri MagnetUri { get; private set; }
    }
}