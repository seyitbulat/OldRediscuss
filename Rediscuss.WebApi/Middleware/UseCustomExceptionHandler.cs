using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Diagnostics;
using Rediscuss.Business.CustomExceptions;
using System.Text.Json;

namespace Rediscuss.WebApi.Middleware
{
	public static class UseCustomExceptionHandler
	{
		public static void UseCustomException(this IApplicationBuilder app)
		{
			app.UseExceptionHandler(exceptionhandlerApp =>
			{
				exceptionhandlerApp.Run(async context =>
				{
					context.Response.ContentType = "application/json";

					var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();
					var statusCode = StatusCodes.Status500InternalServerError;

					switch (exceptionFeature.Error)
					{
						case BadRequesException:
							statusCode = StatusCodes.Status400BadRequest; 
							break;
						case NotFoundException:
							statusCode = StatusCodes.Status404NotFound;
							break;
					}

					context.Response.StatusCode = statusCode;
					var response = ApiResponse<List<NoData>>.Fail(statusCode, exceptionFeature.Error.Message);

					// LOGGING

					await context.Response.WriteAsync(JsonSerializer.Serialize(response));
				});
			});
		}
	}
}
