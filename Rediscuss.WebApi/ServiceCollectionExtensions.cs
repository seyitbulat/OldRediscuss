using Infrastructure.Utilities.Security.JWT;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

namespace Rediscuss.WebApi
{
    public static class ServiceCollectionExtensions
	{
		public static void AddApiService(this IServiceCollection services, IConfiguration configuration)
		{
			services.AddControllers(opt =>
			{
				opt.InputFormatters.Insert(0, MyJPIF.GetJsonPatchInputFormatter());
			})
				.AddJsonOptions(opt => opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
						

			var tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
			services.AddAuthentication(opt =>
			{
				opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
				opt.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = tokenOptions.Issuer,
					ValidAudience = tokenOptions.Audience,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey)),
					ClockSkew = TimeSpan.Zero
				};

			});







			services.AddEndpointsApiExplorer();
			services.AddSwaggerGen();

		}
	}
}
