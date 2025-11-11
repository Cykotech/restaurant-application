using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Data;
using RestaurantBackend.Dtos;
using RestaurantBackend.Exceptions;
using RestaurantBackend.Models;

namespace RestaurantBackend.Services.StaffFeature
{
	public class StaffService : IStaffService
	{
		private readonly PosDbContext _dbContext;

		public StaffService(PosDbContext dbContext) { _dbContext = dbContext; }

		public async Task<List<StaffDto>> GetAllStaff()
		{
			var response = new List<StaffDto>();
			var staff = await _dbContext.Staff.ToListAsync();

			foreach (var item in staff)
			{
				response.Add(item.ToDto());
			}

			return response;
		}

		public async Task<List<StaffDto>> GetStaffByRole(int roleId)
		{
			var response = new List<StaffDto>();
			var staff =
				await _dbContext.Staff.Where(x => x.Id == roleId).ToListAsync();

			foreach (var item in staff)
			{
				response.Add(item.ToDto());
			}

			return response;
		}

		public async Task<StaffDto> GetStaffById(int id)
		{
			var staff = await _dbContext.Staff.FirstOrDefaultAsync(x => x.Id == id);

			if (staff is null)
				throw new NotFoundException<Staff>("Staff with this id doesn't exist");

			return staff.ToDto();
		}

		public async Task<StaffDto> CreateStaff(StaffDto staff, int roleId)
		{
			var role =
				await _dbContext.StaffRoles
				                .FirstOrDefaultAsync(x => x.Id == roleId);

			if (role is null)
				throw new NotFoundException<StaffRole>("Role with name doesn't exist");

			Staff newStaff =
				new(staff.Name, role.Id, staff?.Email, staff?.PhoneNumber);

			await _dbContext.Staff.AddAsync(newStaff);

			return newStaff.ToDto();
		}

		public async Task<StaffDto> UpdateStaff(StaffDto staff)
		{
			var staffToUpdate =
				await _dbContext.Staff.FirstOrDefaultAsync(x => x.Id == staff.Id);

			if (staffToUpdate is null)
				throw new NotFoundException<Staff>("Staff with this id doesn't exist");

			staffToUpdate.UpdateStaff(staff.Name, staff.Email, staff.PhoneNumber);
			await _dbContext.SaveChangesAsync();

			return staffToUpdate.ToDto();
		}

		public async Task<bool> ChangeClockStatus(int id)
		{
			var staffToClock =
				await _dbContext.Staff.FirstOrDefaultAsync(x => x.Id == id);

			if (staffToClock is null)
				throw new NotFoundException<Staff>("Staff with this id doesn't exist");

			staffToClock.ChangeClockStatus();
			await _dbContext.SaveChangesAsync();

			return staffToClock.IsClockedIn;
		}

		public async Task<int> DeleteStaff(int id)
		{
			var staffToDelete =
				await _dbContext.Staff.FirstOrDefaultAsync(x => x.Id == id);

			if (staffToDelete is null)
				throw new NotFoundException<Staff>("Staff with this id doesn't exist");
			
			_dbContext.Staff.Remove(staffToDelete);
			return await _dbContext.SaveChangesAsync();
		}
	}
}