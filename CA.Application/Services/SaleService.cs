using CA.Domain.Enitites;
using CA.Domain.Interface;
using CA.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository _saleRepository;

        public SaleService(ISaleRepository saleRepository)
        {
            _saleRepository = saleRepository;
        }


        public async Task<List<SaleDTO>> GetAllAsync(DateTime DStart, DateTime DEnd, string? filter = null)
        {
            return await _saleRepository.GetAllAsync(DStart, DEnd, filter);
        }

        public async Task<List<SaleDTO>> GetByIdAsync(int id)
        {
            return await _saleRepository.GetByIdAsync(id);
        }


        public async Task<int> DeleteAsync(int id)
        {
            return await _saleRepository.DeleteAsync(id); 
        }

        public async Task<int> UpdateAsync(int id, SaleDTO saleDto)
        {
            return await _saleRepository.UpdateAsync(id, saleDto);
        }

        public async Task<SaleCreateDTO> CreateAsync(SaleCreateDTO saleCreateDTO)
        {
            return await _saleRepository.CreateAsync(saleCreateDTO);
        }
    }
}
