using BaseApi.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Model.OutputDto;

namespace UserService.Controllers
{
    public class UserController : BaseController
    {
        [HttpGet]
        public async Task<ApiResponse> UserInfo(int id)
        {
            return Success(await _Context.User.FindAsync(id));
        }
    }
}
