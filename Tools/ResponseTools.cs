using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QqGuildRobotSdk.Response;

namespace QqGuildRobotSdk.Tools;

public static class ResponseTools
{
    public static async Task<ApiResponse<TData?, GeneralErrorResponse>> GetReturnValueAsync<TData>(HttpResponseMessage responseMessage)
    {
        string responseStr = await responseMessage.Content.ReadAsStringAsync();
        JToken jToken = JsonConvert.DeserializeObject<JToken>(responseStr) ?? new JObject();

        bool hasErrorJson = jToken is JObject jObject && jObject.ContainsKey("code") && jObject.ContainsKey("message");
        bool hasErrorHttp = !responseMessage.IsSuccessStatusCode;
        bool hasError = hasErrorHttp || hasErrorJson;
        if (hasError)
        {
            return new ApiResponse<TData?, GeneralErrorResponse>(default, GeneralErrorResponse.Create(jToken, responseMessage));
        }
        var data = jToken.ToObject<TData>();
        return new ApiResponse<TData?, GeneralErrorResponse>(data, null);
    }

    public static async Task<GeneralErrorResponse?> GetReturnValueAsync(HttpResponseMessage responseMessage)
    {
        string responseStr = await responseMessage.Content.ReadAsStringAsync();
        JToken jToken = JsonConvert.DeserializeObject<JToken>(responseStr) ?? new JObject();

        bool hasErrorJson = jToken is JObject jObject && jObject.ContainsKey("code") && jObject.ContainsKey("message");
        bool hasErrorHttp = !responseMessage.IsSuccessStatusCode;
        bool hasError = hasErrorHttp || hasErrorJson;

        return hasError ? GeneralErrorResponse.Create(jToken, responseMessage) : null;
    }
}