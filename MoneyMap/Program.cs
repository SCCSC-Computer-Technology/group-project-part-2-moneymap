using MoneyMap.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseHttpsRedirection();

app.UseDefaultFiles(new DefaultFilesOptions
{
    // home page
    DefaultFileNames = new List<string> { "login.html" }
});
app.UseStaticFiles();

app.UseRouting();

app.MapGet("/", () => "Hello World!");

app.Run();
