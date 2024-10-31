using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace API.Controllers;
public class ApiResponseService(ConstructionContext context) : Controller
{
    protected readonly ConstructionContext _context = context;

    protected IActionResult CreateResult(int status, string message, object? result)
    {
        var res = new ApiResponse(status, message, result, Request.Path);
        if (Request.Path.Value == null)
            return StatusCode(status, res);

        if (!Request.Path.Value.Contains("health") && !Request.Path.Value.Contains("KeepAlive"))
            Console.WriteLine($"Status: {status}, Path: {Request.Path.Value}");
        else
            Console.WriteLine($"Status: {status}, Path: {Request.Path.Value}");

        return StatusCode(status, res);
    }

    protected IActionResult CreateResult(object res)
    {
        return CreateResult(200, "", res);
    }

    protected IActionResult CreateResult(string message)
    {
        return CreateResult(200, message, null);
    }

    protected IActionResult CreateResult(int status, string message)
    {
        return CreateResult(status, message, null);
    }

    protected IActionResult CreateResult()
    {
        return CreateResult(200, "", null);
    }

    protected IActionResult CreateResult(int status, object response)
    {
        return CreateResult(status, "", response);
    }

    protected IActionResult CreateResult(ApiResponse response)
    {
        return response == null
            ? CreateResult(200, "", null)
            : CreateResult(response.Status, response.Message, response.Result);
    }

    protected ApiResponse CreateApiResponse(int status, string message = "", object? result = null)
    {
        return new ApiResponse(status, message, result, Request.Path);
    }

}