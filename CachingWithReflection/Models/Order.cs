namespace CachingWithReflection.Models
{
    [Caching(10)]
    public class Order
    {
        public Order(int id, int price, int ordererId)
        {
            Id = id;
            Price = price;
            OrdererId = ordererId;
        }

        public int Id { get; set; }

        public int Price { get; set; }

        public int OrdererId { get; set; }
    }
}
