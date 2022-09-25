using System.Text.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using QqChannelRobotSdk.WebSocket.Models;
using QqChannelRobotSdk.WebSocket.Packets.ClientPackets;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace QqChannelRobotSdk.JsonConverters;

public class ShardJsonConverter : Newtonsoft.Json.JsonConverter<Shard>
{

    public override void WriteJson(JsonWriter writer, Shard value, JsonSerializer serializer)
    {
       
        //writer.WritePropertyName("shard");
        if (value.Equals(Shard.None))
        {
            writer.WriteNull();
            return;
        }
        writer.WriteStartArray();
        writer.WriteValue(value.Current);
        writer.WriteValue(value.Total);
        writer.WriteEndArray();
    }
    public override Shard ReadJson(JsonReader reader, Type objectType, Shard existingValue, bool hasExistingValue, JsonSerializer serializer)
    {
        Shard shard = new Shard();
        
        
        while (reader.TokenType != JsonToken.StartArray)
        {
            reader.Read();
        }

        reader.Read();
        if (reader.TokenType == JsonToken.Integer)
        {
            shard.Current = reader.ReadAsInt32() ?? 0;
        }
        
        reader.Read();
        if (reader.TokenType == JsonToken.Integer)
        {
            shard.Total = reader.ReadAsInt32() ?? 0 + 1;
        }

        return shard;
    }
}