using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.Tables.Endpoints
{
	[Handler]
	[MapPut("/api/tables/{tableId}")]
	public static partial class CloseTable
	{
		public sealed record Command
		{
			public sealed record CommandBody
			{
				public required int TableId { get; init; }
			}
			[FromRoute] public required int TableId { get; init; }
		}

		private static async ValueTask HandleAsync(
			[AsParameters] Command command, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var table =
				await context.Tables.FirstOrDefaultAsync(
					t => t.Id == command.TableId, cancellationToken);

			table.Status = TableStatus.Closed;
			await context.SaveChangesAsync(cancellationToken);
		}
	}
}