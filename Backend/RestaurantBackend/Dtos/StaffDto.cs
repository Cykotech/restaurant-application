using RestaurantBackend.Models;

namespace RestaurantBackend.Dtos
{
	public record StaffDto(
		int Id,
		string Name,
		string? Email,
		string? PhoneNumber
	);

	public static class StaffExtensions
	{
		public static StaffDto ToDto(this Staff staff)
		{
			return new StaffDto(staff.Id, staff.Name, staff.Email, staff.PhoneNumber);
		}
	}
}