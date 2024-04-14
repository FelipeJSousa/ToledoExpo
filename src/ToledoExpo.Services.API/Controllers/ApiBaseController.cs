using Microsoft.AspNetCore.Mvc;
using ToledoCW.Services.Model;

namespace ToledoExpo.Services.API.Controllers;

public abstract class ApiBaseController : ControllerBase
{
    protected ApiBaseController()
    {
    }

    protected new IActionResult Response<T>(IEnumerable<T> obj) where T : class
    {
        return obj?.Any() == true
            ? Ok(new ApiResponse<IEnumerable<T>>(obj))
            : NoContent();
    }

    protected new IActionResult Response<T>(T obj) where T : class
    {
        return obj is not null ? Ok(new ApiResponse<T>(obj)) : NoContent();
    }

    protected IActionResult ResponseError(ApiResponseError obj)
    {
        return obj is not null ? Ok(new ApiResponse(obj)) : NoContent();
    }
}