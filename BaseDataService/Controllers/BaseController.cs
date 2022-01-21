using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.Emun;
using Model.OutputDto;
using Common;
using Common.Attributes;
using DB;
using AutoMapper;

namespace BaseDataService.Controllers
{

    [Route("[controller]/[action]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        [FromService] public Context _Db { get; set; }
        [FromService] public IMapper _Mapper { get; set; }
        protected ApiResponse<string> Success() => Success("");
        protected ApiResponse<T> Success<T>(T data) => GetResponse(ApiCode.Success, ApiCode.Success.GetDesc(), data);

        protected ApiResponse<T> Faild<T>(T data) => GetResponse(ApiCode.Faild, ApiCode.Faild.GetDesc(), data);

        public ApiResponse<T> GetResponse<T>(ApiCode code, string msg, T data) => new ApiResponse<T>(code, msg, data);

    }
}
