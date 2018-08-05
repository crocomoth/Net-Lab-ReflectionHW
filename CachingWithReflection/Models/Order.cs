using System;

namespace CachingWithReflection.Models
{
    [Caching(15)]
    public class Order : ICachingModel
    {
        public Order()
        {
        }

        public Order(int id, int price, int ordererId)
        {
            Id = id;
            Price = price;
            OrdererId = ordererId;
        }

        public int Id { get; set; }

        public int Price { get; set; }

        public int OrdererId { get; set; }

        public override string ToString()
        {
            return "Id : " + Id + "Price : " + Price + "Orderer id : " + OrdererId;
        }
    }
}
