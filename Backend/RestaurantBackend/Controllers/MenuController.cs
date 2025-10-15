using Microsoft.AspNetCore.Mvc;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;
using RestaurantBackend.Services.Menu;

namespace RestaurantBackend.Controllers
{
	[Route("api/menu")]
	[ApiController]
	public class MenuController : PosController
	{
		private readonly IMenuService _service;

		public MenuController(IMenuService service) { _service = service; }

		[HttpGet]
		public async Task<IActionResult> GetAllMenuItems()
		{
			try
			{
				var menuItems = await _service.GetAllMenuItems();

				return Ok(menuItems);
			}
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetMenuItem(int id)
		{
			try
			{
				var menuItem = await _service.GetMenuItemById(id);

				return Ok(menuItem);
			}
			catch (NotFoundException<MenuItem> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpPost]
		public async Task<IActionResult> CreateMenuItem(
			[FromBody] MenuItemDto menuItem)
		{
			var newMenuItemResponse =
				await _service.CreateMenuItem(menuItem);

			return CreatedAtAction(nameof(GetMenuItem),
			                       new { id = newMenuItemResponse.Id },
			                       newMenuItemResponse);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateMenuItem(
			[FromBody] MenuItemDto menuItem)
		{
			var updatedMenuItemResponse = await _service.UpdateMenuItem(menuItem);
			
			return Ok(updatedMenuItemResponse);
		}

		// [HttpDelete("{id}")]
		// public async Task<IActionResult> DeleteMenuItem(int id)
		// {
		// 	var response = await _service.DeleteMenuItem(id);
		//
		// 	if (response == 0) return StatusCode(500);
		//
		// 	return NoContent();
		// }
	}
}