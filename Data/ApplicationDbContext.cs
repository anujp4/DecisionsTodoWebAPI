using DecisionsTodoWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace DecisionsTodoWebAPI.Data
{
	public class ApplicationDbContext : DbContext
	{
		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
		{

		}
		public DbSet<Tododata> TododataDbset { get; set; }
	}
}
