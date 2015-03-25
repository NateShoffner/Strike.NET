#region

using System.Collections.Generic;

#endregion

namespace StrikeNET.V2.Responses
{
    public class TorrentSearchResponse
    {
        public List<TorrentSearchResult> Torrents { get; set; }
    }
}