using Sales.Domain.Customers;
using Sales.Domain.Employees;
using Sales.Domain.Entity;
using Sales.Domain.Products;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sales.Domain.Sales
{
    public class Sale : IEntity
    {
        #region fields
        private int _id;
        private int _quantity;
        private decimal _totalPrice;
        private decimal _unitPrice;
        private readonly DateTime _date;
        #endregion

        #region constructors
        public Sale(int quantity, decimal unitPrice, Employee employee, Customer customer, Product product)
        {
            if(customer is null)
            {
                throw new ArgumentNullException("There must be a customer");
            }
            if(product is null)
            {
                throw new ArgumentNullException("There must be a product");
            }
            if(employee is null)
            {
                throw new ArgumentNullException("There must be an employee");
            }
            if(_quantity <= 0)
            {
                throw new ArgumentException("Quantity must have a value");
            }
            if(unitPrice <= 0)
            {
                throw new ArgumentException("There must be a price");
            }
            _quantity = quantity;
            _unitPrice = unitPrice;
            _date = DateTime.Now;
            Employee = employee;
            Customer = customer;
            Product = product;
        }
        #endregion

        #region proprities
        public int Id
        {
            get => _id;
            private set => _id = value;
        }
        public int Quantity
        {
            get => _quantity;
            private set => _quantity = value;
        }
        public decimal UnitPrice
        {
            get => _unitPrice;
            private set
            {
                _unitPrice = value;
                UpdateTotalPrice();
            }
        }
        public decimal TotalPrice
        {
            get => _totalPrice;
            private set
            {
                _totalPrice = value;
            }
        }
        public DateTime Date
        {
            get => _date;
        }
        public virtual Employee Employee { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Product Product { get; set; }
        #endregion

        #region getters and setters
        public void SetQuantity(int quantity)
        {
            Quantity = quantity;
        }
        public void SetUnitPrice(decimal unitPrice)
        {
            UnitPrice = unitPrice;
        }
        #endregion

        public void UpdateTotalPrice()
        {
            _totalPrice = _unitPrice * _quantity;
        }


    }
}
