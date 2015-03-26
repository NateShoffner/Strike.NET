#region

using System;
using Newtonsoft.Json;

#endregion

namespace StrikeNET.V1.Converters
{
    /// <summary>
    ///     Converts string-based file size format (ex. 322.69 MB) to bytes.
    /// </summary>
    internal class FileSizeStringConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(value.ToString());
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (objectType == typeof (string) && reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            return ConvertFileSize(reader.Value as string);
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof (string);
        }

        private static long ConvertFileSize(string sizeStr)
        {
            long size = 0;
            var split = sizeStr.Split(' ');

            if (split.Length > 1)
            {
                decimal amount;
                if (decimal.TryParse(split[0], out amount))
                {
                    var unit = split[1];

                    if (!string.IsNullOrEmpty(unit))
                    {
                        switch (unit.ToUpper())
                        {
                            case "KB":
                                size = (long) (amount*1024);
                                break;
                            case "MB":
                                size = (long) (amount*(1024*1024));
                                break;
                            case "GB":
                                size = (long) (amount*(1024*1024*1024));
                                break;
                            case "TB":
                                size = (long) (amount*(1024L*1024*1024*1024));
                                break;
                            default:
                                size = (long) amount;
                                break;
                        }
                    }
                }
            }

            return size;
        }
    }
}