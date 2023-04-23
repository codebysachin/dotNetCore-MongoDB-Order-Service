using OrderService.Models;

namespace OrderService.Services
{
    public class OrderService : IOrderService
    {
        public Order GetOrderById(int id)
        {
            Order order = new Order();
            order.Id = 23456;
            order.OrderDate = System.DateTime.Today;
            order.CustomerName = "Jane Doe";
            order.TotalAmount = 1000;
            return order;
        }
    }
}
