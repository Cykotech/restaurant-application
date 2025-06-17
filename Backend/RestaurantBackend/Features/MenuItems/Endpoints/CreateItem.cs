using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.MenuItems.Endpoints
{
	[Handler]
	[MapPost("/api/menuItems/create")]
	public static partial class CreateItem
	{
		internal static Created<Response> TransformResult(Response response) =>
			TypedResults.Created($"/api/menuItems/{response.ItemId}", response);
		
		[Validate]
		public sealed partial record Command : IValidationTarget<Command>
		{
			[NotEmpty] public string Name { get; set; }
			public decimal Price { get; set; }
			[NotEmpty] public string Description { get; set; }
		}

		public sealed record Response
		{
			public int ItemId { get; set; }
		}

		private static async ValueTask<Response> HandleAsync(
			Command command, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var item = new MenuItem
			{
				Name = command.Name,
				Price = command.Price,
				Description = command.Description
			};
			
			context.MenuItems.Add(item);
			await context.SaveChangesAsync(cancellationToken);

			return new()
			{
				ItemId = item.Id
			};
		}
	}
}