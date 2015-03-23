#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using RestSharp;

#endregion

namespace StrikeNET
{
    public class StrikeApi
    {
        private const string ApiBaseUrL = "http://getstrike.net/api/";

        private readonly RestClient _restClient;

        public StrikeApi(int timeout = 0, IWebProxy proxy = null)
        {
            _restClient = new RestClient(ApiBaseUrL) {Proxy = proxy, Timeout = timeout, UserAgent = "Strike.NET"};
        }

        /// <summary>
        ///     Retrieves a download link for a torrent.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        /// <returns>Returns a Uri for the torrent file.</returns>
        public Uri GetDownloadLink(string hash)
        {
            var request = new RestRequest("torrents/downloads/", Method.GET);
            request.AddParameter("hash", hash);
            var response = _restClient.Execute<DownloadResponse>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return new Uri(response.Data.Message);
        }

        /// <summary>
        ///     Gets the total number of indexed torrents.
        /// </summary>
        /// <returns>Returns the number of torrents.</returns>
        public int GetTorrentCount()
        {
            var request = new RestRequest("torrents/count/", Method.GET);
            var response = _restClient.Execute<CountResponse>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return response.Data.IndexedTorrents;
        }

        /// <summary>
        ///     Retrieves information for a torrent.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        public TorrentInfo GetInfo(string hash)
        {
            var results = GetInfo(new[] {hash});
            return results.FirstOrDefault();
        }

        /// <summary>
        ///     Retrieves information for a set of torrents.
        /// </summary>
        /// <param name="hashes">The torrent hashes.</param>
        public TorrentInfo[] GetInfo(string[] hashes)
        {
            var results = new List<TorrentInfo>();

            var request = new RestRequest("torrents/info/", Method.GET);
            request.AddParameter("hashes", string.Join(",", hashes));

            var response = _restClient.Execute<TorrentInfoResponse>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            if (response.ErrorException != null)
                throw response.ErrorException;

            // todo refactor this using a custom serializer
            // or something similar, currently this feels
            // like a very hacky deserialization
            foreach (var result in response.Data)
            {
                //don't add stuff that isn't really TorrentInfo
                results.AddRange(result.Where(resultObj => resultObj.TorrentHash != null));
            }

            return results.ToArray();
        }

        public TorrentSearchResult[] Search(string query)
        {
            var results = new List<TorrentSearchResult>();

            var request = new RestRequest("torrents/search/", Method.GET);
            request.AddParameter("q", query);
            var response = _restClient.Execute<TorrentSearchResponse>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            if (response.ErrorException != null)
                throw response.ErrorException;

            // todo refactor this using a custom serializer
            // or something similar, currently this feels
            // like a very hacky deserialization
            foreach (var result in response.Data)
            {
                //don't add stuff that isn't really TorrentSearchResult
                results.AddRange(result.Where(x => x.TorrentTitle != null));
            }

            return results.ToArray();
        }
    }
}