using System;
using System.Linq;
using GameBox.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GameBox.Data
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new GameDbContext(serviceProvider.GetRequiredService<DbContextOptions<GameDbContext>>()))
            {
                var userManager = serviceProvider.GetService<UserManager<ApplicationUser>>();
                var roleManager = serviceProvider.GetService<RoleManager<IdentityRole>>();

                if (!roleManager.RoleExistsAsync("Admin").Result)
                {
                    roleManager.CreateAsync(new IdentityRole { Name = "Admin" }).Wait();
                }

                if (userManager.FindByEmailAsync("admin@example.com").Result == null)
                {
                    var user = new ApplicationUser
                    {
                        UserName = "admin@example.com",
                        Email = "admin@example.com",
                        EmailConfirmed = true,
                        FirstName = "Super",
                        LastName = "Admin"
                    };

                    IdentityResult result = userManager.CreateAsync(user, "P@ssw0rd").Result;

                    if (result.Succeeded)
                    {
                        userManager.AddToRoleAsync(user, "Admin").Wait();
                    }
                }


                // Look for any movies.
                if (context.Games.Any()) return; // DB has been seeded

                context.SaveChanges();
            }
        }
    }
}