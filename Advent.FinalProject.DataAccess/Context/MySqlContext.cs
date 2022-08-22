using Advent.FinalProject.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent.FinalProject.DataAccess.Context
{
    public class MySqlContext: DbContext
    {
        private readonly string _connectionString = string.Empty;
        public DbSet<User> Users { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Booking> Bookings { get; set; }
        public DbSet<PaymentRecord> PaymentRecords { get; set; }
        public MySqlContext(DbContextOptions<MySqlContext> options) : base(options) { }
        public MySqlContext() => _connectionString = "server=localhost;uid=root;pwd=33474351Mgr*;database=adventfinalproject";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PaymentRecord>().HasKey(c => new { c.PaymentId });
            modelBuilder.Entity<PaymentRecord>().Property(c => c.PaymentId).UseIdentityColumn()
                .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            modelBuilder.Entity<User>().HasKey(c => new { c.PersonId });
            modelBuilder.Entity<User>().Property(c => c.PersonId).UseIdentityColumn()
                .Metadata.SetBeforeSaveBehavior(Microsoft.EntityFrameworkCore.Metadata.PropertySaveBehavior.Ignore);

            base.OnModelCreating(modelBuilder);
        }
    }
}
