using AppInventaris;
using AppInventaris.Areas.Identity;
using AppInventaris.Data;
using AppInventaris.Models;
using Blazored.LocalStorage;
using BlazorStrap;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;


//https://blazorstrap.io/V5/V5


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// var connectionString =
//     builder.Configuration.GetConnectionString("DefaultConnection")
//     ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING");
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddTokenProvider<DataProtectorTokenProvider<ApplicationUser>>(TokenOptions.DefaultProvider)
    .AddDefaultUI();
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddScoped<AuthenticationStateProvider, RevalidatingIdentityAuthenticationStateProvider<ApplicationUser>>();
builder.Services.AddSingleton<WeatherForecastService>();

builder.Services.AddBlazorStrap();
builder.Services.AddBlazoredLocalStorage();

builder.Services.AddScoped<ILokasiService, LokasiService>();
builder.Services.AddScoped<IBarangService, BarangService>();
builder.Services.AddScoped<IKategoriService, KategoriService>();
builder.Services.AddScoped<IItemBarangService, ItemBarangService>();



var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var dbcontext = scope.ServiceProvider.GetService<ApplicationDbContext>();
    dbcontext.Database.EnsureCreated();

    var userManager = scope.ServiceProvider.GetService<UserManager<ApplicationUser>>();
    var roleManager = scope.ServiceProvider.GetService<RoleManager<IdentityRole>>();

    if (!dbcontext.Roles.Any())
    {
        await roleManager.CreateAsync(new IdentityRole("Admin"));
        await roleManager.CreateAsync(new IdentityRole("Pimpinan"));
        await roleManager.CreateAsync(new IdentityRole("Penilai"));
    }

    if (!dbcontext.Users.Any())
    {
        var user = new ApplicationUser("admin@gmail.com");
        var result = await userManager.CreateAsync(user, "Password@123");
        if (result.Succeeded)
        {
            await userManager.AddToRoleAsync(user, "Admin");
        }
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();
