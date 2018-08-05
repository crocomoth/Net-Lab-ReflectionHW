using CachingWithReflection.Helpers;
using CachingWithReflection.Models;
using CachingWithReflection.Repository;
using System;

namespace CachingWithReflection
{
    public class Service
    {
        ReflectionDataConverter _dataConverter;
        ClientRepository _clientRepository;
        OrderRepository _orderRepository;
        RedisHelper _redis;

        public Service(ClientRepository clientRepository, OrderRepository orderRepository)
        {
            _clientRepository = clientRepository ?? throw new ArgumentNullException(nameof(clientRepository));
            _orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
            _dataConverter = new ReflectionDataConverter();
            _redis = new RedisHelper();
        }

        public void AddClient(Person person)
        {
            _clientRepository.AddClient(person);
        }

        public void AddOrder(Order order)
        {
            _orderRepository.AddOrder(order);
        }

        public Person GetClientById(int id)
        {
            var value = _redis.GetValue("Client" + id.ToString());

            if (value == null)
            {
                string newValue = _dataConverter.GetDataAsString(_clientRepository.GetById(id));

                _redis.Cache("Client" + id.ToString(), newValue, GetRefresmentTime(typeof(Person)));
                return _clientRepository.GetById(id);
            }
            else
            {
                return _dataConverter.GetObjectFromString<Person>(value);
            }
        }

        public Order GetOrderById(int id)
        {
            var value = _redis.GetValue("Order" + id.ToString());

            if (value == null)
            {
                string newValue = _dataConverter.GetDataAsString(_orderRepository.GetByOrderId(id));

                _redis.Cache("Order" + id.ToString(), newValue, GetRefresmentTime(typeof(Order)));
                return _orderRepository.GetByOrderId(id);
            }
            else
            {
                return _dataConverter.GetObjectFromString<Order>(value);
            }
        }

        private TimeSpan GetRefresmentTime(Type t)
        {
            var attribute = (CachingAttribute)Attribute.GetCustomAttribute(t, typeof(CachingAttribute));

            if (attribute == null)
            {
                throw new Exception("attribute is null");
            }

            return TimeSpan.FromSeconds(attribute.CachingTime);
        }
    }
}
