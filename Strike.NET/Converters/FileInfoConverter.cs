﻿#region

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

#endregion

namespace StrikeNET.Converters
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

            var fileInfo = JArray.Load(reader);

            var o = fileInfo.First;

            if (o != null)
            {
                var fileNamesArray = o.SelectToken("file_names") as JArray;
                var fileLengthsArray = o.SelectToken("file_lengths") as JArray;

                if (fileNamesArray != null && fileLengthsArray != null)
                {
                    var fileNames = new List<string>(fileNamesArray.Values<string>());
                    var fileLengths = new List<long>(fileLengthsArray.Values<long>());

                    var total = fileNames.Count();
                    for (var i = 0; i < total; i++)
                    {
                        var fi = new TorrentFileInfo(fileNames[i], fileLengths[i]);
                        files.Add(fi);
                    }
                }
            }

            return files;
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (List<TorrentFileInfo>);
        }
    }
}