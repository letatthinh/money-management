﻿using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Common.CustomJsonConverters
{
    public class DateOnlyJsonConverter : JsonConverter<DateOnly>
    {
        private const string _dateFormat = "yyyy-mm-dd";

        // Serialize
        public override void Write(Utf8JsonWriter writer, DateOnly value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(value.ToString(_dateFormat, CultureInfo.InvariantCulture));
        }

        // Deserialize
        public override DateOnly Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return DateOnly.ParseExact(reader.GetString()!, _dateFormat, CultureInfo.InvariantCulture);
        }
    }
}
