using Sales.Domain.Entity;
using Sales.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Employees
{
    public class Employee : IEntity
    {
        #region private fields
        private int _id;
        private string _name = null!;
        #endregion

        #region constructors
        public Employee(string name, ICollection<Sale>? sales = null)
        {
            _name = name;
            Sales = sales is null ? new List<Sale>() : sales;
        }
        #endregion

        #region public properites
        public int Id
        {
            get => _id;
            private set => _id = value;
        }
        public string Name
        {
            get => _name;
            private set => _name = value;
        }
        public virtual ICollection<Sale>? Sales { get; set; }
        #endregion

        #region setters and getters
        public void SetName(string name)
        {
            Name = name;
        }
        #endregion

    }
}
