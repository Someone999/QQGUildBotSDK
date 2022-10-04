using Newtonsoft.Json;

namespace QqChannelRobotSdk.Models;

public class User : IEqualityComparer<User>
{
    [JsonProperty("id")]
    public string Id { get; set; } = "";
    
    [JsonProperty("username")]
    public string UserName { get; set; } = "";

    [JsonProperty("avatar")]
    public string? AvatarUrl { get; set; }
    
    [JsonProperty("bot")]
    public bool IsBot { get; set; }

    [JsonProperty("union_openid")]
    public string? UnionOpenId { get; set; }
    
    [JsonProperty("union_user_account")]
    public string? UnionUserAccount { get; set; }



    public static User Empty { get; } = new();

    public bool Equals(User? x, User? y)
    {
        if (ReferenceEquals(x, y))
            return true;
        if (ReferenceEquals(x, null))
            return false;
        if (ReferenceEquals(y, null))
            return false;
        if (x.GetType() != y.GetType())
            return false;
        return x.Id == y.Id;
    }
    public int GetHashCode(User obj)
    {
        return obj.Id.GetHashCode();
    }
}