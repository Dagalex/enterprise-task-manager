using Microsoft.EntityFrameworkCore;
using ProjectService.Data; // your DbContext namespace

var builder = WebApplication.CreateBuilder(args);

// Render fix: listen on port 80
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseInMemoryDatabase("ProjectDb"));

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