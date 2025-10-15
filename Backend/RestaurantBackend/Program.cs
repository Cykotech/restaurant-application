using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Dtos;
using RestaurantBackend.Services.Sessions;

namespace RestaurantBackend;

public class Program
{
	public static void Main(string[] args)
	{
		var developmentPolicy = "_developmentPolicy";

		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();

		builder.Services.AddAuthorization();
		builder.Services.AddCors(options =>
		{
			options.AddPolicy(
				name: developmentPolicy,
				policy =>
				{
					policy.WithOrigins("http://localhost:5173")
					      .AllowAnyHeader()
					      .AllowAnyMethod();
				}
			);
		});

		builder.Services.AddSingleton<ISessionService, SessionService>();
		builder.Services.AddDbContext<PosDbContext>(options =>
			                                            options.UseSqlite(
				                                            "Data Source=pos.db"));

		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen();

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();
		app.UseCors(developmentPolicy);

		app.Use(async (context, next) =>
		{
			var path = context.Request.Path;

			if (path.StartsWithSegments("/api/auth"))
			{
				await next();

				return;
			}

			var header = context.Request.Headers["Authorization"].FirstOrDefault();

			if (header is null || !header.StartsWith("Bearer "))
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Unauthorized");

				return;
			}

			var token = header["Bearer ".Length..].Trim();

			var sessions =
				context.RequestServices.GetRequiredService<ISessionService>();

			if (!sessions.ValidateSession(token, out var staffId))
			{
				context.Response.StatusCode = StatusCodes.Status401Unauthorized;
				await context.Response.WriteAsync("Invalid or expired session");

				return;
			}

			context.Items["StaffId"] = staffId;

			await next();
		});

		app.MapControllers();
		app.MapPost("api/auth/login", async (
			            StaffLogin loginRequest, PosDbContext context,
			            ISessionService sessions) =>
		            {
			            var staff =
				            await context.Staff.FirstOrDefaultAsync(s => s.Pin ==
					            loginRequest.Pin);

			            if (staff is null) return Results.Unauthorized();

			            var token = sessions.CreateSession(staff.Id);

			            return Results.Ok(token);
		            });

		app.Run();
	}
}