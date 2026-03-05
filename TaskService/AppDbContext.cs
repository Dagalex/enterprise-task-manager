using Microsoft.EntityFrameworkCore;
using TaskService.Entity;

namespace TaskService.Data
{
	public class AppDbContext : DbContext
	{
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

		public DbSet<TaskItem> Tasks { get; set; }
	}
}