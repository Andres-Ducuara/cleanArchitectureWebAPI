using CA.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Interface
{
    public interface ISaleRepository
    {
        Task<List<SaleDTO>> GetAllAsync(DateTime DStart, DateTime DEnd, string? filter = null);
        Task<List<SaleDTO>> GetByIdAsync(int id);

        Task<int> UpdateAsync(int id, SaleDTO saleDTO);
        Task<int> DeleteAsync(int id);


    }
}
