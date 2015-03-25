#region

using System.Collections.Generic;

#endregion

namespace StrikeNET.V2.Responses
{
    public class TorrentInfoResponse
    {
        public List<TorrentInfoResult> Torrents { get; set; }
    }
}