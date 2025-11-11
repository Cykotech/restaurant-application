namespace RestaurantBackend.Services.Sessions
{
	public interface ISessionService
	{
		string CreateSession(int staffId);
		bool ValidateSession(string token, out int staffId);
		void EndSession(string token);
	}
}