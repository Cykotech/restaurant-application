using Microsoft.AspNetCore.Mvc;

namespace RestaurantBackend.Controllers
{
	public class PosController : ControllerBase
	{
		protected int? StaffId => HttpContext.Items.TryGetValue("StaffId", out var value) ? value as int? : null;
	}
}