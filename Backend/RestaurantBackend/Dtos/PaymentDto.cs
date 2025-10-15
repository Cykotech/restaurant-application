using RestaurantBackend.Models;

namespace RestaurantBackend.Dtos
{
	public record PaymentDto(
		int Id,
		decimal Amount,
		DateTime? PaidAt,
		PaymentMethod? PaymentMethod
	);
}