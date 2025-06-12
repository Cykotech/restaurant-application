using Microsoft.AspNetCore.Mvc;

namespace RestaurantBackend.Features.Tables.OpenTable
{
	[ApiController]
	[Route("api/tables")]
	public class OpenTableEndpoint : ControllerBase
	{
		private readonly IHandler<OpenTableRequest, OpenTableResponse> _handler;
		
		public OpenTableEndpoint(IHandler<OpenTableRequest, OpenTableResponse> handler)
		{
			_handler = handler;
		}

		[HttpPost]
		public async Task<IActionResult> Post([FromBody] OpenTableRequest request, CancellationToken cancellationToken)
		{
			var response = await _handler.Handle(request, cancellationToken);
			
			return Ok(response);
		}
	}
}