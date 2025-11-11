namespace RestaurantBackend.Models
{
	public class Staff
	{
		public int Id { get; init; }
		public string Name { get; private set; }
		public int RoleId { get; private set; }
		public StaffRole? Role { get; private set; }
		public string? Email { get; private set; }
		public string? PhoneNumber { get; private set; }
		public bool IsClockedIn { get; private set; }
		public string Pin { get; private set; }
		public List<Order> Orders { get; init; } = new();

		public Staff(
			string name, int roleId,
			string? email,
			string? phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));

			Name = name;
			RoleId = roleId;
			Email = !string.IsNullOrWhiteSpace(email) ? email : null;
			PhoneNumber = !string.IsNullOrWhiteSpace(phoneNumber) ? phoneNumber : null;
			Pin = GeneratePin();
		}

		public void UpdateStaff(
			string name = "", string? email = "",
			string? phoneNumber = "")
		{
			if (!string.IsNullOrWhiteSpace(name)) Name = name;
			if (!string.IsNullOrWhiteSpace(email)) Email = email;
			if (!string.IsNullOrWhiteSpace(phoneNumber)) PhoneNumber = phoneNumber;
		}
		public void ChangeClockStatus() { IsClockedIn = !IsClockedIn; }

		private string GeneratePin()
		{
			var random = new Random();
			int pin = random.Next(10000);

			string fmt = "0000";

			return pin.ToString(fmt);
		}
	}
}