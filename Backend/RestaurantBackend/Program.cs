using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

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

		app.MapControllers();

		app.Run();
	}
}