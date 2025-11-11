using Microsoft.AspNetCore.Mvc;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;
using RestaurantBackend.Services.StaffFeature;

namespace RestaurantBackend.Controllers
{
	[Route("api/staff")]
	[ApiController]
	public class StaffController : ControllerBase
	{
		private readonly IStaffService _service;

		public StaffController(IStaffService service) { _service = service; }

		[HttpGet]
		public async Task<IActionResult> GetAllStaff([FromBody] int? roleId)
		{
			try
			{
				List<StaffDto> staffList;

				if (roleId is not null)
				{
					staffList = await _service.GetStaffByRole((int)roleId);

					return Ok(staffList);
				}

				staffList = await _service.GetAllStaff();

				return Ok(staffList);
			}
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpGet("{id}")]
		public async Task<IActionResult> GetStaffById(int id)
		{
			try
			{
				var staff = await _service.GetStaffById(id);

				return Ok(staff);
			}
			catch (NotFoundException<Staff> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpPost]
		public async Task<IActionResult> CreateStaff(
			[FromBody] StaffDto staff, [FromQuery] int? roleId)
		{
			try
			{
				if (roleId is null) return BadRequest("Invalid Role Id");

				var newStaff = await _service.CreateStaff(staff, (int)roleId);

				return CreatedAtAction(nameof(GetStaffById), new { id = newStaff.Id },
				                       newStaff);
			}
			catch (NotFoundException<StaffRole> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpPut("{id}")]
		public async Task<IActionResult> UpdateStaff([FromBody] StaffDto staff)
		{
			try
			{
				var updatedStaff = await _service.UpdateStaff(staff);

				return Ok(updatedStaff);
			}
			catch (NotFoundException<Staff> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpPut("/clock")]
		public async Task<IActionResult> ChangeClockStatus()
		{
			try
			{
				var staffId = HttpContext.GetStaffId();
				await _service.ChangeClockStatus(staffId);

				return Ok();
			}
			catch (NotFoundException<Staff> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}

		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteStaff(int id)
		{
			try
			{
				var deletedEntries = await _service.DeleteStaff(id);

				if (deletedEntries == 0)
					// TODO: Find appropriate status code
					return StatusCode(418, "Entry not deleted");

				return NoContent();
			}
			catch (NotFoundException<Staff> ex) { return NotFound(ex.Message); }
			catch (Exception ex) { return StatusCode(500, ex.Message); }
		}
	}
}