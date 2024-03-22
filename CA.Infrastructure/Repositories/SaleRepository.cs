using AC.Domain.Enitites;
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
    public class SaleRepository : ISaleRepository
    {
        private readonly AppDbContext _appDbContext;

        public SaleRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<List<SaleDTO>> GetAllAsync(DateTime DStart, DateTime DEnd, string? filter = null)
        {
            IQueryable<Sale> Sales = _appDbContext.Sales.Include(u => u.UserID);

            DStart = DateTime.SpecifyKind(DStart, DateTimeKind.Utc);
            DEnd = DateTime.SpecifyKind(DEnd, DateTimeKind.Utc);

            if (DStart != default && DEnd != default)
            {
                Sales = Sales.Where(s => s.DateS >= DStart && s.DateS <= DEnd);
            }

            if (filter != null)
            {
                Sales = Sales.Where(s => s.UserID.DNI.Contains(filter) || s.UserID.Name.Contains(filter));
            }

            // Resultados en una lista de objetos DTO con los campos solicitados
            var result = await Sales.Select(s => new SaleDTO
            {
                Id = s.Id,
                UsuarioId = s.UserID.Id,
                NombreUsuario = s.UserID.Name,
                Fecha = s.DateS,
                Total = s.Total
            }).ToListAsync();

            return result;
        }

        public async Task<List<SaleDTO>> GetByIdAsync(int id)
        {
            IQueryable<Sale> Sales = _appDbContext.Sales.Include(u => u.UserID);

            

            if (id != default)
            {
                Sales = Sales.Where(s => s.Id >= id);
            }
 

            // Resultados en una lista de objetos DTO con los campos solicitados
            var result = await Sales.Select(s => new SaleDTO
            {
                Id = s.Id,
                UsuarioId = s.UserID.Id,
                NombreUsuario = s.UserID.Name,
                Fecha = s.DateS,
                Total = s.Total
            }).ToListAsync();

            return result;
        }



        public async Task<int> DeleteAsync(int id)
        {
            return await _appDbContext.Sales
                .Where(s => s.Id == id)
                .ExecuteDeleteAsync();
        }

        public async Task<int> UpdateAsync(int id, SaleDTO saleDTO)
        {
             var sale = await _appDbContext.Sales
                  .Include(s => s.UserID) 
                  .FirstOrDefaultAsync(s => s.Id == id);

            if (sale == null)
            {
                return 0;
            }

            sale.Id = saleDTO.Id;
            sale.UserID.Id = saleDTO.UsuarioId;
            sale.UserID.Name = saleDTO.NombreUsuario;
            sale.DateS = DateTime.SpecifyKind(saleDTO.Fecha, DateTimeKind.Utc);
            sale.Total = saleDTO.Total;

            return await _appDbContext.SaveChangesAsync();

        }
    }
}
