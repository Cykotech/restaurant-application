namespace RestaurantBackend.Dtos
{
	public record MenuItemDto(
		int Id,
		string Name,
		decimal Price,
		string Description,
		int CategoryId
	);
}