using System.Xml.Linq;

namespace Terehov.OrdersAPI.Model
{
    public class Order
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public decimal Total { get; set; }

        public Guid BuyerId { get; set; }

        public List<Product> Products { get; set; }

        public Order(Guid id, decimal total, Guid buyerId, List<Product> products)
        {
            Id = id;
            Total = total;
            BuyerId = buyerId;
            Products = products;
        }
    }
}