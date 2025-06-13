using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend.Features.Tables.CloseTable
{
	public class
		CloseTableHandler : IHandler<CloseTableRequest, CloseTableResponse>
	{
		private readonly PosDbContext _context;

		public CloseTableHandler(PosDbContext context) { _context = context; }

		public async Task<CloseTableResponse> Handle(
			CloseTableRequest request, CancellationToken cancellationToken)
		{
			var table =
				await _context.Tables.FirstOrDefaultAsync(
					t => t.Id == request.Id, cancellationToken);

			if (table is null) { throw new KeyNotFoundException(); }

			table.ClosedAt = DateTime.UtcNow;
			table.Status = "Closed";
			await _context.SaveChangesAsync(cancellationToken);
			
			return new CloseTableResponse(table.Status, table.ClosedAt);
		}
	}
}