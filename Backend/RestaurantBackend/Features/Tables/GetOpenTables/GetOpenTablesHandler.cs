using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend.Features.Tables.GetOpenTables
{
	public class
		GetOpenTablesHandler : IHandler<GetOpenTablesRequest, GetOpenTablesResponse>
	{
		private readonly PosDbContext _dbContext;

		public GetOpenTablesHandler(PosDbContext dbContext)
		{
			_dbContext = dbContext;
		}

		public async Task<GetOpenTablesResponse> Handle(
			GetOpenTablesRequest request, CancellationToken cancellationToken)
		{
			var tables = await _dbContext.Tables.Where(t => t.Status == "Open")
			                             .ToListAsync(cancellationToken);

			return new GetOpenTablesResponse(tables);
		}
	}
}