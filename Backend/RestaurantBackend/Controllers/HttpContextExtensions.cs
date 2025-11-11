namespace RestaurantBackend.Controllers
{
	public static class HttpContextExtensions
	{
		public static int GetStaffId(this HttpContext context)
		{
			var id = context.Items.TryGetValue("StaffId", out var value) ? value as int? : null;

			// TODO Make custom exception
			if (value is null) throw new UnauthorizedAccessException();
			
			return (int)value;
		}
	}
}