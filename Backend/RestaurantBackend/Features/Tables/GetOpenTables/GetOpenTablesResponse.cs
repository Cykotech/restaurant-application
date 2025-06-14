using RestaurantBackend.Models;

namespace RestaurantBackend.Features.Tables.GetOpenTables
{
	public record GetOpenTablesResponse(List<Table> tables);
}