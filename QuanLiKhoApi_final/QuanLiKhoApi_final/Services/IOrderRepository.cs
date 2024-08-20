using ApiQuanlikho.Models;

namespace ApiQuanlikho.Services
{
    public interface IOrderRepository
    {
        public Task<List<OrderModel>> GetAllOrderAsync();
        public Task<OrderModel> GetOrderByIdAsync(int OrderId);
        public Task DeleteOrderAsync(int OrderId);
        public Task<int> AddOrderAsync(OrderModel Order);
        public Task UpdateOrderAsync(OrderModel Order, int id);
    }
}
