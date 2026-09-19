using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using WebApplication3.Areas.Identity.Data;
using WebApplication3.Data;
var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("ArtEquipmentContextConnection") ?? throw new InvalidOperationException("Connection string 'ArtEquipmentContextConnection' not found.");;

builder.Services.AddDbContext<ArtEquipmentContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddDefaultIdentity<User>(options => options.SignIn.RequireConfirmedAccount = false).AddRoles<IdentityRole>().AddEntityFrameworkStores<ArtEquipmentContext>();
    

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<ArtEquipmentContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred creating the DB.");
    }
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseAuthorization();
app.MapRazorPages();
app.MapStaticAssets(); 

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

using (var scope = app.Services.CreateScope())
{
    var role_manager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Teacher"};

    foreach (var role in roles)
    {
        if (!await role_manager.RoleExistsAsync(role))
            await role_manager.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var usr_manager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

    // ecc7ebb7-0241-4f85-a6d8-39208c0f4d3c

    string email = "staff@gmail.com";
    string password = "*Art2026*";


    if(await usr_manager.FindByEmailAsync(email) == null)
    {
        var usr = new User();
        usr.UserName = email;
        usr.Email = email;

        await usr_manager.CreateAsync(usr, password);

        await usr_manager.AddToRoleAsync(usr, "Teacher");

    }
}

app.Run();
