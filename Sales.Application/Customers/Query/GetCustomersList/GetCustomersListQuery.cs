using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Customers.Query.GetCustomersList
{
    public record GetCustomersListQuery() : IRequest<List<GetCustomersListQueryModel>>;
}
