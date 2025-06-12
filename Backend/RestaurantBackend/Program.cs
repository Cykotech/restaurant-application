using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Features;
using RestaurantBackend.Features.Tables.GetAll;
using RestaurantBackend.Features.Tables.OpenTable;

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

		builder.Services
		       .AddScoped<IHandler<OpenTableRequest, OpenTableResponse>,
			       OpenTableHandler>();
		builder.Services.AddScoped<IHandler<GetAllRequest, GetAllResponse>, GetAllHandler>();

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

		app.MapControllers();

		app.Run();
	}
}