#region

using System.Collections.Generic;

#endregion

namespace StrikeNET.Responses
{
    public class TorrentInfoResponse
    {
        public List<TorrentInfoResult> Torrents { get; set; }
    }
}