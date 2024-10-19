using Microsoft.EntityFrameworkCore;
using ShowTracker.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ShowTrackerContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<ShowTrackerContext>();
    context.Database.Migrate();

    // Seed Data
    if (!context.Shows.Any())
    {
        context.Shows.AddRange(
            new Show { Title = "Breaking Bad", Genre = "Drama", Rating = 10 },
            new Show { Title = "Stranger Things", Genre = "Sci-Fi", Rating = 9 }
        );
        context.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
