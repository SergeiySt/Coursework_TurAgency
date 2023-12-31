﻿using Microsoft.EntityFrameworkCore;


namespace Tur_agen_asp_net.Models
{
    public class ApDbContext : DbContext
    {
        public ApDbContext() { }
        public ApDbContext(DbContextOptions<ApDbContext> options) : base(options) { }

        public DbSet<Tour> Tour { get; set; }
        public DbSet<TourOrder> TourOrder { get; set; }
        public DbSet<UserOrderHistory> UserOrderHistory { get; set; }
        public DbSet<Users> User { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    //modelBuilder.Entity<TourOrder>()
        //    //    .HasOne(to => to.Tour)
        //    //    .WithMany()
        //    //    .HasForeignKey(to => to.id_tour);

        //    //modelBuilder.Entity<TourOrder>()
        //    //    .HasOne(to => to.User)
        //    //    .WithMany()
        //    //    .HasForeignKey(to => to.id_users);

        //    //modelBuilder.Entity<TourOrder>()
        //    //    .Property(to => to.TOSumm)
        //    //    .HasColumnType("decimal(18, 4)");

        //    //modelBuilder.Entity<Tour>()
        //    //    .Property(to => to.TPrice)
        //    //    .HasColumnType("decimal(18, 4)");

        //    base.OnModelCreating(modelBuilder);
        //}

        //protected override void OnConfiguring(DbContextOptionsBuilder options)
        //=> options.UseSqlServer("Server=192.168.226.130; Database=db_tur_agency;User=sa;Password=Colorado2023; TrustServerCertificate=True;");
    }
}
