using RestaurantBackend.Dtos;
using RestaurantBackend.Models;

namespace RestaurantBackend.Services.Menu
{
	public interface IMenuService
	{
		Task<List<MenuItemDto>> GetAllMenuItems();
		Task<MenuItemDto> GetMenuItemById(int id);

		Task<MenuItemDto> CreateMenuItem(MenuItemDto menuItemDto);

		Task<MenuItemDto> UpdateMenuItem(MenuItemDto menuItem);
		// Task<int> DeleteMenuItem(int id);
	}
}