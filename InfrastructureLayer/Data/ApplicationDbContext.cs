using DomainLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace InfrastructureLayer.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Product> Products { get; set; }
		public DbSet<Category> Categories { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			//modelBuilder.Entity<Category>()
			//			.HasData(new Category[]
			//			{
			//			new Category { Id = 1, Name = "Fashion" },
			//			new Category { Id = 2, Name = "Perfumes" },
			//			new Category { Id = 3, Name = "Electronics" },
			//			new Category { Id = 4, Name = "Games" },
			//			});

			modelBuilder.Entity<Product>()
			.HasData(new Product[]
			{
						new Product { Id = 1, Name = "Product 1" , CategoryId = 1 , CreatedDate = DateTime.Now , DurationInDays = 10 , Price = 300 , StartDate = DateTime.Now.AddDays(10) },
						new Product { Id = 2, Name = "Product 2" , CategoryId = 2 , CreatedDate = DateTime.Now , DurationInDays = 20 , Price = 400 , StartDate = DateTime.Now.AddDays(20) },
						new Product { Id = 3, Name = "Product 3" , CategoryId = 3 , CreatedDate = DateTime.Now , DurationInDays = 30 , Price = 500 , StartDate = DateTime.Now },
						new Product { Id = 4, Name = "Product 4" , CategoryId = 4 , CreatedDate = DateTime.Now , DurationInDays = 40 , Price = 600 , StartDate = DateTime.Now },
			});

			modelBuilder.Entity<Product>()
						.HasOne<Category>(p => p.Category)
						.WithMany(c => c.Products)
						.HasForeignKey(p => p.CategoryId);

			base.OnModelCreating(modelBuilder);
		}
	}
}
