using Microsoft.AspNetCore.Mvc;

namespace RestaurantBackend.Features.Tables.GetAll
{
	[ApiController]
	[Route("api/tables")]
	public class GetAllEndpoint : ControllerBase
	{
		private readonly IHandler<GetAllRequest, GetAllResponse> _handler;

		public GetAllEndpoint(IHandler<GetAllRequest, GetAllResponse> handler)
		{
			_handler = handler;
		}

		[HttpGet]
		public async Task<IActionResult> Get(CancellationToken cancellationToken)
		{
			var response = await _handler.Handle(new GetAllRequest(), cancellationToken);
			
			return Ok(response);
		}
	}
}