using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EnderStorageDB.Structures
{
    internal class ColorCodeConverter : JsonConverter<ColorCode>
    {
        public override ColorCode Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return ColorCode.Deserialize(reader.GetString());
        }

        public override void Write(Utf8JsonWriter writer, ColorCode value, JsonSerializerOptions options)
        {
            writer.WriteStringValue(ColorCode.Serialize(value));
        }

        public override ColorCode ReadAsPropertyName(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            return Read(ref reader, typeToConvert, options);
        }
        public override void WriteAsPropertyName(Utf8JsonWriter writer, ColorCode value, JsonSerializerOptions options)
        {
            writer.WritePropertyName(ColorCode.Serialize(value));
        }
    }
}
