using CachingWithReflection.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CachingWithReflection.Repository
{
    public class OrderRepository
    {
        private List<Order> _orders;

        public OrderRepository()
        {
            _orders = new List<Order>();
        }

        public OrderRepository(List<Order> orders)
        {
            this._orders = orders ?? throw new ArgumentNullException(nameof(orders));
        }

        public Order GetByOrderId(int id)
        {
            return _orders.First(order => order.Id == id);
        }

        public void AddOrder(Order order)
        {
            _orders.Add(order);
        }

        public List<Order> GetOrdersByClientId(int clientId)
        {
            return _orders.Where(order => order.Id == clientId).ToList();
        }
    }
}
