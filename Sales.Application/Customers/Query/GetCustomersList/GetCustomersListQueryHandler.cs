using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Application.Customers.Query.GetCustomersList
{
    public class GetCustomersListQueryHandler : IRequestHandler<GetCustomersListQuery, List<GetCustomersListQueryModel>>
        {
        public Task<List<GetCustomersListQueryModel>> Handle(GetCustomersListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
