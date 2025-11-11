namespace RestaurantBackend.Dtos
{
	public record OrderDto(int Id, DateTime OpenedAt, DateTime? ClosedAt);
}