using Microsoft.AspNetCore.Mvc;

namespace RestaurantBackend.Features.Tables.CloseTable
{
	[ApiController]
	[Route("api/tables")]
	public class CloseTableEndpoint : ControllerBase
	{
		private readonly IHandler<CloseTableRequest, CloseTableResponse> _handler;

		public CloseTableEndpoint(
			IHandler<CloseTableRequest, CloseTableResponse> handler)
		{
			_handler = handler;
		}

		[HttpPut("{id:int}")]
		public async Task<IActionResult> CloseTable(int id, CancellationToken cancellationToken)
		{
			var response = await _handler.Handle(new CloseTableRequest(id), cancellationToken);
			
			return Ok(response);
		}
	}
}