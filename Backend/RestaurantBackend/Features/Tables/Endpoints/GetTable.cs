using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.Tables.Endpoints
{
	[Handler]
	[MapGet("/api/tables/{tableId}")]
	public static partial class GetTable
	{
		public sealed record Query
		{
			public required int? tableId { get; init; }
		}

		private static async ValueTask<Table> HandleAsync(
			Query query, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var table =
				await context.Tables.FirstOrDefaultAsync(
					t => t.Id == query.tableId, cancellationToken);

			return table;
		}
	}
}