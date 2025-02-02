using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeatherApp.Blazor.Models.Entities;
using WeatherApp.Shared.Models.Entities;
using WeatherApp.Shared.Models.Entities.Management;

namespace WeatherApp.Blazor.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext<ApplicationUser>(options)
    {
        public DbSet<WeatherForecastBlazor>? WeatherForecast { get; set; }
        public DbSet<WeatherCurrentBlazor>? WeatherCurrent { get; set; }
        public DbSet<Location>? Location { get; set; }

        public DbSet<Current>? Current { get; set; }

        public DbSet<Condition>? Condition { get; set; }

        public DbSet<Astro>? Astro { get; set; }

        public DbSet<ForecastDayBlazor>? ForecastDay { get; set; }

        public DbSet<ForecastHourBlazor>? ForecastHour { get; set; }

        public DbSet<SyncRequestInfo>? SyncRequestInfo { get; set; }

        public override DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WeatherCurrentBlazor>()
                .HasOne(w => w.Location)
                .WithOne()
                .HasForeignKey<WeatherCurrentBlazor>(w => w.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherCurrentBlazor>()
                .HasOne(w => w.Current)
                .WithOne()
                .HasForeignKey<WeatherCurrentBlazor>(w => w.CurrentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherCurrentBlazor>()
                .HasOne<ApplicationUser>(w => w.Account)
                .WithMany()
                .HasForeignKey(w => w.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecastBlazor>()
                .HasOne(w => w.Location)
                .WithOne()
                .HasForeignKey<WeatherForecastBlazor>(w => w.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecastBlazor>()
                .HasOne(w => w.Current)
                .WithOne()
                .HasForeignKey<WeatherForecastBlazor>(w => w.CurrentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecastBlazor>()
                .HasOne<ApplicationUser>(w => w.Account)
                .WithMany()
                .HasForeignKey(w => w.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecastBlazor>()
                .HasMany(w => w.ForecastDays)
                .WithOne(fd => fd.WeatherForecast)
                .HasForeignKey(fd => fd.WeatherForecastId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ForecastDayBlazor>()
                .HasMany(fd => fd.ForecastHours)
                .WithOne(fh => fh.ForecastDay)
                .HasForeignKey(fh => fh.ForecastDayId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Current>()
                .HasOne(c => c.Condition)
                .WithOne()
                .HasForeignKey<Current>(c => c.ConditionId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
