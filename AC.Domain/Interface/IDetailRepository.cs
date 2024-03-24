using CA.Domain.Enitites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CA.Domain.Interface
{
    public interface IDetailRepository
    {
        Task<List<SalesDetailDTO>> GetByIdAsync(int saleID);
        Task<List<SalesDetailDTO>> GetByIdSaleAndIdDetailAsync(int saleID, int detailId);
        
    }
}
