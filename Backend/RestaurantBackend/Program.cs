using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend;

public class Program
{
	public static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		builder.Services.AddControllers();

		builder.Services.AddAuthorization();

		builder.Services.AddDbContext<PosDbContext>(options =>
			                                            options.UseSqlite(
				                                            "Data Source=pos.db"));

		builder.Services.AddRestaurantBackendHandlers();
		
		// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
		builder.Services.AddEndpointsApiExplorer();
		builder.Services.AddSwaggerGen(options =>
		{
			options.CustomSchemaIds(x => x.FullName?.Replace("+", ".", StringComparison.Ordinal));
		});

		var app = builder.Build();

		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.UseSwagger();
			app.UseSwaggerUI();
		}

		app.UseHttpsRedirection();

		app.UseAuthorization();

		app.MapRestaurantBackendEndpoints();
		app.MapControllers();

		app.Run();
	}
}