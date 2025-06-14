using RestaurantBackend.Data;
using RestaurantBackend.Models;

namespace RestaurantBackend.Features.Tables.OpenTable
{
	public class OpenTableHandler : IHandler<OpenTableRequest, OpenTableResponse>
	{
		private readonly PosDbContext _context;

		public OpenTableHandler(PosDbContext context) { _context = context; }

		public async Task<OpenTableResponse> Handle(
			OpenTableRequest request, CancellationToken cancellationToken)
		{
			var table = new Table
			{
				Status = "Open",
				ServerName = request.ServerName,
				Guests = request.Guests,
			};

			_context.Add(table);
			await _context.SaveChangesAsync(cancellationToken);

			var response = new OpenTableResponse(table.Id,
			                                     table.ServerName,
			                                     table.Guests,
			                                     table.Status);

			return response;
		}
	}
}