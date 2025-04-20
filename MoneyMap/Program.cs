using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// all of this to make sure that the forgot password button works. sigh
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("https://localhost:7135")
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

app.UseHttpsRedirection();

app.UseCors();

app.UseDefaultFiles(new DefaultFilesOptions
{
    // home page
    DefaultFileNames = new List<string> { "home.html" }
});
app.UseStaticFiles();

app.UseRouting();
// this doesn't break anything so im just. leaving it 
app.MapGet("/", () => "Hello World!");

app.Run();
