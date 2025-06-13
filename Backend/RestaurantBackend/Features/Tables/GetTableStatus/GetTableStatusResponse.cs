namespace RestaurantBackend.Features.Tables.GetTableStatus
{
	public record GetTableStatusResponse(string ServerName, string Status, int Guests);
}