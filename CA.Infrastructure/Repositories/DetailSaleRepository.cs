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
    public class DetailSaleRepository : IDetailRepository
    {
        private readonly AppDbContext _appDbContext;
        public DetailSaleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
   

        public async Task<List<SalesDetailDTO>> GetByIdAsync(int saleID)
        {
            IQueryable<SalesDetail> SalesDetails = _appDbContext.salesDetails;

            if (saleID != default)
            { 
                SalesDetails = SalesDetails.Where(s => s.SaleId.Equals(saleID));
            }

            var result = await SalesDetails.Select(sd => new SalesDetailDTO
            {
                Id = sd.Id,
                ProductId = sd.ProductId,
                Amount = sd.Amount,
                UnitPrice = sd.UnitPrice,
                Total = sd.Total
            }).ToListAsync();

            return result;
        }

        public async Task<List<SalesDetailDTO>> GetByIdSaleAndIdDetailAsync(int saleID, int detailId)
        {
            IQueryable<SalesDetail> SalesDetails = _appDbContext.salesDetails;

            if (saleID != default)
            {
                SalesDetails = SalesDetails.Where(s => s.SaleId.Equals(saleID));
            }

            var result = await SalesDetails.Select(sd => new SalesDetailDTO
            {
                Id = sd.Id,
                ProductId = sd.ProductId,
                Amount = sd.Amount,
                UnitPrice = sd.UnitPrice,
                Total = sd.Total
            }).ToListAsync();

            return result;

        }
    }
}
