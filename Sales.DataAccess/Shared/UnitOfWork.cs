using Sales.Application.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.DataAccess.Shared
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IAppContext _appContext;

        public UnitOfWork(IAppContext appContext)
        {
            _appContext = appContext;
        }

        public void SaveAsync()
        {
            _appContext.Save();
        }
    }
}
