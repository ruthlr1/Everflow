using Everflow.EventPlanner.Application.Features.Auth.Token;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Everflow.EventPlanner.API.Register
{
    public class RegisterToken
    {
        public static void Register(IServiceCollection services)
        {
            string key = "870A83A5-99A2-4F78-B005-D3A4E9E5A938"; // guid
            services.AddAuthentication(x => 
            { 
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
                {
                    x.RequireHttpsMetadata = false;
                    x.SaveToken = true;
                    x.TokenValidationParameters = new TokenValidationParameters
                    { 
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
                        ValidateIssuer = false,
                        ValidateAudience = false,
                    
                    };
                });

            services.AddSingleton<JwtAuthenticationManager>(new JwtAuthenticationManager(key));
        }
    }
}
