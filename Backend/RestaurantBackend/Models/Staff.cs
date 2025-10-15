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

		public Staff(string name, int roleId)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));
			
			Name = name;
			RoleId = roleId;
			Pin = GeneratePin();
		}

		public Staff(
			string name, int roleId,
			string emailOrPhoneNumber)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(emailOrPhoneNumber))
				throw new ArgumentNullException(nameof(emailOrPhoneNumber));
			
			Name = name;
			RoleId = roleId;
			
			if (emailOrPhoneNumber.All(char.IsDigit))
				PhoneNumber = emailOrPhoneNumber;
			else
				Email = emailOrPhoneNumber;
			
			Pin = GeneratePin();
		}

		public Staff(
			string name, int roleId, string email,
			string phoneNumber)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));
			if (string.IsNullOrWhiteSpace(email))
				throw new ArgumentNullException(nameof(email));
			if (string.IsNullOrWhiteSpace(phoneNumber))
				throw new ArgumentNullException(nameof(phoneNumber));
			
			Name = name;
			RoleId = roleId;
			Email = email;
			PhoneNumber = phoneNumber;
			Pin = GeneratePin();
		}

		private void ChangeClockInStatus()
		{
			IsClockedIn = !IsClockedIn;
		}

		private string GeneratePin()
		{
			var random = new Random();
			int pin = random.Next(10000);

			string fmt = "0000";
			return pin.ToString(fmt);
		}
	}
}