
using Domain.Entities.Common;
using Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Context
{
    public class RandevuUygulamasiDbContext : IdentityDbContext<AppUser, AppRole, Guid>
    {
        public RandevuUygulamasiDbContext(DbContextOptions<RandevuUygulamasiDbContext> options)
            : base(options)
        {
        }

        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Randevu>()
                .HasOne(r => r.User)
                .WithMany(u => u.Randevular)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<RefreshToken>()
                .HasOne(rt => rt.User)
                .WithMany(u => u.RefreshTokens)
                .HasForeignKey(rt => rt.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.Entity<WorkingHours>()
                .HasIndex(w => w.DayOfWeek)
                .IsUnique();

            builder.Entity<Holiday>()
                .HasIndex(h => h.Date)
                .IsUnique();

            builder.Entity<RefreshToken>()
                .HasIndex(rt => rt.Token);
        }
    }
}
