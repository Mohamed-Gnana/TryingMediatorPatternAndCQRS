using Sales.Domain.Entity;
using Sales.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Customers
{
    public class Customer: IEntity
    {
        #region private fields
        private int _id;
        private string _name = null!;
        private bool _isActive;
        #endregion

        #region constructors
        public Customer(string name, ICollection<Sale>? sales = null)
        {
            _name = name;
            _isActive = false;
            Sales = sales is null ? new List<Sale>() : sales ;
        }
        #endregion

        #region public properities
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
        public bool IsActive
        {
            get => _isActive;
            set => _isActive = value;
        }
        public virtual ICollection<Sale>? Sales { get; set; }
        #endregion

        #region public Setter and Getter
        public void SetName(string name)
        {
            _name = name;
        }
        #endregion

        #region Methods
        public Customer Activate()
        {
            this._isActive = true;
            return this;
        }
        public Customer Deactivate()
        {
            this._isActive = false;
            return this;
        }
        #endregion


    }
}
