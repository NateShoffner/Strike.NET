#region

using Newtonsoft.Json;
using RestSharp;
using RestSharp.Deserializers;

#endregion

namespace StrikeNET
{
    internal class RestSharpJsonNetDeserializer : IDeserializer
    {
        private readonly JsonSerializerSettings _settings;

        public RestSharpJsonNetDeserializer(JsonSerializerSettings settings)
        {
            _settings = settings;
        }

        public T Deserialize<T>(IRestResponse response)
        {
            return JsonConvert.DeserializeObject<T>(response.Content, _settings);
        }

        public string RootElement { get; set; }
        public string Namespace { get; set; }
        public string DateFormat { get; set; }
    }
}