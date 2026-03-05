using Microsoft.EntityFrameworkCore;
using TaskService.Data; 

var builder = WebApplication.CreateBuilder(args);

// Render fix: listen on port 80
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext (example, in-memory for portfolio)
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseInMemoryDatabase("TaskDb"));

var app = builder.Build();

// Configure middleware
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();