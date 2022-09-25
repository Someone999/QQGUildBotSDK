using System.Text;

namespace QqChannelRobotSdk.Tools;

public class UrlBuilder
{
    private Dictionary<string, string> _arguments = new Dictionary<string, string>();
    public string BaseUrl { get; set; }
    
    private List<string> _subLevels = new();
    public bool IsApiUrl { get; set; }
    public UrlBuilder(string baseUrl, bool isApiUrl = false)
    {
        BaseUrl = baseUrl;
        if (!isApiUrl && !BaseUrl.EndsWith("/"))
        {
            BaseUrl += "/";
        }
    }

    public UrlBuilder AddSubLevel(string subLevel)
    {
        if (subLevel.StartsWith("/"))
        {
            subLevel = subLevel.Substring(1);
        }
        
        _subLevels.Add(subLevel);
        return this;
    }

    public UrlBuilder RemoveSubLevel(string subLevel)
    {
        if (subLevel.StartsWith("/"))
        {
            subLevel = subLevel.Substring(1);
        }
        
        _subLevels.Remove(subLevel);
        return this;
    }

    public UrlBuilder ClearSubLevel()
    {
        _subLevels.Clear();
        return this;
    }
    public UrlBuilder AddArgument(string key, object val)
    {
        if (_arguments.ContainsKey(key))
        {
            return this;
        }
        
        _arguments.Add(key, val.ToString() ?? "null");
        return this;
    }
    
    public UrlBuilder AddArgumentWhenNotNull(string key, object? val)
    {
        if (val == null)
        {
            return this;
        }
        
        if (_arguments.ContainsKey(key))
        {
            return this;
        }
        
        _arguments.Add(key, val.ToString() ?? "null");
        return this;
    }

    public UrlBuilder SetArgument(string key, object val)
    {
        if (!_arguments.ContainsKey(key))
        {
            AddArgument(key, val.ToString() ?? "null");
        }

        _arguments[key] = val.ToString() ?? "null";
        return this;
    }

    public UrlBuilder RemoveArgument(string key)
    {
        _arguments.Remove(key);
        return this;
    }

    public UrlBuilder ClearArgument()
    {
        _arguments.Clear();
        return this;
    }

    public string Build()
    {
        StringBuilder urlStringBuilder = new(BaseUrl);

        if (_subLevels.Count > 0)
        {
            for (int i = 0; i < _subLevels.Count; i++)
            {
                urlStringBuilder.Append(_subLevels[i]);
                if (i < _subLevels.Count - 1)
                {
                    urlStringBuilder.Append('/');
                }
            }
        }
        

        if (_arguments.Count == 0)
        {
            return urlStringBuilder.ToString();
        }
        
        if (urlStringBuilder.ToString().EndsWith("/"))
        {
            urlStringBuilder.Remove(urlStringBuilder.Length - 1, 1);
        }
        
        urlStringBuilder.Append('?');

        for (int i = 0; i < _arguments.Count; i++)
        {
            var currentPair = _arguments.ElementAt(i);
            urlStringBuilder.Append($"{currentPair.Key}={currentPair.Value}");
            if (i < _arguments.Count - 1)
            {
                urlStringBuilder.Append('&');
            }
        }

        return urlStringBuilder.ToString();
    }
}