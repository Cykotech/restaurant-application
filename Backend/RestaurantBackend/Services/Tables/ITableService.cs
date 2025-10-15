using RestaurantBackend.Dtos;

namespace RestaurantBackend.Services.Tables
{
	public interface ITableService
	{
		Task<List<TableDto>> GetAllTables(bool showClosed);
		Task<TableDto> GetTableById(int id);
		Task<TableDto> OpenTable(TableDto table);
		Task CloseTable(int id);
	}
}