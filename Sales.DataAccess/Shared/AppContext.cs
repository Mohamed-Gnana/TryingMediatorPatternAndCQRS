using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using Sales.DataAccess.Customers;
using Sales.DataAccess.Employees;
using Sales.DataAccess.Products;
using Sales.DataAccess.Sales;
using Sales.Domain.Customers;
using Sales.Domain.Employees;
using Sales.Domain.Entity;
using Sales.Domain.Products;
using Sales.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Shared
{
    public class AppContext : DbContext, IAppContext
    {
        #region fields
        private string _connectionString = null!;
        #endregion

        #region constructors
        public AppContext(
            string connectionString = "Data Source=.;Database = Sales;Integrated Security=True;")
        {
            _connectionString = connectionString;
        }
        #endregion

        #region public properities
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sale> Sales { get; set; }
        #endregion

        #region overriding
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new CustomerConfiguration());
            builder.ApplyConfiguration(new EmployeeConfiguration());
            builder.ApplyConfiguration(new ProductsConfiguration());
            builder.ApplyConfiguration(new SalesConfiguration());
        }
        #endregion

        #region methods
        public async Task Save()
        {
            await this.SaveChangesAsync();
        }
        public new DbSet<T> Set<T>() where T : class, IEntity
        {
            return base.Set<T>();
        }
        #endregion
    }
}
