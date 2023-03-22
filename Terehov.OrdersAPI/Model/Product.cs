namespace Terehov.OrdersAPI.Model
{
    public class Product
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public Product(Guid id, string name, decimal price, int quantity)
        {
            Id = id;
            Name = name;
            Price = price;
            Quantity = quantity;
        }
    }
}
