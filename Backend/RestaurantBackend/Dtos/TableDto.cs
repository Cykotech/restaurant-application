using RestaurantBackend.Models;

namespace RestaurantBackend.Dtos
{
	public record TableDto(
		int Id,
		int TableNumber,
		int Seats
	);

	public static class TableExtensions
	{
		public static TableDto ToDto(this Table table)
		{
			return new(table.Id, table.TableNumber, table.Seats);
		}
	}
}