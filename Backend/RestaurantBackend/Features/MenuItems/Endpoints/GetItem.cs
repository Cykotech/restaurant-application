using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.MenuItems.Endpoints
{
	[Handler]
	[MapGet("/api/menuItems/{id}")]
	public static partial class GetItem
	{
		public sealed record Query
		{
			public required int? id { get; init; }
		}

		private static async ValueTask<MenuItem> HandleAsync(
			Query query, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var item =
				await context.MenuItems.FirstOrDefaultAsync(
					i => i.Id == query.id, cancellationToken);
			
			return item;
		}
	}
}