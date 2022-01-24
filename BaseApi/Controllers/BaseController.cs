using AutoMapper;
using Common;
using Common.Attributes;
using DB;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Model.Emun;
using Model.OutputDto;

namespace BaseApi.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BaseController : ControllerBase
    {
        [FromService] public Context _Context { get; set; }
        [FromService] public IMapper _Mapper { get; set; }
        protected ApiResponse Success() => Success("");
        protected ApiResponse Faild() => Faild("");
        protected ApiResponse GetResponse(ApiCode code, string? msg = null) => GetResponse(code, msg, "");
        protected ApiResponse<T> Success<T>(T data) => GetResponse(ApiCode.Success, ApiCode.Success.GetDesc(), data);

        protected ApiResponse<T> Faild<T>(T data) => GetResponse(ApiCode.Faild, ApiCode.Faild.GetDesc(), data);

        protected ApiResponse<T> GetResponse<T>(ApiCode code, string? msg, T data) => new ApiResponse<T>(code, msg ?? code.GetDesc(), data);
    }
}
