#region

using System.Collections.Generic;

#endregion

namespace StrikeNET
{
    public class TorrentInfoResponse : List<List<TorrentInfo>>
    {
        public int results { get; set; }
        public int statuscode { get; set; }
        public double responsetime { get; set; }
    }
}