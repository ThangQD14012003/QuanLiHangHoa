using ApiQuanlikho.Datas;
using ApiQuanlikho.Models;
using AutoMapper;

namespace ApiQuanlikho.Helper
{
    public class AplicationMapper: Profile
    {
        public AplicationMapper()
        {
            CreateMap<Customer, CustomerModel>().ReverseMap();
            CreateMap<Product, ProductModel>().ReverseMap();
            CreateMap<Order, OrderModel>().ReverseMap();
        }
    }
}
