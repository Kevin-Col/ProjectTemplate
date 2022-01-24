using Model.Internal;
using System.Security.Claims;

namespace BaseApi
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor _accessor;
        private readonly IEnumerable<Claim> _claims;
        public bool IsAuthenticated => _accessor.HttpContext.User?.Identity?.IsAuthenticated ?? false;

        public CurrentUser(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            _claims = _accessor.HttpContext?.User?.Claims;
        }

        public string UserId
        {
            get
            {
                var value = _claims.FirstOrDefault(f => f.Type == JwtClaim.UserId)?.Value;
                if (IsAuthenticated && string.IsNullOrEmpty(value))
                    throw new ArgumentException(nameof(JwtClaim.UserId));
                return value;
            }
        }
    }
}
