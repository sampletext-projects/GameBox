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

                context.Games.Add(new Game()
                {
                    Title = "Cyberpunk 2077",
                    Genre = Genre.FPS | Genre.ThreeD,
                    ImgUrl = "https://i.playground.ru/e/Ryrrx206WNZbVZv6yow2JQ.jpeg",
                    ReleaseDate = DateTime.Today
                });
                context.Games.Add(new Game()
                {
                    Title = "The Witcher 3: Wild Hunt",
                    Genre = Genre.ThreeD,
                    ImgUrl = "https://i.playground.ru/e/9thR9kr-oEyBmZSODTny6w.jpeg",
                    ReleaseDate = DateTime.Today
                });
                context.Games.Add(new Game()
                {
                    Title = "Red Dead Redemption 2",
                    Genre = Genre.ThreeD | Genre.Adventure,
                    ImgUrl = "https://i.playground.ru/e/VCWcLDopPY6j_abJ82vryg.jpeg",
                    ReleaseDate = DateTime.Today
                });

                context.SaveChanges();
            }
        }
    }
}