#region

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace StrikeNET.V2.Converters
{
    internal class FileInfoConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            var files = new List<TorrentFileInfo>();

            Console.WriteLine("loading");
            var fileInfo = JObject.Load(reader);

            var fileNamesArray = fileInfo.SelectToken("file_names") as JArray;
            var fileLengthsArray = fileInfo.SelectToken("file_lengths") as JArray;

            if (fileNamesArray != null && fileLengthsArray != null)
            {
                var fileNames = new List<string>(fileNamesArray.Values<string>());
                var fileLengths = new List<long>(fileLengthsArray.Values<long>());

                //increment using lengths since 'file_names'
                //includes directories as well
                var total = fileLengths.Count;
                for (var i = 0; i < total; i++)
                {
                    var fi = new TorrentFileInfo(fileNames[i].Trim(), fileLengths[i]);
                    files.Add(fi);
                }
            }

            return files;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(List<TorrentFileInfo>);
        }
    }
}