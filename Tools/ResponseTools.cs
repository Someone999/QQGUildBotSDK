using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using QqChannelRobotSdk.Response;

namespace QqChannelRobotSdk.Tools;

public static class ResponseTools
{
    public static async Task<ApiResponse<TData?, GeneralErrorResponse>> GetReturnValueAsync<TData>(HttpResponseMessage responseMessage)
    {
        string responseStr = await responseMessage.Content.ReadAsStringAsync();
        JObject? jObject = JsonConvert.DeserializeObject<JObject>(responseStr) ?? new JObject();

        bool hasErrorJson = jObject.ContainsKey("code") && jObject.ContainsKey("message");
        bool hasErrorHttp = !responseMessage.IsSuccessStatusCode;
        bool hasError = hasErrorHttp || hasErrorJson;
        if (hasError)
        {
            return new ApiResponse<TData?, GeneralErrorResponse>(default, GeneralErrorResponse.Create(jObject, responseMessage));
        }
        var data = jObject.ToObject<TData>();
        return new ApiResponse<TData?, GeneralErrorResponse>(data, null);
    }

    public static async Task<GeneralErrorResponse?> GetReturnValueAsync(HttpResponseMessage responseMessage)
    {
        string responseStr = await responseMessage.Content.ReadAsStringAsync();
        JObject? jObject = JsonConvert.DeserializeObject<JObject>(responseStr) ?? new JObject();
        bool hasErrorJson = jObject.ContainsKey("code") && jObject.ContainsKey("message");
        bool hasErrorHttp = !responseMessage.IsSuccessStatusCode;
        bool hasError = hasErrorHttp || hasErrorJson;

        return hasError ? GeneralErrorResponse.Create(jObject, responseMessage) : null;
    }
}