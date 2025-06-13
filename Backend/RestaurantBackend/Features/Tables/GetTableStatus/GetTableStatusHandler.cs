using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend.Features.Tables.GetTableStatus
{
	public class
		GetTableStatusHandler : IHandler<GetTableStatusRequest,
		GetTableStatusResponse>
	{
		private readonly PosDbContext _dbContext;

		public GetTableStatusHandler(PosDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<GetTableStatusResponse> Handle(
			GetTableStatusRequest request, CancellationToken cancellationToken)
		{
			var table =
				await _dbContext.Tables.FirstOrDefaultAsync(
					t => t.Id == request.Id, cancellationToken);

			if (table is null)
			{
				throw new KeyNotFoundException($"Table with id {request.Id} not found");
			}

			GetTableStatusResponse response =
				new(table.ServerName, table.Status, table.Guests);

			return response;
		}
	}
}