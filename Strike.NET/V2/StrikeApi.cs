#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using RestSharp;
using StrikeNET.V2.Responses;

#endregion

namespace StrikeNET.V2
{
    /// <summary>
    ///     Represents the Strike API service.
    /// </summary>
    public class StrikeApi
    {
        private const int MaxInfoQueries = 50;
        private const int MinSearchQueryLength = 4;

        private const string ApiBaseUrL = "http://getstrike.net/api/v2/";

        private readonly RestClient _restClient;

        /// <summary>
        ///     Initializes a new StrikeApi instance.
        /// </summary>
        /// <param name="timeout">The timeout used for requests.</param>
        /// <param name="proxy">The proxy settings to use for requests.</param>
        public StrikeApi(int timeout = 0, IWebProxy proxy = null)
        {
           _restClient = new RestClient(ApiBaseUrL) {Proxy = proxy, Timeout = timeout, UserAgent = Common.GetUserAgent()};
        }

        private IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            var response = _restClient.Execute<T>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return response;
        }

        /// <summary>
        ///     Retrieves a download link for a torrent.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        /// <returns>Returns a Uri for the torrent file.</returns>
        public Uri GetDownloadLink(string hash)
        {
            if (hash == null)
                throw new ArgumentNullException("hash");

            var request = new RestRequest("torrents/download/", Method.GET);
            request.AddParameter("hash", hash);
            var response = Execute<DownloadResponse>(request);
            return response.Data.Url;
        }

        /// <summary>
        ///     Gets the total number of indexed torrents.
        /// </summary>
        /// <returns>Returns the number of torrents.</returns>
        public int GetTorrentCount()
        {
            var request = new RestRequest("torrents/count/", Method.GET);
            var response = Execute<CountResponse>(request);
            return response.Data.Message;
        }

        /// <summary>
        ///     Retrieves information for a torrent.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        public TorrentInfoResult GetInfo(string hash)
        {
            if (hash == null)
                throw new ArgumentNullException("hash");

            var results = GetInfo(new[] {hash});
            return results.FirstOrDefault();
        }

        /// <summary>
        ///     Retrieves information for a set of torrents.
        /// </summary>
        /// <param name="hashes">The torrent hashes.</param>
        /// <param name="truncateQueries">Queries will be truncated if they exceed the limit.</param>
        public TorrentInfoResult[] GetInfo(string[] hashes, bool truncateQueries = false)
        {
            if (hashes == null)
                throw new ArgumentNullException("hashes");

            var hashList = new List<string>(hashes);

            if (hashList.Count > MaxInfoQueries)
            {
                if (truncateQueries)
                    hashList = new List<string>(hashList.Take(MaxInfoQueries));
                else
                    throw new StrikeException(string.Format("Cannot exceed {0} info queries per request", MaxInfoQueries));
            }

            var results = new List<TorrentInfoResult>();

            var request = new RestRequest("torrents/info/", Method.GET);
            request.AddParameter("hashes", string.Join(",", hashList.ToArray()));

            var response = Execute<TorrentInfoResponse>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            if (response.Data != null)
                results.AddRange(response.Data.Torrents);

            return results.ToArray();
        }

        /// <summary>
        ///     Gets a torrent description.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        /// <returns>Returns base64 decoded description string.</returns>
        public string GetDescriptions(string hash)
        {
            if (hash == null)
                throw new ArgumentNullException("hash");

            var request = new RestRequest("torrents/descriptions/", Method.GET);
            request.AddParameter("hash", hash);

            var response = Execute<DescriptionsResponse>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var data = Convert.FromBase64String(response.Data.Message);
            return Encoding.UTF8.GetString(data);
        }

        /// <summary>
        ///     Performs a torrent search.
        /// </summary>
        /// <param name="phrase">Torrent search query.</param>
        /// <param name="category">Torrent category.</param>
        /// <param name="subCategory">Torrent subcategory.</param>
        /// <returns>Returns an array of search results.</returns>
        public TorrentSearchResult[] Search(string phrase, Category category = null, Subcategory subCategory = null)
        {
            if (phrase == null)
                throw new ArgumentNullException("phrase");

            if (phrase.Trim().Length < MinSearchQueryLength)
                throw new StrikeException("Query must be at least 4 characters long without whitespace");

            var results = new List<TorrentSearchResult>();

            var request = new RestRequest("torrents/search/", Method.GET);
            request.AddParameter("phrase", phrase);

            if (category != null)
                request.AddParameter("category", category.Name);
            if (subCategory != null)
                request.AddParameter("subcategory", subCategory.Name);

            var response = Execute<TorrentSearchResponse>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            if (response.Data != null)
                results.AddRange(response.Data.Torrents);

            return results.ToArray();
        }

        /// <summary>
        ///     Performs a combined torrent search and info lookup.
        /// </summary>
        /// <param name="phrase">Torrent search query.</param>
        /// <param name="category">Torrent category.</param>
        /// <param name="subCategory">Torrent subcategory.</param>
        /// <returns>Returns an array of torrent</returns>
        public TorrentInfoSearchResult[] InfoSearch(string phrase, Category category = null, Subcategory subCategory = null)
        {
            if (phrase == null)
                throw new ArgumentNullException("phrase");

            var results = new List<TorrentInfoSearchResult>();

            var searchResults = new List<TorrentSearchResult>(Search(phrase, category, subCategory));

            var hashes = searchResults.Select(x => x.TorrentHash);

            var infoResults = GetInfo(hashes.ToArray(), true);

            //this is a bit hacky, but it works
            foreach (var infoResult in infoResults)
            {
                var searchResult = searchResults.Find(x => x.TorrentHash == infoResult.TorrentHash);

                //this shouldn't ever be null, but just incase...
                if (searchResult != null)
                {
                    var r = new TorrentInfoSearchResult
                    {
                        //torrent data
                        TorrentHash = searchResult.TorrentHash,
                        TorrentTitle = searchResult.TorrentTitle,
                        TorrentCategory = searchResult.TorrentCategory,
                        SubCategory = searchResult.SubCategory,
                        Seeds = searchResult.Seeds,
                        Leeches = searchResult.Leeches,

                        //search data
                        Page = searchResult.Page,
                        DownloadLink = searchResult.DownloadLink,
                        RssFeed = searchResult.RssFeed,
                        DownloadCount = searchResult.DownloadCount,

                        //info
                        Files = infoResult.Files,
                        MagnetUri = infoResult.MagnetUri
                    };

                    results.Add(r);
                }
            }

            return results.ToArray();
        }
    }
}