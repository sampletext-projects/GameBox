using GameBox.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GameBox.Data
{
    public class GameDbContext : IdentityDbContext<ApplicationUser>
    {
        public GameDbContext()
        {
        }

        public GameDbContext(DbContextOptions<GameDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=(localdb)\\MSSQLLocalDB;Database=GameBox;Trusted_Connection=True;MultipleActiveResultSets=true");
            }
        }

        public DbSet<Game> Games { get; set; }

        public DbSet<GameBox.Models.Article> Article { get; set; }

        public DbSet<GameBox.Models.Comment> Comment { get; set; }
    }
}