using Newtonsoft.Json;

namespace API.Controllers;
public class ApiResponse
{
    public string Message { get; set; }
    public int Status { get; set; }
    public string Url { get; set; }
    public object Result { get; set; }

    public ApiResponse(int status, string message, object result, string url)
    {
        Message = message;
        Status = status;
        Result = result;
        Url = url;
    }

    public ApiResponse(int status, string message, object result)
    {
        Message = message;
        Status = status;
        Result = result;
        Url = "";
    }

    public ApiResponse(int status, string message)
    {
        Message = message;
        Status = status;
        Result = null;
        Url = "";
    }

    public string ToJsonResult()
    {
        return JsonConvert.SerializeObject(Result);
    }
}