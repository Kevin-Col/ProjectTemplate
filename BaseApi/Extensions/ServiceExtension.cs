using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Model.Internal;
using System.Text;

namespace BaseApi.Extensions
{
    public static class ServiceExtension
    {
        public static IServiceCollection ConfigJwt(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));
            var jwtconfig = new JwtConfig();
            configuration.GetSection("Jwt").Bind(jwtconfig);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtconfig.Secrect)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtconfig.Iss,
                    ValidateAudience = false,
                    ValidateActor = false,
                    ValidateLifetime = true,

                };
            });
            return services;
        }
    }
}
