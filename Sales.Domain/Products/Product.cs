using Sales.Domain.Entity;
using Sales.Domain.Sales;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Products
{
    public class Product : IEntity
    {
        #region fields
        private int _id;
        private string _name = null!;
        private decimal _price;
        #endregion

        #region constructors
        public Product(string name, decimal price, ICollection<Sale>? sales = null)
        {
            _name = name;
            _price = price;
            Sales = sales is null ? new List<Sale>() : sales;
        }
        #endregion

        #region properities
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
        public decimal Price
        {
            get => _price;
            private set => _price = value;
        }
        public virtual ICollection<Sale>? Sales { get; set; }
        #endregion

        #region getters and setters
        public void SetName(string name)
        {
            Name = name;
        }
        public void SetPrice(decimal price)
        {
            Price = price;
        }
        #endregion

    }
}
