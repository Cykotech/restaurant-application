using Microsoft.AspNetCore.Mvc.Diagnostics;
using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;

namespace RestaurantBackend.Services.Menu
{
	public class MenuService : IMenuService
	{
		private readonly PosDbContext _dbContext;

		public MenuService(PosDbContext dbContext) { _dbContext = dbContext; }

		public async Task<List<MenuItemDto>> GetAllMenuItems()
		{
			var response = new List<MenuItemDto>();
			var menuItems = await _dbContext.MenuItems.ToListAsync();

			foreach (var menuItem in menuItems)
			{
				response.Add(menuItem.ToDto());
			}

			return response;
		}

		public async Task<List<MenuItemDto>> GetMenuItemsByCategory(int categoryId)
		{
			var response = new List<MenuItemDto>();
			var menuItems = await _dbContext.MenuItems
			                                .Where(m => m.CategoryId == categoryId)
			                                .ToListAsync();

			foreach (var menuItem in menuItems)
			{
				response.Add(menuItem.ToDto());
			}

			return response;
		}

		public async Task<MenuItemDto> GetMenuItemById(int id)
		{
			var menuItem =
				await _dbContext.MenuItems.FirstOrDefaultAsync(m => m.Id == id);

			if (menuItem is null) throw new NotFoundException<MenuItem>(id);

			return menuItem.ToDto();
		}

		public async Task<MenuItemDto> CreateMenuItem(MenuItemDto menuItem)
		{
			var newItem = new MenuItem(menuItem.Name, menuItem.Description,
			                           menuItem.Price, menuItem.CategoryId);

			_dbContext.MenuItems.Add(newItem);

			await _dbContext.SaveChangesAsync();

			return newItem.ToDto();
		}

		public async Task<MenuItemDto> UpdateMenuItem(MenuItemDto menuItem)
		{
			var itemToUpdate =
				await _dbContext.MenuItems
				                .FirstOrDefaultAsync(m => m.Id == menuItem.Id);

			if (itemToUpdate is null)
				throw new NotFoundException<MenuItem>(menuItem.Id);
			
			itemToUpdate.UpdateItem(menuItem.Name, menuItem.Description,
			                        menuItem.Price);
			await _dbContext.SaveChangesAsync();

			return itemToUpdate.ToDto();
		}

		public async Task<int> DeleteMenuItem(int id)
		{
			var itemToDelete =
				await _dbContext.MenuItems.FirstOrDefaultAsync(m => m.Id == id);
			
			if (itemToDelete is null)
				throw new NotFoundException<MenuItem>(id);
			
			_dbContext.Remove(itemToDelete);
			return await _dbContext.SaveChangesAsync();
		}
	}
}