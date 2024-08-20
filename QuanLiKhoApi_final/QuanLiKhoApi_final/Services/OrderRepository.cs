using ApiQuanlikho.Datas;
using ApiQuanlikho.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiQuanlikho.Services
{
    public class OrderRepository:IOrderRepository
    {
        private readonly SaleDataContext _context;
        private readonly IMapper _mapper;

        public OrderRepository(SaleDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> AddOrderAsync(OrderModel order)
        {
            var newO = _mapper.Map<Order>(order);
            _context.Orders.Add(newO);
            await _context.SaveChangesAsync();
            return newO.Id;
        }

        public async Task DeleteOrderAsync(int OrderId)
        {
            var Or = _context.Orders.SingleOrDefault(o => o.Id == OrderId);
            if (Or != null)
            {
                _context.Orders.Remove(Or);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<OrderModel>> GetAllOrderAsync()
        {
            var order = await _context.Orders.ToListAsync();    
            return _mapper.Map<List<OrderModel>>(order);    
        }

        public async Task<OrderModel> GetOrderByIdAsync(int OrderId)
        {
            var order = await _context.Orders.FindAsync(OrderId);
            return _mapper.Map<OrderModel>(order);
        }

        public async Task UpdateOrderAsync(OrderModel Order, int id)
        {
            if (id == Order.Id)
            {
                var updateOrder = _mapper.Map<Order>(Order);
                _context.Orders.Update(updateOrder);
                await _context.SaveChangesAsync();
            }
        }
    }
}
