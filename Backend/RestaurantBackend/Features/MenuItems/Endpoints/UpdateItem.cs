using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend.Features.MenuItems.Endpoints
{
	[Handler]
	[MapPut("/api/menuItems/{menuItemId}")]
	public static partial class UpdateItem
	{
		[Validate]
		public sealed partial record Command : IValidationTarget<Command>
		{
			public sealed record CommandBody
			{
				public string? Name { get; init; }
				public decimal? Price { get; init; }
				public string? Description { get; init; }
			}

			[FromRoute] public required int MenuItemId { get; init; }

			[FromBody] public CommandBody Body { get; init; }
		}

		public sealed record Response
		{
			public int ItemId { get; init; }
			public string? Name { get; init; }
			public decimal? Price { get; init; }
			public string? Description { get; init; }
		}

		private static async ValueTask<Response> HandleAsync(
			[AsParameters] Command command, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var item =
				await context.MenuItems.FirstOrDefaultAsync(
					i => i.Id == command.MenuItemId, cancellationToken);

			if (command.Body.Name is not null) item.Name = command.Body.Name;

			if (command.Body.Price is not null) item.Price = (decimal)command.Body.Price;

			if (command.Body.Description is not null)
				item.Description = command.Body.Description;
			
			await context.SaveChangesAsync(cancellationToken);

			return new()
			{
				ItemId = item.Id,
				Name = item.Name,
				Price = item.Price,
				Description = item.Description
			};
		}
	}
}