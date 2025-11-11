using RestaurantBackend.Dtos;
using RestaurantBackend.Models;

namespace RestaurantBackend.Services.StaffFeature
{
	public interface IStaffService
	{
		Task<List<StaffDto>> GetAllStaff();
		Task<List<StaffDto>> GetStaffByRole(int roleId);
		Task<StaffDto> GetStaffById(int id);
		Task<StaffDto> CreateStaff(StaffDto staff, int roleId);
		Task<StaffDto> UpdateStaff(StaffDto staff);
		Task<bool> ChangeClockStatus(int id);
		Task<int> DeleteStaff(int id);
	}
}