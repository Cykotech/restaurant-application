using Microsoft.AspNetCore.Mvc;

namespace RestaurantBackend.Features.Tables.GetOpenTables
{
	[ApiController]
	[Route("api/tables/open")]
	public class GetOpenTablesEndpoint : ControllerBase
	{
		private readonly IHandler<GetOpenTablesRequest, GetOpenTablesResponse> _handler;

		public GetOpenTablesEndpoint(
			IHandler<GetOpenTablesRequest, GetOpenTablesResponse> handler)
		{
			_handler = handler;
		}

		[HttpGet]
		public async Task<IActionResult> Get(CancellationToken cancellationToken)
		{
			var response = await _handler.Handle(new GetOpenTablesRequest(), cancellationToken);
			
			return Ok(response);
		}
	}
}