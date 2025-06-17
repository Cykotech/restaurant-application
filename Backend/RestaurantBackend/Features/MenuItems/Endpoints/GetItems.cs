using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.MenuItems.Endpoints
{
	[Handler]
	[MapGet("/api/menuItems")]
	public static partial class GetItems
	{
		public record Query;
		private static async ValueTask<List<MenuItem>> HandleAsync(Query _,
			PosDbContext context, CancellationToken cancellationToken)
		{
			var items = await context.MenuItems.ToListAsync(cancellationToken);
			
			return items;
		}
	}
}