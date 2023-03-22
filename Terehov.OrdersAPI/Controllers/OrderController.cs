using Microsoft.AspNetCore.Mvc;
using Terehov.OrdersAPI.Model;

namespace Terehov.OrdersAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        static List<Product> products = new List<Product>()
        {
            new Product(Guid.NewGuid(), "Product1", 10, 10),
            new Product(Guid.NewGuid(), "Product2", 12, 12),
            new Product(Guid.NewGuid(), "Product3", 14, 14),
            new Product(Guid.NewGuid(), "Product4", 16, 16),
            new Product(Guid.NewGuid(), "Product5", 18, 18),
        };

        static List<Order> orders = new List<Order>() 
        {
            new Order(Guid.NewGuid(), 20, Guid.NewGuid(), products),
            new Order(Guid.NewGuid(), 30, Guid.NewGuid(), products),
            new Order(Guid.NewGuid(), 40, Guid.NewGuid(), products),
            new Order(Guid.NewGuid(), 50, Guid.NewGuid(), products),
            new Order(Guid.NewGuid(), 60, Guid.NewGuid(), products),
        };

        [HttpGet]
        [Route("GetAllOrders")]
        public async Task<IActionResult> GetAllOrders()
        {
            return Ok(orders);
        }

        [HttpGet]
        [Route("GetOrderByID")]
        public async Task<IActionResult> GetAllOrders(Guid id)
        {

            foreach(var order in orders)
            {
                if (order.Id == id)
                    return Ok(order);
            }

            return BadRequest();
        }

        [HttpDelete]
        [Route("DeleteOrderByID")]
        public async Task<IActionResult> DeleteOrderByID(Guid id)
        {

            foreach (var order in orders)
            {
                if (order.Id == id)
                {
                    orders.Remove(order);
                    return Ok(order);
                } 
            }

            return BadRequest("Not found");
        }

        [HttpPost]
        [Route("CreateOrderByID")]
        public async Task<IActionResult> CreateOrderByID(Order order)
        {
            decimal totalPrice = 0;

            foreach(var total in order.Products)
            {
                totalPrice =+ total.Price * total.Quantity;
            }

            order.Total = totalPrice;

            orders.Add(order);

            return Ok(orders);
        }

        [HttpPut]
        [Route("UpdateOrderByID")]
        public async Task<IActionResult> UpdateOrderByID(Order order)
        {
            var existingOrder = orders.Find(order => order.Id == order.Id);

            decimal totalPrice = 0;

            foreach (var total in order.Products)
            {
                totalPrice =+ total.Price * total.Quantity;
            }

            existingOrder.Products = order.Products;
            existingOrder.Total = totalPrice;
            existingOrder.BuyerId = order.BuyerId;

            return Ok(orders);
        }
    }
}
