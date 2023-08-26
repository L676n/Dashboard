using Dashboard.Models;
using Microsoft.EntityFrameworkCore;
namespace Dashboard.Data
{
	//               function name     parent
	public class ApplicationDbContext : DbContext
	{
		//ctor + enter
		//DbContextOptions offerd by Entity Framework (EF) and its job to send/tell the parent DbContext the 1- class name and 2- connection type 3- connection line
		//constructer name has the same function name
		//base responsible of carrying options and its all info to the parent
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }

		public DbSet<ProductDetails> ProductDetails { get; set; }

		public DbSet<Customer> Customer { get; set; }

		public DbSet<Invoice> Invoice { get; set; }

        public DbSet<Cart> Cart { get; set; }

    }
}

