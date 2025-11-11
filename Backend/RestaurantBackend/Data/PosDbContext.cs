using Microsoft.EntityFrameworkCore;
using RestaurantBackend.Models;

namespace RestaurantBackend.Data
{
	public class PosDbContext : DbContext
	{
		public DbSet<Table> Tables { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<MenuItem> MenuItems { get; set; }
		public DbSet<Staff> Staff { get; set; }
		public DbSet<StaffRole> StaffRoles { get; set; }
		public DbSet<Category> Categories { get; set; }

		public PosDbContext(DbContextOptions<PosDbContext> options) : base(options)
		{}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Table>()
			            .HasOne(t => t.Server)
			            .WithMany()
			            .HasForeignKey(t => t.ServerId)
			            .IsRequired();

			modelBuilder.Entity<Order>()
			            .HasOne(o => o.Table)
			            .WithMany(t => t.Orders)
			            .HasForeignKey(o => o.TableId)
			            .IsRequired();
			
			modelBuilder.Entity<Order>()
			            .HasOne(o => o.Server)
			            .WithMany(s => s.Orders)
			            .HasForeignKey(o => o.ServerId)
			            .IsRequired();

			modelBuilder.Entity<Staff>()
			            .HasOne(s => s.Role)
			            .WithMany()
			            .HasForeignKey(s => s.RoleId)
			            .IsRequired();
			
			modelBuilder.Entity<OrderItem>()
			            .HasOne(i => i.Order)
			            .WithMany(o => o.OrderItems)
			            .HasForeignKey(i => i.OrderId)
			            .IsRequired();

			modelBuilder.Entity<OrderItem>()
			            .HasOne(i => i.MenuItem)
			            .WithOne()
			            .HasForeignKey<OrderItem>(i => i.MenuItemId);
			
			modelBuilder.Entity<MenuItem>()
			            .HasOne(m => m.Category)
			            .WithMany()
			            .HasForeignKey(m => m.CategoryId)
			            .IsRequired();
			
			modelBuilder.Entity<Payment>()
			            .HasOne(p => p.Order)
			            .WithMany(o => o.Payments)
			            .HasForeignKey(p => p.OrderId)
			            .IsRequired();
		}
	}
}