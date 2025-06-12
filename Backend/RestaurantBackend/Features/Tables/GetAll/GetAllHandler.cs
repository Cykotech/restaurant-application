using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;

namespace RestaurantBackend.Features.Tables.GetAll
{
	public class GetAllHandler : IHandler<GetAllRequest, GetAllResponse>
	{
		private readonly PosDbContext _context;
		
		public GetAllHandler(PosDbContext context) { _context = context; }

		public async Task<GetAllResponse> Handle(
			GetAllRequest request, CancellationToken cancellationToken)
		{
			var tables = await _context.Tables.ToListAsync(cancellationToken);
			
			return new GetAllResponse(tables);
		}
	}
}