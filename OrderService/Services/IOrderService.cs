using OrderService.Models;

namespace OrderService.Services
{
    public interface IOrderService
    {
        Order GetOrderById(int id);
    }
}
