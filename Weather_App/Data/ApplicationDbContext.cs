using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Weather_App.Models.Entities;

namespace Weather_App.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WeatherCurrent>()
                .HasOne(w => w.Location)
                .WithOne()
                .HasForeignKey<WeatherCurrent>(w => w.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherCurrent>()
                .HasOne(w => w.Current)
                .WithOne()
                .HasForeignKey<WeatherCurrent>(w => w.CurrentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherCurrent>()
                .HasOne(w => w.Account)
                .WithOne()
                .HasForeignKey<WeatherCurrent>(w => w.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecast>()
                .HasOne(w => w.Location)
                .WithOne()
                .HasForeignKey<WeatherForecast>(w => w.LocationId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecast>()
                .HasOne(w => w.Current)
                .WithOne()
                .HasForeignKey<WeatherForecast>(w => w.CurrentId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecast>()
                .HasOne(w => w.Account)
                .WithOne()
                .HasForeignKey<WeatherForecast>(w => w.AccountId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<WeatherForecast>()
                .HasMany(w => w.ForecastDays)
                .WithOne(fd => fd.WeatherForecast)
                .HasForeignKey(fd => fd.WeatherForecastId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ForecastDay>()
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
