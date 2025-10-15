namespace RestaurantBackend.Dtos
{
	public record StaffDto(
		int Id,
		string Name,
		string? Email,
		string? PhoneNumber
	);
}