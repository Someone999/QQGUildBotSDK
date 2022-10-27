using Newtonsoft.Json;
using QqGuildRobotSdk.WebSocket.Packets.ClientPackets;
using JsonSerializer = Newtonsoft.Json.JsonSerializer;

namespace QqGuildRobotSdk.JsonConverters;

public class ShardJsonConverter : Newtonsoft.Json.JsonConverter<Shard>
{

    private static object Locker { get; } = new();
    public override void WriteJson(JsonWriter writer, Shard value, JsonSerializer serializer)
    {
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
        //reader.Read();
        shard.Current = reader.ReadAsInt32() ?? 0;
        shard.Total = reader.ReadAsInt32() ?? 0 + 1;
        reader.Read();
        return shard;

    }
}