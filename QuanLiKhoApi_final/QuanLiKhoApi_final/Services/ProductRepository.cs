using ApiQuanlikho.Datas;
using ApiQuanlikho.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApiQuanlikho.Services
{
    public class ProductRepository : IProductRepository
    {
        private readonly SaleDataContext _context;
        private readonly IMapper _mapper;

        public ProductRepository(SaleDataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<int> Add([FromForm]ProductModel model)
        {
            var uploadImage = Path.Combine(Directory.GetCurrentDirectory(),"wwwroot", "Images", model.image.FileName);
            using(var stream = new FileStream(uploadImage, FileMode.Create))
            {
                await model.image.CopyToAsync(stream);
            }
            var newP = _mapper.Map<Product>(model);
            newP.image = uploadImage;
            _context.Products.Add(newP);
            await _context.SaveChangesAsync();
            return newP.Id;
        }

        public async Task DeleteById(int id)
        {
            var Pro = await _context.Products.FindAsync(id);
            if(Pro != null)
            {
                _context.Products.Remove(Pro); 
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Product>> GetAll()
        {
            var ListPro = await _context.Products.ToListAsync();
            return _mapper.Map<List<Product>>(ListPro);
        }

        public async Task<Product> GetById(int id)
        {
            var Pro = await _context.Products.FindAsync(id);
            return _mapper.Map<Product>(Pro);
        }

        public async Task Update(ProductModel model, int id)
        //public async Task Update([FromForm] ProductModel model, int id) đang k hiểu tại sao để như trên vẫn chạy đúng
        {
            var uploadImage = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Images", model.image.FileName);
            using (var stream = new FileStream(uploadImage, FileMode.Create))
            {
                await model.image.CopyToAsync(stream);
            }
            if (model.Id == id)
            {
                var updateP = _mapper.Map<Product>(model);
                updateP.image = uploadImage;
                _context.Products.Update(updateP);
                await _context.SaveChangesAsync();
            }
        }
    }
}
