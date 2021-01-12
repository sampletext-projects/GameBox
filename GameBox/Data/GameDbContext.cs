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

        //  представляет коллекцию всех сущностей указанного типа, которые содержатся в контексте или могут быть запрошены из базы данных.
        public DbSet<Game> Games { get; set; }

        public DbSet<Article> Article { get; set; }

        public DbSet<Comment> Comment { get; set; }
    }
}