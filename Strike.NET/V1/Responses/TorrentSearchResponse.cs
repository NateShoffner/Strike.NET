#region

using System.Collections.Generic;

#endregion

namespace StrikeNET.V1.Responses
{
    public class TorrentSearchResponse
    {
        public List<TorrentSearchResult> SearchResults { get; set; }
    }
}