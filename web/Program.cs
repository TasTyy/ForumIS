using web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using web.Models;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration.GetConnectionString("ForumContext");
//var connectionString = builder.Configuration.GetConnectionString("AzureContext");

/*builder.Services.AddDbContext<ForumContext>(options =>
    options.UseSqlServer(connectionString));*/

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ForumContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

/* builder.Services.AddDbContext<ForumContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("ForumContext"))); */

builder.Services.AddDbContext<ForumContext>(options =>
<<<<<<< HEAD
    options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));
=======
            options.UseSqlServer(builder.Configuration.GetConnectionString("AzureContext")));
>>>>>>> 8f2459e02200a14c35d7ce966332a4bbc7b84c1f

var app = builder.Build();

CreateDbIfNotExists(app);

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapRazorPages();
app.UseRouting();
app.UseAuthentication();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

static void CreateDbIfNotExists(IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ForumContext>();
                    //context.Database.EnsureCreated();
                    DbInitializer.Initialize(context);
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    //logger.LogError(ex, "An error occurred creating the DB.");
                    logger.LogError(ex, "Prišlo je do napake pri ustvarjanju DB.");
                }
            }
        }