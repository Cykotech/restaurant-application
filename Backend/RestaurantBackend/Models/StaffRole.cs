using System.ComponentModel.DataAnnotations;

namespace RestaurantBackend.Models
{
	public class StaffRole
	{
		public int Id { get; init; }
		[Required] public string Name { get; set; }

		public StaffRole(string name)
		{
			if (string.IsNullOrWhiteSpace(name))
				throw new ArgumentNullException(nameof(name));
			
			Name = name;
		}
	}
}