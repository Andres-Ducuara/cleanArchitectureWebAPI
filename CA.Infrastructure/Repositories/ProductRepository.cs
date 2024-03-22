using CA.Domain.Enitites;
using CA.Domain.Interface;
using CA.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _appDbContext;

        public ProductRepository(AppDbContext appDbContext) 
        {
            _appDbContext = appDbContext;
        }

        public async Task<Product> CreateAsync (Product product)
        {
            _appDbContext.Products.Add(product);
            await _appDbContext.SaveChangesAsync();

            return product;
        }

        public async Task<int> DeleteAsync(int id)
        {
            return await _appDbContext.Products
                .Where (p => p.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Product>> GetAllAsync(string? filter = null)
        {
            IQueryable<Product> Products = _appDbContext.Products;

            if (!string.IsNullOrEmpty(filter))
            {
                Products = Products.Where(u => u.Name.Contains(filter));
            }
            return await Products.ToListAsync();
        }

        public async Task<Product> GetByIdAsync(int id)
        {
            return await _appDbContext.Products.AsNoTracking()
                .FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<int> UpdateAsync(int id, Product product)
        {
            return await _appDbContext.Products
                .Where(p => p.Id == id)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(p => p.Id, product.Id)
                    .SetProperty(p => p.Name, product.Name)
                    .SetProperty(p => p.Price, product.Price)
                    .SetProperty(p => p.Description, product.Description)
                );
        }
    }
}
