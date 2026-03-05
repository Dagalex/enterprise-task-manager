using Microsoft.AspNetCore.Mvc;
using TaskService.Entity;
using Microsoft.EntityFrameworkCore;
using TaskService.Data;

namespace TaskService.Controller
{
	[ApiController]
	[Route("api/tasks")]
	public class TaskController : ControllerBase
	{
		private readonly AppDbContext _context;

		public TaskController(AppDbContext context)
		{
			_context = context;
		}

		[HttpGet]
		public async Task<IActionResult> GetTasks()
		{
			return Ok(await _context.Tasks.ToListAsync());
		}

		[HttpPost]
		public async Task<IActionResult> Create(TaskItem task)
		{
			_context.Tasks.Add(task);
			await _context.SaveChangesAsync();

			return Ok(task);
		}
	}
}
