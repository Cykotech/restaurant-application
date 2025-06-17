using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend.Features.MenuItems.Endpoints
{
	[Handler]
	[MapDelete("/api/menuItems/{id}/delete")]
	public static partial class DeleteItem
	{
		internal static NoContent TransformResult(Response response) => TypedResults.NoContent();
		public sealed record Query
		{
			public required int? id { get; init; }
		}

		public record Response;

		private static async ValueTask<Response> HandleAsync(
			Query query, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var item =
				await context.MenuItems.FirstOrDefaultAsync(
					i => i.Id == query.id, cancellationToken);
			
			context.MenuItems.Remove(item);
			await context.SaveChangesAsync(cancellationToken);

			return new Response();
		}
	}
}