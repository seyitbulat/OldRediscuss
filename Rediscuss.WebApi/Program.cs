using Autofac.Core;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Rediscuss.Business;
using Rediscuss.WebApi.Middleware;
using System.Reflection;
using System.Text.Json.Serialization;

namespace Rediscuss.WebApi
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddApiService(builder.Configuration);
			builder.Services.AddBusinessServices();


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseAuthorization();

			app.UseCustomException();
			app.MapControllers();

			app.Run();
		}
	}
}