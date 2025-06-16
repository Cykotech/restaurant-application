using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.Tables.Endpoints
{
	[Handler]
	[MapGet("/api/tables")]
	public static partial class GetTables
	{
		public sealed record Query
		{
			public bool? ShowClosed { get; init; } = null;
		}
		
		private static async ValueTask<List<Table>> HandleAsync(
			Query query, PosDbContext context,
			CancellationToken cancellationToken)
		{
			bool showClosed = query.ShowClosed ?? true;
			var tables = await context.Tables.ToListAsync(cancellationToken);

			if (!showClosed)
				tables = tables.Where(t => t.Status != TableStatus.Closed).ToList();

			return tables;
		}
	}
}