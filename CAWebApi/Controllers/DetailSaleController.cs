using CA.Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace CAWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetailSaleController : ControllerBase
    {
        private readonly IDetailService _detailService;

        public DetailSaleController(IDetailService detailService)
        {
            _detailService = detailService;
        }

        [HttpGet("{saleID}")]
        public async Task<IActionResult> GetByIdAsync(int saleID)
        {
            var detailSale = await _detailService.GetByIdAsync(saleID);
            return Ok(detailSale);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdSaleAndIdDetailAsync(int saleID, int detailId)
        {
            var detailSale = await _detailService.GetByIdSaleAndIdDetailAsync(saleID, detailId);
            return Ok(detailSale);
        }
        

    }
}
