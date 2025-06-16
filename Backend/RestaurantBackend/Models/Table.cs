namespace RestaurantBackend.Models
{
	public class Table
	{
		public int Id { get; set; }
		public TableStatus Status { get; set; }
		public string ServerName { get; set; }
		public int Guests { get; set; }
		public List<Order> Orders { get; set; } = [];
		public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
		public List<DateTime> UpdatedAt { get; set; } = [];
		public DateTime ClosedAt { get; set; }
	}

	public enum TableStatus
	{
		Open = 0,
		Closed = 1
	}
}