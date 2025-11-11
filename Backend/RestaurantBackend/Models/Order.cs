namespace RestaurantBackend.Models
{
	public class Order
	{
		public int Id { get; init; }
		public int TableId { get; private set; }
		public Table? Table { get; private set; }
		public int ServerId { get; private set; }
		public Staff? Server { get; private set; }
		public DateTime OpenedAt { get; init; } = DateTime.Now;
		public DateTime? ClosedAt { get; private set; }
		public OrderStatus Status { get; private set; } =  OrderStatus.Open;
		public List<OrderItem>? OrderItems { get; private set; }
		public List<Payment> Payments { get; private set; } = new();

		public Order(int tableId, int serverId)
		{
			TableId = tableId;
			ServerId = serverId;
		}

		private void CloseOrder()
		{
			ClosedAt = DateTime.Now;
			Status = OrderStatus.Closed;
		}
	}

	public enum OrderStatus
	{
		Open = 1,
		Closed = 2
	}
}