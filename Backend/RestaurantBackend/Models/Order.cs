namespace RestaurantBackend.Models
{
	public class Order
	{
		public int Id { get; set; }
		public int TableId { get; set; }
		public List<OrderItem> Items { get; set; }
		public DateTime CreatedAt { get; set; }
	}
}