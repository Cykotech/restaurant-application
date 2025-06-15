using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Models;

namespace RestaurantBackend.Data
{
	public class PosDbContext : DbContext
	{
		public DbSet<Table> Tables { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<MenuItem> OrderItems { get; set; }

		public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
		{}
	}
}