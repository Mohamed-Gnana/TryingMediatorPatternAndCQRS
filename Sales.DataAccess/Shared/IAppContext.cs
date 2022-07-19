using Microsoft.EntityFrameworkCore;
using Sales.Domain.Customers;
using Sales.Domain.Employees;
using Sales.Domain.Entity;
using Sales.Domain.Products;
using Sales.Domain.Sales;

namespace Sales.DataAccess.Shared
{
    public interface IAppContext
    {
        DbSet<Customer> Customers { get; set; }
        DbSet<Employee> Employees { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Sale> Sales { get; set; }

        Task Save();
        DbSet<T> Set<T>() where T : class, IEntity;
    }
}