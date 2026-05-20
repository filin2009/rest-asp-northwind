using Microsoft.EntityFrameworkCore;
using RestAspNorthwind.Models;

namespace RestAspNorthwind.Data
{
    public class NorthwindDbContext : DbContext
    {
        public NorthwindDbContext(DbContextOptions<NorthwindDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeTerritory> EmployeeTerritories { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Region> Region { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Territory> Territories { get; set; }
        public DbSet<CustomerDemographic> CustomerDemographics { get; set; }
        public DbSet<CustomerCustomerDemo> CustomerCustomerDemo { get; set; }
        public DbSet<UsState> UsStates { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasKey(c => c.CategoryId);
            modelBuilder.Entity<Customer>().HasKey(c => c.CustomerId);
            modelBuilder.Entity<Employee>().HasKey(e => e.EmployeeId);
            modelBuilder.Entity<EmployeeTerritory>().HasKey(et => new { et.EmployeeId, et.TerritoryId });
            modelBuilder.Entity<OrderDetail>().HasKey(od => new { od.OrderId, od.ProductId });
            modelBuilder.Entity<Order>().HasKey(o => o.OrderId);
            modelBuilder.Entity<Product>().HasKey(p => p.ProductId);
            modelBuilder.Entity<Region>().HasKey(r => r.RegionId);
            modelBuilder.Entity<Shipper>().HasKey(s => s.ShipperId);
            modelBuilder.Entity<Supplier>().HasKey(s => s.SupplierId);
            modelBuilder.Entity<Territory>().HasKey(t => t.TerritoryId);
            modelBuilder.Entity<CustomerDemographic>().HasKey(cd => cd.CustomerTypeId);
            modelBuilder.Entity<CustomerCustomerDemo>().HasKey(ccd => new { ccd.CustomerId, ccd.CustomerTypeId });
            modelBuilder.Entity<UsState>().HasKey(s => s.StateId);

            // TODO: configure column names and relationships as needed
        }
    }
}