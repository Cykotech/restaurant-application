using RestaurantBackend.Dtos;

namespace RestaurantBackend.Services.Tables
{
	public interface ITableService
	{
		Task<List<TableDto>> GetAllTables(
			bool showClosed, bool showByServer,
			int serverId);

		Task<TableDto> GetTableById(int id);
		Task<TableDto> OpenTable(TableDto table, int serverId);
		Task CloseTable(int id);
	}
}