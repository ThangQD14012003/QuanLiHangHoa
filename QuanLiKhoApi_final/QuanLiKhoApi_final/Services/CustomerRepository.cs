using ApiQuanlikho.Datas;
using ApiQuanlikho.Models;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace ApiQuanlikho.Services
{
    public class CustomerRepository:ICustomerRepository
    {
        private readonly SaleDataContext _context;
        private readonly IMapper _mapper;

        public CustomerRepository(SaleDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> AddCustomerAsync(CustomerModel customer)
        {
            var newCustomer = _mapper.Map<Customer>(customer);
            _context.Customers.Add(newCustomer);
            await _context.SaveChangesAsync();
            return newCustomer.Id;
        }

        public async Task DeleteCustomerAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            if (customer != null)
            {
                _context.Customers.Remove(customer);
                await _context.SaveChangesAsync();
            }
        }

        //public void Dispose()
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<List<CustomerModel>> GetAllCustomerAsync()
        {
            var customers = await _context.Customers.ToListAsync();
            return _mapper.Map<List<CustomerModel>>(customers);
        }

        public async Task<CustomerModel> GetCustomerByIdAsync(int customerId)
        {
            var customer = await _context.Customers.FindAsync(customerId);
            return _mapper.Map<CustomerModel>(customer);
        }

        public async Task UpdateCustomerAsync(CustomerModel c, int id)
        {
            if (c.Id == id)
            {
                var updateC = _mapper.Map<Customer>(c);
                _context.Customers.Update(updateC);
                await _context.SaveChangesAsync();
            }
        }
    }
}
