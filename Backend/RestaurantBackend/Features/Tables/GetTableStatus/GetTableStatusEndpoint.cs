using Microsoft.AspNetCore.Mvc;

namespace RestaurantBackend.Features.Tables.GetTableStatus
{
	[ApiController]
	[Route("api/tables")]
	public class GetTableStatusEndpoint : ControllerBase
	{
		private readonly IHandler<GetTableStatusRequest, GetTableStatusResponse> _handler;

		public GetTableStatusEndpoint(
			IHandler<GetTableStatusRequest, GetTableStatusResponse> handler)
		{
			_handler = handler;
		}

		[HttpGet("{id:int}")]
		public async Task<IActionResult> GetTableStatus(int id,  CancellationToken cancellationToken)
		{
			var response = await _handler.Handle(new GetTableStatusRequest(id), cancellationToken);
			
			return Ok(response);
		}
	}
}