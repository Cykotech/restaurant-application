using RestaurantBackend.Models;

namespace RestaurantBackend.Dtos
{
	public record MenuItemDto(
		int Id,
		string Name,
		decimal Price,
		string Description,
		int CategoryId
	);

	public static class MenuExtensions
	{
		public static MenuItemDto ToDto(this MenuItem menuItem)
		{
			return new(menuItem.Id, menuItem.Name, menuItem.Price,
			           menuItem.Description, menuItem.CategoryId);
		}
	}
}