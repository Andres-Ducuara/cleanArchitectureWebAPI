using AC.Domain.Enitites;
using CA.Domain.Enitites;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Services
{
    public interface ISaleService
    {
        Task<List<SaleDTO>> GetAllAsync(DateTime DStart, DateTime DEnd,  string? filter = null);
        Task<List<SaleDTO>> GetByIdAsync(int id);
        Task<int> UpdateAsync(int id, SaleDTO saleDto);
        Task<int> DeleteAsync(int id);

        Task<SaleCreateDTO> CreateAsync([FromBody] SaleCreateDTO saleCreateDTO);
      
    }
}