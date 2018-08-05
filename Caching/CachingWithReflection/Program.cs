using CachingWithReflection.Models;
using CachingWithReflection.Repository;
using System;
using System.Collections.Generic;

namespace CachingWithReflection
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Person> people = new List<Person>
            {
                new Person(1, "Jhon", "Smith"),
                new Person(2, "Jhon", "Grey"),
                new Person(3, "Lil", "Pump")
            };

            List<Order> orders = new List<Order>
            {
                new Order(1, 100, 1),
                new Order(2, 100, 1),
                new Order(3, 200, 2)
            };

            ClientRepository clientRepository = new ClientRepository(people);
            OrderRepository orderRepository = new OrderRepository(orders);

            Service service = new Service(clientRepository, orderRepository);

            string command = string.Empty;

            do
            {
                command = Console.ReadLine();

                var arr = command.Split(new char[] { ' ' }, 2);

                if (arr[0].Equals("client"))
                {
                    Console.WriteLine(service.GetClientById(Convert.ToInt32(arr[1])).ToString());
                }

                if (arr[0].Equals("order"))
                {
                    Console.WriteLine(service.GetOrderById(Convert.ToInt32(arr[1])));
                }
            } while (!command.Equals("exit"));
        }
    }
}
