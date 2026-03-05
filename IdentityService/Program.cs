using Microsoft.EntityFrameworkCore;
using IdentityService.Data; // your DbContext namespace
using IdentityService.Services; // JwtService etc

var builder = WebApplication.CreateBuilder(args);

// Render fix: listen on port 80
builder.WebHost.UseUrls("http://0.0.0.0:80");

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Add DbContext
builder.Services.AddDbContext<AppDbContext>(options =>
	options.UseInMemoryDatabase("IdentityDb"));

// Add JWT Service (example)
builder.Services.AddSingleton<JwtService>();

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