namespace RestaurantBackend.Models
{
	public class Table
	{
		public int Id { get; set; }
		public string Status { get; set; } // e.g. Open, Ordered, Closed
		public List<Order> Orders { get; set; }
	}
}