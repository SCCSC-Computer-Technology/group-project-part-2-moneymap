public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            // error page doesn't exist yet but IF IT DID.
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseDefaultFiles(new DefaultFilesOptions
        {
            // default page when you run the program takes you to the database.
            DefaultFileNames = new List<string> { "login.html" }
        });
        app.UseStaticFiles();

        app.UseRouting();
    }
}