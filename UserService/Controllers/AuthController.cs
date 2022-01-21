using BaseApi.Controllers;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Model.DBModel;
using Model.Emun;
using Model.InputDto.Auth;
using Model.Internal;
using Model.OutputDto;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using DM = Model.DBModel;

namespace UserService.Controllers
{
    public class AuthController : BaseController
    {
        private readonly IConfiguration _configuration;
        public AuthController(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<ApiResponse> Authenticate(LoginInput dto)
        {
            if (string.IsNullOrEmpty(dto.LoginName))
                return GetResponse(ApiCode.CantEmptyLoginName);
            if (string.IsNullOrEmpty(dto.Password))
                return GetResponse(ApiCode.CantEmptyPassword);
            var user = await _Db.User.Where(w => !w.IsDeleted && w.LoginName == dto.LoginName && w.Password == dto.Password.MD5Encrypt(32)).FirstOrDefaultAsync();
            if (user == null)
                return GetResponse(ApiCode.WrongPassword);
            return Success(await GenerateToken(user));
        }

        /// <summary>
        /// 生成jwt令牌
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        private async Task<string> GenerateToken(User user)
        {
            var dic = (await HttpHelper.Get<ApiResponse<List<DM.Dictionary>>>(ConstValue.GatewayUrl + "Dictionary/Get?Type=JwtConfig")).Data.FirstOrDefault();
            var jwtConfig = JsonConvert.DeserializeObject<JwtConfig>(dic?.Value ?? "");

            //秘钥，就是标头，这里用Hmacsha256算法，需要256bit的密钥
            var securityKey = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtConfig.Secrect)), SecurityAlgorithms.HmacSha256);

            //相当于有效载荷
            var claims = new Claim[] {
                new Claim(JwtRegisteredClaimNames.Iss,jwtConfig.Iss),
                new Claim("Guid",Guid.NewGuid().ToString("D")),
                new Claim("Uid",user.Id.ToString()),
                new Claim(ClaimTypes.Role,"system"),
                new Claim(ClaimTypes.Role,"admin"),
    };
            SecurityToken securityToken = new JwtSecurityToken(
                signingCredentials: securityKey,
                expires: DateTime.Now.AddMinutes(jwtConfig.Expires),//过期时间
                claims: claims
            );
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }
    }
}
