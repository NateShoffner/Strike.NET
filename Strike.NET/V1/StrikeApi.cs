#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using StrikeNET.Deserialization;
using StrikeNET.V1.Responses;

#endregion

namespace StrikeNET.V1
{
    /// <summary>
    /// Represents the Strike API service.
    /// </summary>
    public class StrikeApi
    {
        private const int MaxInfoQueries = 50;
        private const int MinSearchQueryLength = 4;

        private const string ApiBaseUrL = "http://getstrike.net/api/";

        private readonly RestClient _restClient;

        /// <summary>
        /// Initializes a new StrikeApi instance.
        /// </summary>
        /// <param name="timeout">The timeout used for requests.</param>
        /// <param name="proxy">The proxy settings to use for requests.</param>
        public StrikeApi(int timeout = 0, IWebProxy proxy = null)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            _restClient = new RestClient(ApiBaseUrL) { Proxy = proxy, Timeout = timeout, UserAgent = Constants.UserAgent };
            _restClient.AddHandler("application/json", new RestSharpJsonNetDeserializer(serializerSettings));
        }

        private IRestResponse<T> Execute<T>(IRestRequest request) where T : new()
        {
            var response = _restClient.Execute<T>(request);

            if (response.ErrorException != null)
                throw response.ErrorException;

            return response;
        }

        private IRestResponse Execute(IRestRequest request)
        {
            var response = _restClient.Execute(request);

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
            var request = new RestRequest("torrents/downloads/", Method.GET);
            request.AddParameter("hash", hash);
            var response = Execute<DownloadResponse>(request);
            return new Uri(response.Data.Message);
        }

        /// <summary>
        ///     Gets the total number of indexed torrents.
        /// </summary>
        /// <returns>Returns the number of torrents.</returns>
        public int GetTorrentCount()
        {
            var request = new RestRequest("torrents/count/", Method.GET);
            var response = Execute<CountResponse>(request);
            return response.Data.IndexedTorrents;
        }

        /// <summary>
        ///     Retrieves information for a torrent.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        public TorrentInfoResult GetInfo(string hash)
        {
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

            var response = Execute(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            var array = (JArray) JsonConvert.DeserializeObject(response.Content);

            var responseContent = (array == null ? null : new TorrentInfoResponse()
            {
                Torrents = array.OfType<JArray>().SelectMany(a => JsonConvert.DeserializeObject<List<TorrentInfoResult>>(a.ToString())).ToList()
            });

            if (responseContent != null)
                results.AddRange(responseContent.Torrents);

            return results.ToArray();
        }

        //DescriptionsResponse
        /// <summary>
        ///     Gets a torrent description.
        /// </summary>
        /// <param name="hash">The torrent hash.</param>
        /// <returns>Returns base64 decoded description string.</returns>
        public string GetDescriptions(string hash)
        {
            //despite the parameter being pluralized, it only seems to accept a single query
            var request = new RestRequest("torrents/descriptions/", Method.GET);
            request.AddParameter("hashes", hash);

            var response = Execute<DescriptionsResponse>(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var data = Convert.FromBase64String(response.Data.Message);
            return Encoding.UTF8.GetString(data);
        }
        /// <summary>
        ///     Performs a torrent search.
        /// </summary>
        /// <param name="query">Torrent search query.</param>
        /// <returns>Returns an array of search results.</returns>
        public TorrentSearchResult[] Search(string query)
        {
            if (query.Trim().Length < MinSearchQueryLength)
                throw new StrikeException("Query must be at least 4 characters long without whitespace");

            var results = new List<TorrentSearchResult>();

            var request = new RestRequest("torrents/search/", Method.GET);
            request.AddParameter("q", query);

            var response = Execute(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            var array = (JArray) JsonConvert.DeserializeObject(response.Content);

            var responseContent = (array == null ? null : new TorrentSearchResponse()
            {
                SearchResults = array.OfType<JArray>().SelectMany(a => JsonConvert.DeserializeObject<List<TorrentSearchResult>>(a.ToString())).ToList()
            });

            if (responseContent != null)
                results.AddRange(responseContent.SearchResults);

            return results.ToArray();
        }

        /// <summary>
        /// Performs a combined torrent search and info lookup.
        /// </summary>
        /// <param name="query">Torrent search query.</param>
        /// <returns>Returns an array of torrent</returns>
        public TorrentInfoSearchResult[] InfoSearch(string query)
        {
            var results = new List<TorrentInfoSearchResult>();

            var searchResults = new List<TorrentSearchResult>(Search(query));

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