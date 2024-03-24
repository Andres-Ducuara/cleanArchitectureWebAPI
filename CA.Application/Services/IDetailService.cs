using CA.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Application.Services
{
    public interface IDetailService
    {
        Task<List<SalesDetailDTO>> GetByIdAsync(int saleID);
        Task<List<SalesDetailDTO>> GetByIdSaleAndIdDetailAsync(int saleID, int detailId);


    }
}
