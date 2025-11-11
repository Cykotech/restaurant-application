namespace RestaurantBackend.Models
{
	public class MenuItem
	{
		public int Id { get; init; }
		public string Name { get; private set; }
		public string Description { get; private set; }
		public decimal Price { get; private set; }
		public int CategoryId { get; private set; }
		public Category? Category { get; private set; }

		public MenuItem(
			string name, string description,
			decimal price, int categoryId)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(description))
				throw new ArgumentNullException(nameof(description));

			Name = name;
			Description = description;
			Price = price;
			CategoryId = categoryId;
		}

		public void UpdateItem(
			string name = "", string description = "",
			decimal price = 0)
		{
			if (!string.IsNullOrWhiteSpace(name)) Name = name;
			if (!string.IsNullOrWhiteSpace(description)) Description = description;

			Price = price;
		}
	}
}