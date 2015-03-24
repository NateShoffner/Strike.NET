﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using RestSharp;
using StrikeNET.Deserialization;
using StrikeNET.Responses;

#endregion

namespace StrikeNET
{
    public class StrikeApi
    {
        private const int MaxInfoQueries = 50;

        private const string ApiBaseUrL = "http://getstrike.net/api/";

        private readonly RestClient _restClient;

        public StrikeApi(int timeout = 0, IWebProxy proxy = null)
        {
            var serializerSettings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };

            _restClient = new RestClient(ApiBaseUrL) {Proxy = proxy, Timeout = timeout, UserAgent = "Strike.NET"};
            _restClient.AddHandler("application/json", new RestSharpJsonNetDeserializer(serializerSettings));
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
            if (hashes.Length > MaxInfoQueries)
                throw new StrikeException(string.Format("Cannot exceed {0} info queries per request", MaxInfoQueries));

            var results = new List<TorrentInfo>();

            var request = new RestRequest("torrents/info/", Method.GET);
            request.AddParameter("hashes", string.Join(",", hashes));

            var response = _restClient.Execute(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return results.ToArray();

            var array = (JArray) JsonConvert.DeserializeObject(response.Content);

            var responseContent = (array == null ? null : new TorrentInfoResponse()
            {
                Torrents = array.OfType<JArray>().SelectMany(a => JsonConvert.DeserializeObject<List<TorrentInfo>>(a.ToString())).ToList()
            });

            if (responseContent != null)
                results.AddRange(responseContent.Torrents);

            return results.ToArray();
        }

        /// <summary>
        ///     Performs a torrent search.
        /// </summary>
        /// <param name="query">Torrent search query.</param>
        /// <returns>Returns an array of search results.</returns>
        public TorrentSearchResult[] Search(string query)
        {
            var results = new List<TorrentSearchResult>();

            var request = new RestRequest("torrents/search/", Method.GET);
            request.AddParameter("q", query);

            var response = _restClient.Execute(request);

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
    }
}