using ApiQuanlikho.Models;

namespace ApiQuanlikho.Services
{
    public interface ICustomerRepository
    {
        public Task<List<CustomerModel>> GetAllCustomerAsync();
        public Task<CustomerModel> GetCustomerByIdAsync(int customerId);
        public Task DeleteCustomerAsync(int customerId);
        public Task<int> AddCustomerAsync(CustomerModel customer);
        //public Task<int> AddOrderAsync(OrderModel Order);
        public Task UpdateCustomerAsync(CustomerModel customer, int id);
    }
}
