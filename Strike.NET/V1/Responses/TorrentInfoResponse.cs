#region

using System.Collections.Generic;

#endregion

namespace StrikeNET.V1.Responses
{
    public class TorrentInfoResponse
    {
        public List<TorrentInfoResult> Torrents { get; set; }
    }
}