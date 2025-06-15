namespace RestaurantBackend.Models
{
	public class Order
	{
		public int Id { get; set; }
		public int TableId { get; set; }
		public List<MenuItem> Items { get; set; } = [];
		public DateTime CreatedAt { get; set; }
	}
}