using Game_Shop.Database.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Game_Shop.Database.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Category>()
                .HasData(
                    new Category { Name = "Action", Id = 1},
                    new Category { Name = "Adventure", Id = 2},
                    new Category { Name = "Racing", Id = 3},
                    new Category { Name = "Puzzle", Id = 4},
                    new Category { Name = "Role-Playing", Id = 5},
                    new Category { Name = "Sports", Id = 6}
                );

            builder.Entity<Device>()
                .HasData(
                    new Device { Name = "Play Station", Icon = "bi bi-playstation", Id = 1 },
                    new Device { Name = "PC", Icon = "bi bi-pc-display-horizontal", Id = 2 },
                    new Device { Name = "X-Box", Icon = "bi bi-xbox", Id = 3 },
                    new Device { Name = "Mobile Phone", Icon = "bi bi-phone", Id = 4 },
                    new Device { Name = "Nintendo-Switch", Icon = "bi bi-nintendo-switch", Id = 5 }
                );

            base.OnModelCreating(builder);

            builder.Entity<GameDevice>()
                .HasKey(k => new {k.GameId, k.DeviceId});

            builder.Entity<GameDevice>()
                .HasOne(g => g.Game)
                .WithMany(gd => gd.GameDevices);

            builder.Entity<GameDevice>()
                .HasOne(g => g.Device)
                .WithMany(gd => gd.GameDevices);
        }

        public virtual DbSet<Game> Games { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Device> Devics { get; set; }
        public virtual DbSet<GameDevice> GameDevices { get; set; }
    }
}