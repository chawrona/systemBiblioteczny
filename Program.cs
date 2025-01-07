using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using systemBiblioteczny.Areas.Identity.Data;
using systemBiblioteczny.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages();
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection")));

builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders()
    .AddDefaultUI();

var app = builder.Build();


await CreateRoles(app);
await CreateUsers(app);
await SeedDatabase(app);


async Task CreateRoles(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
        string[] roleNames = { "Admin", "User" };

        foreach (var roleName in roleNames)
        {
            var roleExist = await roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var role = new IdentityRole(roleName);
                await roleManager.CreateAsync(role);
            }
        }
    }
}

async Task SeedDatabase(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var context = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
        await context.Database.MigrateAsync();

        // Seed BookStatuses
        if (!context.BooksStatuses.Any())
        {
            await context.BooksStatuses.AddRangeAsync(
                new BookStatus { Id = 1, Status = "Available" },
                new BookStatus { Id = 2, Status = "Reserved" },
                new BookStatus { Id = 3, Status = "Borrowed" }
            );
            await context.SaveChangesAsync(); // Save to generate Id values
        }

        // Ensure the BookStatuses are correctly retrieved using their Id values
        var availableStatus = await context.BooksStatuses.FirstOrDefaultAsync(b => b.Status == "Available");
        var reservedStatus = await context.BooksStatuses.FirstOrDefaultAsync(b => b.Status == "Reserved");
        var borrowedStatus = await context.BooksStatuses.FirstOrDefaultAsync(b => b.Status == "Borrowed");

        if (availableStatus == null || reservedStatus == null || borrowedStatus == null)
        {
            // If any status is not found, throw an exception to stop further execution
            throw new Exception("One or more BookStatuses could not be found.");
        }

        // Seed Books
        if (!context.Books.Any())
        {
            await context.Books.AddRangeAsync(
                new Book
                {
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    Genre = "Fiction",
                    Description = "A story about teenage alienation.",
                    ReleaseDate = new DateTime(1951, 7, 16),
                    IdBookStatus = availableStatus.Id
                },
                new Book
                {
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    Genre = "Fiction",
                    Description = "A novel about racial injustice in the Deep South.",
                    ReleaseDate = new DateTime(1960, 7, 11),
                    IdBookStatus = availableStatus.Id
                },
                new Book
                {
                    Title = "1984",
                    Author = "George Orwell",
                    Genre = "Dystopian",
                    Description = "A dystopian novel about totalitarianism.",
                    ReleaseDate = new DateTime(1949, 6, 8),
                    IdBookStatus = availableStatus.Id
                }
            );
            await context.SaveChangesAsync();
        }
    }
}


async Task CreateUsers(WebApplication app)
{
    using (var scope = app.Services.CreateScope())
    {
        var userManager = scope.ServiceProvider.GetRequiredService<UserManager<User>>();

        var adminEmail = "admin@admin.admin";
        var userEmail = "user@user.user";
        var adminPassword = "Admin123!";
        var userPassword = "User123!";

        // SprawdŸ, czy u¿ytkownicy ju¿ istniej¹
        var adminUser = await userManager.FindByEmailAsync(adminEmail);
        var normalUser = await userManager.FindByEmailAsync(userEmail);

        if (adminUser == null)
        {
            adminUser = new User
            {
                UserName = adminEmail,
                Email = adminEmail,
                Login = "Admin"
            };
            var result = await userManager.CreateAsync(adminUser, adminPassword);
            if (result.Succeeded)
            {
                adminUser.EmailConfirmed = true;
                await userManager.UpdateAsync(adminUser);
                await userManager.AddToRoleAsync(adminUser, "Admin");
            }
        }

        if (normalUser == null)
        {
            normalUser = new User
            {
                UserName = userEmail,
                Email = userEmail,
                Login = "User"
            };
            var result = await userManager.CreateAsync(normalUser, userPassword);
            if (result.Succeeded)
            {
                normalUser.EmailConfirmed = true;
                await userManager.UpdateAsync(normalUser);
                await userManager.AddToRoleAsync(normalUser, "User");
            }
        }
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Shared/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Book}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
