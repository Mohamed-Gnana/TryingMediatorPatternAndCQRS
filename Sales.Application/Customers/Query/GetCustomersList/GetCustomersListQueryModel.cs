using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using Sales.Domain.Sales;

namespace Sales.Application.Customers.Query.GetCustomersList
{
    public class GetCustomersListQueryModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public bool IsActive { get; set; }
        public ICollection<Sale>? Sales { get; set; }
    }
}
