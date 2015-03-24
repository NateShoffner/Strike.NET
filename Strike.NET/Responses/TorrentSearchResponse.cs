#region

using System.Collections.Generic;

#endregion

namespace StrikeNET.Responses
{
    public class TorrentSearchResponse
    {
        public List<TorrentSearchResult> SearchResults { get; set; }
    }
}