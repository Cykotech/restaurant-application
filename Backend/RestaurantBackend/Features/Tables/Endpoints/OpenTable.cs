using Immediate.Apis.Shared;
using Immediate.Handlers.Shared;
using Immediate.Validations.Shared;
using Microsoft.AspNetCore.Http.HttpResults;
using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.Tables.Endpoints
{
	[Handler]
	[MapPost("/api/tables/open")]
	public static partial class OpenTable
	{
		internal static Created<Response> TransformResult(Response response) =>
			TypedResults.Created($"/api/tables/{response.TableId}", response);
		
		[Validate]
		public sealed partial record Command : IValidationTarget<Command>
		{
			[NotEmpty] public required string ServerName { get; init; }
			public required int Guests { get; init; }
		}

		public sealed record Response
		{
			public int TableId { get; init; }
		}

		private static async ValueTask<Response> HandleAsync(
			Command command, PosDbContext context,
			CancellationToken cancellationToken)
		{
			var table = new Table
			{
				Status = TableStatus.Open,
				ServerName = command.ServerName,
				Guests = command.Guests,
			};
			
			context.Tables.Add(table);
			await context.SaveChangesAsync(cancellationToken);

			return new()
			{
				TableId = table.Id,
			};
		}
	}
}