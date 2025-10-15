namespace RestaurantBackend.Models
{
	public class OrderItem
	{
		public int Id { get; init; }
		public int OrderId { get; init; }
		public Order? Order { get; init; }
		public int MenuItemId { get; init; }
		public MenuItem? MenuItem { get; init; }
		public int Quantity { get; init; } = 1;
		public string? SpecialInstructions { get; init; }

		public OrderItem(int orderId, int menuItemId)
		{
			OrderId = orderId;
			MenuItemId = menuItemId;
		}

		public OrderItem(
			int orderId, int menuItemId,
			int quantity)
		{
			if (quantity < 1)
				throw new ArgumentException("Quantity must be greater than zero",
				                            nameof(quantity));

			OrderId = orderId;
			MenuItemId = menuItemId;
			Quantity = quantity;
		}

		public OrderItem(
			int orderId, int menuItemId,
			string specialInstructions)
		{
			if (string.IsNullOrEmpty(specialInstructions))
				throw new ArgumentException(
					"SpecialInstructions cannot be null or empty",
					nameof(specialInstructions));

			OrderId = orderId;
			MenuItemId = menuItemId;
			SpecialInstructions = specialInstructions;
		}

		public OrderItem(
			int orderId, int menuItemId,
			int quantity, string specialInstructions)
		{
			if (quantity < 1)
				throw new ArgumentException("Quantity must be greater than zero",
				                            nameof(quantity));

			if (string.IsNullOrEmpty(specialInstructions))
				throw new ArgumentException(
					"SpecialInstructions cannot be null or empty",
					nameof(specialInstructions));

			OrderId = orderId;
			MenuItemId = menuItemId;
			Quantity = quantity;
			SpecialInstructions = specialInstructions;
		}
	}
}