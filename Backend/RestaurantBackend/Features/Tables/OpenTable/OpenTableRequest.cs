using MediatR;

namespace RestaurantBackend.Features.Tables.OpenTable
{
	public record OpenTableRequest(string ServerName, int Guests);
}