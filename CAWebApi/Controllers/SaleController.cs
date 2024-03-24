using CA.Application.Services;
using CA.Domain.Enitites;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CAWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SaleController : ControllerBase
    {
        private readonly ISaleService _saleService;

        public SaleController(ISaleService saleService)
        {
            _saleService = saleService;
        }

        //GET /api/ventas: Devuelve una lista de ventas.

        [HttpGet]
        public async Task<IActionResult> GetAllAsync(DateTime DStart, DateTime DEnd, string? filter = null)
        {
            var sales = await _saleService.GetAllAsync(DStart, DEnd, filter);
            return Ok(sales);   
        }


        // GET /api/ventas/{id}: Devuelve los detalles de una venta específica por su ID.
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var salesDto = await _saleService.GetByIdAsync(id);
            if (salesDto == null)
            {
                return NotFound();
            }
            return Ok(salesDto);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, SaleDTO saleDto)
        {
            int okSaleDto = await _saleService.UpdateAsync(id, saleDto);
            if (okSaleDto == 0)
            {
                return BadRequest();
            }
            return NoContent();
        }



        //DELETE /api/ventas/{id}: Recibe el ID de la venta a eliminar en la URL.
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            int sales = await _saleService.DeleteAsync(id);
            if (sales == 0)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SaleCreateDTO saleCreateDTO)
        {
            var createdSale = await _saleService.CreateAsync(saleCreateDTO);
            return CreatedAtAction(nameof(GetAllAsync), new { id = createdSale.DNI }, createdSale);
        }



    }
}
