using System.Collections.Concurrent;

namespace RestaurantBackend.Services.Sessions
{
	public class SessionService : ISessionService
	{
		private readonly ConcurrentDictionary<string, int> _sessions = new();

		public string CreateSession(int staffId)
		{
			var sessionId = Guid.NewGuid().ToString();
			_sessions.TryAdd(sessionId, staffId);
			return sessionId;
		}

		public bool ValidateSession(string token, out int staffId) => _sessions.TryGetValue(token, out staffId);

		public void EndSession(string token) => _sessions.TryRemove(token, out _);
	}
}