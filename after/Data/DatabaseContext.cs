using before.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace before.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasData(
                new Customer { Id = 1, FirstName = "Petar", LastName = "Gligic" },
                new Customer { Id = 2, FirstName = "Ryan", LastName = "Ha" },
                new Customer { Id = 3, FirstName = "Jessica", LastName = "Fong" },
                new Customer { Id = 4, FirstName = "Adam", LastName = "Kita" },
                new Customer { Id = 5, FirstName = "Mohamed", LastName = "Alkakkali" }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order { Id = 1, Cost = 523.2, CustomerId = 1, ShippedDate = DateTimeOffset.UtcNow.AddDays(-2) },
                new Order { Id = 2, Cost = 22.5, CustomerId = 1, ShippedDate = DateTimeOffset.UtcNow.AddDays(-3) },
                new Order { Id = 3, Cost = 56.2, CustomerId = 2, ShippedDate = DateTimeOffset.UtcNow.AddDays(-5) },
                new Order { Id = 4, Cost = 97.2, CustomerId = 3, ShippedDate = DateTimeOffset.UtcNow.AddDays(-1) },
                new Order { Id = 5, Cost = 342.4, CustomerId = 4, ShippedDate = DateTimeOffset.UtcNow.AddDays(-2) },
                new Order { Id = 6, Cost = 6767.3, CustomerId = 5, ShippedDate = DateTimeOffset.UtcNow.AddDays(-6) }
            );
        }
    }
}
