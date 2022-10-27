namespace QqGuildRobotSdk.Response;


public class ApiResponse<T, TError>
{
    public T? ResponseObject { get; }
    public TError? ErrorObject { get; }
    public bool Success { get; }
    internal ApiResponse(T? responseObject,TError? errorObject)
    {
        ResponseObject = responseObject;
        ErrorObject = errorObject;
        Success = errorObject == null && responseObject != null;
    }
}