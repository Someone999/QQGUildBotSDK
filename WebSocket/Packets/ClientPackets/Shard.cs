namespace QqGuildRobotSdk.WebSocket.Packets.ClientPackets;

public struct Shard
{
    public Shard(int current, int total)
    {
        Current = current;
        Total = total;
    }
    
    public int Current { get; set; }
    public int Total { get; set; }

    public static Shard OneShard { get; } = new Shard(0, 1);
    public static Shard None { get; } = new Shard(-1, -1);

    public override bool Equals(object? obj)
    {
        if (obj is Shard shard)
        {
            return Equals(shard);
        }
        
        return false;
    }
    public bool Equals(Shard other)
    {
        return Current == other.Current && Total == other.Total;
    }
    public override int GetHashCode()
    {
        return HashCode.Combine(Current, Total);
    }

}