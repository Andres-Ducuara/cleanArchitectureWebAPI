using CA.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Interface
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync(string? filter = null);
        Task<Product> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<int> UpdateAsync(int id, Product product);
        Task<int> DeleteAsync(int id);
    }
}
