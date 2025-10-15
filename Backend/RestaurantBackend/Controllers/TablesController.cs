using Microsoft.AspNetCore.Mvc;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;
using RestaurantBackend.Services.Tables;

namespace RestaurantBackend.Controllers
{
	[Route("api/tables")]
	[ApiController]
	public class TablesController : ControllerBase
	{
		private readonly ITableService _service;

		public TablesController(ITableService service) { _service = service; }

		[HttpGet]
		public async Task<IActionResult> GetAllTables(bool showClosed = true)
		{
			try
			{
				var tables = await _service.GetAllTables(showClosed);

				return Ok(tables);
			}
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTable(int id)
		{
			try
			{
				var table = await _service.GetTableById(id);

				return Ok(table);
			}
			catch (NotFoundException<Table> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpPost]
		public async Task<IActionResult> OpenTable(
			[FromBody] TableDto newTable)
		{
			var newTableResponse = await _service.OpenTable(newTable);

			return CreatedAtAction(nameof(GetTable), new { id = newTableResponse.Id },
			                       newTableResponse);
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> CloseTable(int id)
		{
			try { await _service.CloseTable(id); }
			catch (NotFoundException<Table> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }

			return Ok();
		}
	}
}