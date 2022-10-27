using System.Net;
using Newtonsoft.Json.Linq;

namespace QqGuildRobotSdk.Response;

public class GeneralErrorResponse
{
    public static GeneralErrorResponse Create(JToken responseJson, HttpResponseMessage responseMessage)
    {
        int code = responseJson["code"]?.ToObject<int>() ?? 0;
        string message = responseJson["message"]?.ToObject<string>() ?? "null";
        var httpStatusCode = responseMessage.StatusCode;
        var httpStatusMessage = responseMessage.StatusCode.ToString();
        return new GeneralErrorResponse(code, message, httpStatusCode, httpStatusMessage);
    }
    public GeneralErrorResponse(int code, string message, HttpStatusCode httpResponseCode, string httpResponseMessage)
    {
        Code = code;
        Message = message;
        HttpResponseCode = httpResponseCode;
        HttpResponseMessage = httpResponseMessage;
    }
    public int Code { get; }
    public string Message { get; } = "";
    public HttpStatusCode HttpResponseCode { get; }
    public string HttpResponseMessage { get; }

}