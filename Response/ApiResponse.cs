namespace QqChannelRobotSdk.Response;


public class ApiResponse<T, TError>
{
    public T? ResponseObject { get; }
    public TError? ErrorObject { get; }
    public bool Succsee { get; }
    internal ApiResponse(T? responseObject,TError? errorObject)
    {
        ResponseObject = responseObject;
        ErrorObject = errorObject;
        Succsee = errorObject == null && responseObject != null;
    }
}