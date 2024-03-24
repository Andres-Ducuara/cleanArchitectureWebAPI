using CA.Domain.Enitites;
using CA.Domain.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Services
{
    public class DetailsService : IDetailService
    {
        private readonly IDetailRepository _detailRepository;

        public DetailsService(IDetailRepository detailRepository)
        {
            _detailRepository = detailRepository;
        }

        public Task<List<SalesDetailDTO>> GetByIdAsync(int saleID)
        {
           return _detailRepository.GetByIdAsync(saleID);
        }

        public async Task<List<SalesDetailDTO>> GetByIdSaleAndIdDetailAsync(int saleID, int detailId)
        {
            return await _detailRepository.GetByIdSaleAndIdDetailAsync(saleID, detailId);  
        }
    }
}
