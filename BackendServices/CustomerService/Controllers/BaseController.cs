using CustomerService.Models;
using Microsoft.AspNetCore.Mvc;

namespace CustomerService.Controllers
{
    public class BaseController : ControllerBase
    {
        protected ActionResult<BaseResponseModel> GenerateJson<T>(T body, int status, string message)
        {
            BaseResponseModel response = new BaseResponseModel()
            {
                Status = status,
                Message = message,
                Body = body
            };
            return Ok(response);
        }

        protected ActionResult<BaseResponseModel> GenerateExceptionJson(int status, string message)
        {
            BaseResponseModel response = new BaseResponseModel()
            {
                Status = status,
                Message = message
            };
            return Ok(response);
        }
    }
}
