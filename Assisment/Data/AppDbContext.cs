using Assisment.Models;
using Microsoft.EntityFrameworkCore;

namespace Assisment.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Coach> Coachs { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Competition> Competitions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Coach>()
                 .HasOne(t => t.Team).WithOne(t => t.Coach)
                 .HasForeignKey<Team>(f => f.CoachId);

            modelBuilder.Entity<Team>()
                .HasMany(p => p.Player).WithOne(t => t.Team)
                .HasForeignKey(f => f.TeamId);

            modelBuilder.Entity<Competition>()
                .HasMany(c => c.Team).WithMany(c => c.Competition);

            modelBuilder.Entity<Coach>().HasData(
                new Coach {Id = 1 , Name = "Salah" , Specializatiion= "Basketball" , ExperinceYears = 5},
                new Coach {Id = 2 , Name = "Mohamed" , Specializatiion= "Football" , ExperinceYears = 8},
                new Coach {Id = 3 , Name = "Ahmed" , Specializatiion= "Volyball" , ExperinceYears = 2},
                new Coach {Id = 4 , Name = "Nour" , Specializatiion= "Tenis" , ExperinceYears = 1},
                new Coach {Id = 5 , Name = "Omar" , Specializatiion= "Golf" , ExperinceYears = 6}
                );
            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Trackers", City = "Giza", CoachId = 1 },
                new Team { Id = 2, Name = "Good", City = "Cairo", CoachId = 2 },
                new Team { Id = 3, Name = "Bad", City = "Haram", CoachId = 3 },
                new Team { Id = 4, Name = "Nice", City = "Nasr", CoachId = 4 },
                new Team { Id = 5, Name = "Smachers", City = "Tahrir", CoachId = 5}

                );
            modelBuilder.Entity<Player>().HasData(
                new Player { Id = 1 , FullName = "Fawzy" , Position = "Attack" , Age = 10 , TeamId = 1},
                new Player { Id = 2 , FullName = "Gamal" , Position = "Defense" , Age = 16 , TeamId = 2},
                new Player { Id = 3 , FullName = "Ans" , Position = "L Wing" , Age = 18 , TeamId = 3},
                new Player { Id = 4 , FullName = "Yassin" , Position = "R Wing" , Age = 16 , TeamId = 4},
                new Player { Id = 5 , FullName = "Ibrahem" , Position = "Goal keper" , Age = 19 , TeamId = 5}

                );
            modelBuilder.Entity<Competition>().HasData(
                new Competition { Id = 1 , Title = "ComboB" , Location = "Nasr Club" , Date = new DateTime(2026 - 8 -15)},
                new Competition { Id = 2 , Title = "Pollan" , Location = "Mansoura" , Date = new DateTime(2025 - 10 -15)},
                new Competition { Id = 3 , Title = "Fatns" , Location = "Street" , Date = new DateTime(2029 - 1 -15)},
                new Competition { Id = 4 , Title = "Eating the ground" , Location = "Pyramids" , Date = new DateTime(2030 - 2 -15)},
                new Competition { Id = 5 , Title = "Fangle" , Location = "My home" , Date = new DateTime(2025 - 10 -20)}
                );
                
        }
    }
}
