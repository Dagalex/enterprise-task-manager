using Microsoft.EntityFrameworkCore;
using ProjectService.Entity;

namespace ProjectService.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<Project> Projects { get; set; }
	}
}