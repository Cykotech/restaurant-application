using Microsoft.AspNetCore.Mvc;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;
using RestaurantBackend.Services.Tables;

namespace RestaurantBackend.Controllers
{
	[Route("api/tables")]
	[ApiController]
	public class TablesController : PosController
	{
		private readonly ITableService _service;

		public TablesController(ITableService service) { _service = service; }

		[HttpGet]
		public async Task<IActionResult> GetAllTables(
			bool showClosed = false, bool showByServer = true)
		{
			try
			{
				var server = HttpContext.GetStaffId();

				var tables =
					await _service.GetAllTables(showClosed, showByServer, server);

				return Ok(tables);
			}
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetTableById(int id)
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
		public async Task<IActionResult> OpenTable([FromBody] TableDto newTable)
		{
			try
			{
				var server = HttpContext.GetStaffId();
				var newTableResponse = await _service.OpenTable(newTable, server);

				return CreatedAtAction(nameof(GetTableById),
				                       new { id = newTableResponse.Id },
				                       newTableResponse);
			}
			// TODO Handle custom exception from extension
			catch (Exception ex) { return StatusCode(500, ex.Message); }
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